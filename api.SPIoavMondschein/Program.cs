using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using Repository;
using Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using Repository.Models;
using Services.Validaciones;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register DbContext
var connectionString = builder.Configuration.GetConnectionString("postgres");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<FacturaRepository>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FacturaService>();

builder.Services.AddScoped<IValidator<ClienteModel>, ClienteValidator>();
builder.Services.AddScoped<IValidator<FacturaModel>, FacturaValidator>();

builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
