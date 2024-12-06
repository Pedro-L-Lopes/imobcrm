using FluentValidation;
using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.DTOs.Locations;
using imobcrm.Middlewares;
using imobcrm.Repository;
using imobcrm.Repository.Interfaces;
using imobcrm.Services;
using imobcrm.Services.Interfaces;
using imobcrm.Validators;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions
        .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()  // Permite qualquer origem
              .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando banco de dados
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection)));

// Validações FluentValidation
builder.Services.AddTransient<IValidator<ClienteDTO>, ClienteValidator>();
builder.Services.AddTransient<IValidator<LocalizacaoDTO>, LocalizacaoValidator>();
builder.Services.AddTransient<IValidator<ImovelDTO>, ImovelValidator>();
builder.Services.AddTransient<IValidator<VisitaDTO>, VisitaValidator>();

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Services e Repositórios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
builder.Services.AddScoped<ILocalizacaoService, LocalizacaoService>();
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddScoped<IImovelService, ImovelService>();
builder.Services.AddScoped<IVisitaRepository, VisitaRepository>();
builder.Services.AddScoped<IVisitaService, VisitaService>();

// UOF
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PermitirTudo");

app.UseMiddleware<ExceptionMiddleware>();
app.UseValidationMiddleware<ClienteDTO>();
app.UseValidationMiddleware<LocalizacaoDTO>();
app.UseValidationMiddleware<ImovelDTO>();
app.UseValidationMiddleware<VisitaDTO>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
