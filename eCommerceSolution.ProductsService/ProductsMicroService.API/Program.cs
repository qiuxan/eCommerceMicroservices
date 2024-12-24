using eCommerce.ProductsMicroService.BusinessLogicLayer;
using eCommerce.ProductsMicroService.DataAccessLayer;
using FluentValidation.AspNetCore;
using ProductsMicroService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Add DAL and BLL services

builder.Services.AddDataAccessLayer();
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

//Enable FluentValidation
builder.Services.AddFluentValidationAutoValidation();


var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();

//Auth

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
