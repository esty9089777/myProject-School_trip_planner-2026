using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using myProjectTrips.Interfaces;
using myProjectTrips.model;
using Repository.Entities;
using Service.Authorization;
using Service.Extensions;
using Service.Interfaces;
using Service.Services;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



var connection = builder.Configuration.GetConnectionString("databasa-myComputer");

//builder.Services.AddSingleton<IContext>(new TripContext(connection));

builder.Services.AddDbContext<TripContext>(option => option.UseSqlServer(connection));
builder.Services.AddScoped<IContext>(provider => provider.GetRequiredService<TripContext>());
builder.Services.AddAuthentication("CustomScheme")
    .AddScheme<AuthenticationSchemeOptions, CustomAuthHandler>("CustomScheme", null);


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditPolicy", policy =>
        policy.Requirements.Add(new SameAuthorRequirement()));
});

builder.Services.AddScoped<IAuthorizationHandler, OwnershipHandler>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddServices();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<Service.Services.MapperProfile>();
}); var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// 2. מחלקה פנימית קטנה שתקרא את הטוקן באמצעות החבילה שיש לך
public class CustomAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public CustomAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
        : base(options, logger, encoder) { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // קריאת הטוקן מה-Header שהדפדפן או פוסטמן שולחים
        if (!Request.Headers.TryGetValue("Authorization", out var authHeader))
            return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

        try
        {
            var token = authHeader.ToString().Replace("Bearer ", "");

            // שימוש בדיוק בחבילה שיש לך (System.IdentityModel.Tokens.Jwt) כדי לפענח
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // חילוץ המשתמש והעברתו למערכת ההרשאות שלך
            var identity = new ClaimsIdentity(jwtToken.Claims, "CustomAuth");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "CustomScheme");

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        catch
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Token"));
        }
    }
}