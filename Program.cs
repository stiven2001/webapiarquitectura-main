using System.Text;
using System.Text.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
    });
}

app.UseHttpsRedirection();

app.MapPost("/countcharacters", (Request? body) =>
{
    if (body == null || body.text == null)
    {
        return "No se recibió ningun texto para contar caracteres";
    }

    var characterCount = body.text.Length;
    
    return $"La cantidad de caracteres es: {characterCount.ToString()}";
});

app.Run();

public class Request
{
    public string? text { get; set; }
}