using System.Text.Json.Serialization;
using eCommerce.ProductsMicroService.API.APIEndpoints;
using eCommerce.ProductsMicroService.DataAccessLayer;
using eCommerce.ProductsService.BusinessLogicLayer;
using FluentValidation.AspNetCore;
using ProductsMicroService.API.Middleware;


var builder = WebApplication.CreateBuilder(args);

//Add DAL and BLL services

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

//Enable FluentValidation
builder.Services.AddFluentValidationAutoValidation();

//Add model binder to read value from json to enum
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); // add options to configure the JSON serializer and it is different from using controller options as it is using minimal API


var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();

//Auth

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapProductAPIEndpoints();


app.Run();
