using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//add services to the

builder.Services.AddInfrastructure();
builder.Services.AddCore();

//add controllers
builder.Services.AddControllers().AddJsonOptions
    (options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();

//Add API explorer services
builder.Services.AddEndpointsApiExplorer();

//Add Swagger generator services to create Swagger specifications

builder.Services.AddSwaggerGen();

//Add Cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") //Allow requests from the Angular app
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

app.UseSwagger(); //Add endpoint to serve generated Swagger as a JSON endpoint

app.UseSwaggerUI();// Add swagger UI (interactive page to explore and test API endpoints)

app.UseCors();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//map controllers
app.MapControllers();

app.Run();
