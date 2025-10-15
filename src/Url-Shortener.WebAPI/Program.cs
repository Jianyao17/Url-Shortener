using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using UrlShortener.WebAPI.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options 
    => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.Run();