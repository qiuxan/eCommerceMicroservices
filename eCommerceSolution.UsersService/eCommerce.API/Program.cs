using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//add services to the

builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
