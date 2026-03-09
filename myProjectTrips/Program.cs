using myProjectTrips.Interfaces;
using myProjectTrips.model;
using Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository.Entities;
using System.Text;
using AutoMapper;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



var connection = builder.Configuration.GetConnectionString("databasa-myComputer");

//builder.Services.AddSingleton<IContext>(new TripContext(connection));

builder.Services.AddDbContext<TripContext>(option => option.UseSqlServer(connection));
builder.Services.AddScoped<IContext>(provider => provider.GetRequiredService<TripContext>());

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddServices();
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


