using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//add services to the

builder.Services.AddInfrastructure();
builder.Services.AddCore();

//add controllers
builder.Services.AddControllers();

var app = builder.Build();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//map controllers
app.MapControllers();

app.Run();
