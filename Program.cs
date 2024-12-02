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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando banco de dados
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection)));

// Valida��es FluentValidation
builder.Services.AddTransient<IValidator<ClienteDTO>, ClienteValidator>();
builder.Services.AddTransient<IValidator<LocalizacaoDTO>, LocalizacaoValidator>();
builder.Services.AddTransient<IValidator<ImovelDTO>, ImovelValidator>();

// Configura��o do AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Services e Reposit�rios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
builder.Services.AddScoped<ILocalizacaoService, LocalizacaoService>();
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddScoped<IImovelService, ImovelService>();

// UOF
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseValidationMiddleware<ClienteDTO>();
app.UseValidationMiddleware<LocalizacaoDTO>();
app.UseValidationMiddleware<ImovelDTO>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
