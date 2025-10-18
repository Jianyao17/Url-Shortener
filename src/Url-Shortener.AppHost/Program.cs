
var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithImage("postgres:17-alpine")
    .WithDataVolume()
    .WithPgAdmin()
    .AddDatabase( "url-shortener");

var redis = builder.AddRedis("redis");

var urlShortenerApi = builder
    .AddProject<Projects.Url_Shortener_WebAPI>("url-shortener-webapi")
    .WithHttpEndpoint(port: 5001, name: "UrlShortenerApi")
    .WithExternalHttpEndpoints()
    .WithReference(postgres)
    .WithReference(redis)
    .WaitFor(postgres)
    .WaitFor(redis);

builder.Build().Run();
