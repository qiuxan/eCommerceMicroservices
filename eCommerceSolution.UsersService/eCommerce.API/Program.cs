using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//add services to the

builder.Services.AddInfrastructure();
builder.Services.AddCore();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
