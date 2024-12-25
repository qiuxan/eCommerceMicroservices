using eCommerce.BusinessLogicLayer.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.ProductsMicroService.BusinessLogicLayer;
public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        //TODO: Add data Access Layer services into the IoC container
        // add mappper services into the IoC container
        services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile)// once is enough, it will scan the whole assembly with the type of ProductAddRequestToProductMappingProfile which is Profile
            .Assembly);

        return services;
    }
}

