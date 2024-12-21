using System.Reflection;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Core;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the DI container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection
        AddCore(this IServiceCollection services)
    {
        //TODO: Add services to the IoC container

        //Core services often include data access, caching and other low-level components

        services.AddTransient<IUsersService,UsersService>();

        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}