using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using imobcrm.DTOs.Locations;
using imobcrm.DTOs;

namespace imobcrm.Middlewares
{
    public class ValidationMiddleware<T> where T : class
    {
        private readonly RequestDelegate _next;
        private readonly IValidator<T> _validator;

        public ValidationMiddleware(RequestDelegate next, IValidator<T> validator)
        {
            _next = next;
            _validator = validator;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if ((context.Request.Path.StartsWithSegments("/cliente") && typeof(T) == typeof(ClienteDTO)) ||
                (context.Request.Path.StartsWithSegments("/localizacao") && typeof(T) == typeof(LocalizacaoDTO)) ||
                (context.Request.Path.StartsWithSegments("/imovel") && typeof(T) == typeof(ImovelDTO)))
            {
                if (context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put)
                {
                    context.Request.EnableBuffering();
                    var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    context.Request.Body.Position = 0;

                    var model = JsonSerializer.Deserialize<T>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (model != null)
                    {
                        var validationResult = await _validator.ValidateAsync(model);
                        if (!validationResult.IsValid)
                        {
                            var errorResponse = new
                            {
                                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                                title = "One or more validation errors occurred.",
                                status = 400,
                                traceId = context.TraceIdentifier,
                                errors = validationResult.Errors
                                    .GroupBy(e => e.PropertyName.ToLower())
                                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray())
                            };

                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsJsonAsync(errorResponse);
                            return;  // Interrompe a requisição
                        }
                    }
                }
            }

            await _next(context);  // Chama o próximo middleware apenas se a validação passar
        }


    }

    public static class ValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationMiddleware<T>(this IApplicationBuilder builder) where T : class
        {
            return builder.UseMiddleware<ValidationMiddleware<T>>();
        }
    }
}
