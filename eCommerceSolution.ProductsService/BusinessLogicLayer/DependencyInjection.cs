using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.ProductsMicroService.BusinessLogicLayer;
public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        //TODO: Add data Access Layer services into the IoC container
        return services;
    }
}

