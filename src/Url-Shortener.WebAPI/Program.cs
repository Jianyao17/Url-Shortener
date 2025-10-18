using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;
using UrlShortener.WebAPI.Config;
using UrlShortener.WebAPI.Database;
using UrlShortener.WebAPI.Endpoints;
using UrlShortener.WebAPI.Entities;
using UrlShortener.WebAPI.Extensions;
using UrlShortener.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults(); // Adds logging, configuration, and other common services from Aspire
builder.AddNpgsqlDbContext<AppDbContext>("url-shortener");
builder.AddRedisDistributedCache("redis");

// Load all configuration sections from "Configs" namespace
builder.Services.AddAllConfigs(builder.Configuration);

// Identity and Authentication
builder.Services
    .AddIdentityApiEndpoints<User>(builder.LoadIdentityConfig())
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Add JWT Authentication
builder.Services.AddJwtAuthentication();

builder.Services.AddOpenApi();
builder.Services.AddHybridCache();

// Application Services
builder.Services.AddScoped<JwtIdentityService>();
builder.Services.AddScoped<UrlShortenerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseDeveloperExceptionPage();
    
    // Apply pending migrations at startup
    app.ExecuteMigration();
}

// API Endpoints
app.MapGetShortenUrlEndpoints();
app.MapShortUrlsEndpoints();
app.MapUsersAuthEndpoints();

// Middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();