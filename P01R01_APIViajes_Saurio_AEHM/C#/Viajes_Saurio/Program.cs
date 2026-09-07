using Microsoft.EntityFrameworkCore;
using Viajes_Saurio.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opciones =>
        opciones.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")??""));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // AGREGA ESTAS LÍNEAS AQUÍ:
    app.UseSwaggerUI(options =>
    {
        // Enlaza la interfaz gráfica con el JSON nativo de .NET 10
        options.SwaggerEndpoint("/openapi/v1.json", "Viajes_Saurio v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
