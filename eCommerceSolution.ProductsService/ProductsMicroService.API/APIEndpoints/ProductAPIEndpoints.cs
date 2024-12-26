using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;

namespace eCommerce.ProductsMicroService.API.APIEndpoints;

public static class ProductAPIEndpoints
{
    public static IEndpointRouteBuilder MapProductAPIEndpoints(this IEndpointRouteBuilder app)
    {
        //GET /api/products
        app.MapGet("/api/products", async (IProductsService productService) =>
        {
            List<ProductResponse?> products = await productService.GetProducts();
            return Results.Ok(products);
        });

        //GET /api/products/search/product-id/00000000-0000-0000-0000-000000000000
        app.MapGet("/api/products/search/product-id/{productID}", async (IProductsService productService, Guid productID) =>
        {
            ProductResponse? product = await productService.GetProductByCondition(p => p.ProductID == productID);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        });

        return app;
    }
}
