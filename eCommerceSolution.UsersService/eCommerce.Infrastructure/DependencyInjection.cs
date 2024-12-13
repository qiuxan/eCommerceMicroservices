using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastructure;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the DI container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection 
        AddInfrastructure( this IServiceCollection services)
    {
        //TODO: Add services to the IoC container

        //infrastructure services often include data access, caching and other low-level components

        return services;
    }
}
