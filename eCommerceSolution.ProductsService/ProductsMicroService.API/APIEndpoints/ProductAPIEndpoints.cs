using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using FluentValidation;
using FluentValidation.Results;

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
        app.MapGet("/api/products/search/product-id/{productID:guid}", async (IProductsService productService, Guid productID) =>
        {
            ProductResponse? product = await productService.GetProductByCondition(p => p.ProductID == productID);
        
            return Results.Ok(product);
        });

        //GET /api/products/search/xxxx
        app.MapGet("/api/products/search/{SearchString}", async (IProductsService productService, string SearchString) =>
        {
            List<ProductResponse?> productsByProductName = await productService.GetProductsByCondition(p => 
                p.ProductName != null&&
                p.ProductName.Contains(SearchString, StringComparison.OrdinalIgnoreCase));

            List<ProductResponse?> productsByProductCategory = await productService.GetProductsByCondition(p =>
                p.Category != null &&
                p.Category.Contains(SearchString, StringComparison.OrdinalIgnoreCase));

            var products = productsByProductName.Union(productsByProductCategory);

            return Results.Ok(products);
        });

        app.MapPost("/api/products",async (IValidator<ProductAddRequest> ProductAddValidator, IProductsService productsService, ProductAddRequest productAddRequest)=> 
        {
            ValidationResult validationResult = await ProductAddValidator.ValidateAsync(productAddRequest);
            if (!validationResult.IsValid)
            {
                Dictionary<string, string[]> errors =  
                    validationResult.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary
                        (
                            group => group.Key, 
                            group => group.Select(err => err.ErrorMessage).ToArray()
                        );
                return Results.ValidationProblem(errors);
            }

            ProductResponse?  addedProduct= await productsService.AddProduct(productAddRequest);

            if (addedProduct != null)
            {
                return Results.Created($"/api/products/search/product-id/{addedProduct.ProductID}",addedProduct);
            }

            return Results.Problem("Error in adding product");

        });
        //PUT /api/products
        app.MapPut("/api/products", async (IValidator<ProductUpdateRequest> ProductUpdateValidator, IProductsService productsService, ProductUpdateRequest productUpdateRequest) =>
        {

            ValidationResult validationResult = await ProductUpdateValidator.ValidateAsync(productUpdateRequest);
            if (!validationResult.IsValid)
            {
                Dictionary<string, string[]> errors =
                    validationResult.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary
                        (
                            group => group.Key,
                            group => group.Select(err => err.ErrorMessage).ToArray()
                        );
                return Results.ValidationProblem(errors);
            }
            ProductResponse? updateProduct = await productsService.UpdateProduct(productUpdateRequest);

            if(updateProduct != null)
            {
                return Results.Ok(updateProduct);
            }

            return Results.Problem("Error in updating product");
        });

        app.MapDelete("/api/products/{productID:guid}", async (IProductsService productsService, Guid productID) =>
        {
            bool isDeleted = await productsService.DeleteProduct(productID);
            if(isDeleted)
                return Results.Ok(isDeleted);

            return Results.Problem("Error in deleting product");
        });

        app.MapGet("/api/products/search/category/{category}", async (IProductsService productsService, string category) =>
        {
            List<ProductResponse?> products = await productsService.GetProductsByCondition(p => p.Category == category);

            return Results.Ok(products);
        });

        return app;
    }
}
