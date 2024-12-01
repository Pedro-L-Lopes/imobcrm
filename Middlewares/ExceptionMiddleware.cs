using imobcrm.Errors;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException ex)
        {
            // Captura a CustomException e retorna o status e a mensagem personalizados
            Console.WriteLine($"CustomException lançada: {ex.StatusCode}, {ex.Message}");
            await HandleCustomExceptionAsync(context, ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            // Captura todas as exceções não tratadas
            Console.WriteLine($"Unhandled Exception: {ex.Message}");
            await HandleUnexpectedExceptionAsync(context, ex);
        }
    }

    private static Task HandleCustomExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        var errorResponse = new
        {
            type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            title = "Erro personalizado.",
            status = (int)statusCode,
            traceId = context.TraceIdentifier,
            message
        };

        context.Response.StatusCode = (int)statusCode; // Aqui definimos o status que foi passado na exceção
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsJsonAsync(errorResponse, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }

    private static Task HandleUnexpectedExceptionAsync(HttpContext context, Exception ex)
    {
        var errorResponse = new
        {
            type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            title = "Erro inesperado.",
            status = StatusCodes.Status500InternalServerError,
            traceId = context.TraceIdentifier,
            message = "Ocorreu um erro interno no servidor."
        };

        context.Response.StatusCode = StatusCodes.Status500InternalServerError; // Erro 500 para exceções não tratadas
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsJsonAsync(errorResponse, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }
}
