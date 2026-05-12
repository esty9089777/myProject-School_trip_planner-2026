using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using myProjectTrips.Interfaces;
using myProjectTrips.model;
using Repository.Entities;
using Repository.Entities;
using Service.Authorization;
using Service.Extensions;
using Service.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



var connection = builder.Configuration.GetConnectionString("databasa-myComputer");

//builder.Services.AddSingleton<IContext>(new TripContext(connection));

builder.Services.AddDbContext<TripContext>(option => option.UseSqlServer(connection));
builder.Services.AddScoped<IContext>(provider => provider.GetRequiredService<TripContext>());
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditPolicy", policy =>
        policy.Requirements.Add(new SameAuthorRequirement()));
});

builder.Services.AddScoped<IAuthorizationHandler, OwnershipHandler>();

builder.Services.AddServices();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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


