using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using Microsoft.Extensions.Configuration;
using System;


var builder = WebApplication.CreateBuilder(args);

    
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
});

// builder.Services.AddDbContext<ApplicationDBContext>(options =>{
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));});
builder.Services.AddControllers();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite(connectionString));
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ❌ REMOVE or COMMENT this line to avoid HTTPS redirection errors
// app.UseHttpsRedirection();

app.MapAreaControllerRoute(
    name: "default",
    areaName: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
