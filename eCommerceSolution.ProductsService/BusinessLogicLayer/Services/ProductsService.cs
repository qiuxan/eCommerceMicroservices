using System.Linq.Expressions;
using AutoMapper;
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using eCommerce.DataAccessLayer.Entities;
using eCommerce.DataAccessLayer.RepositoryContracts;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLogicLayer.Services;
public class ProductsService: IProductsService
{
    private readonly IValidator<ProductAddRequest> _productAddRequestValidator;
    private readonly IValidator<ProductUpdateRequest> _productUpdateRequestValidator;
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public ProductsService(
        IValidator<ProductAddRequest> productAddRequestValidator,
        IValidator<ProductUpdateRequest> productUpdateRequestValidator,
        IMapper mapper, 
        IProductsRepository productsRepository)
    {
        _productAddRequestValidator = productAddRequestValidator;
        _productUpdateRequestValidator = productUpdateRequestValidator;
        _mapper = mapper;
        _productsRepository = productsRepository;
    }

    public async Task<List<ProductResponse?>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponse?> AddProduct(ProductAddRequest ProductAddRequest)
    {
        if(ProductAddRequest is null) throw new ArgumentNullException(nameof(ProductAddRequest));

        // validate the request using FluentValidation
        ValidationResult validationResult = await _productAddRequestValidator.ValidateAsync(ProductAddRequest);

        // check if the request is valid
        if (!validationResult.IsValid)
        {  
            string errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage)); //Error1,Error2,Error3,...
            throw new ArgumentException(errors);
        }

        //Attempt to add the product to the database

        // map the ProductAddRequest to Product

        Product productInput = _mapper.Map<Product>(ProductAddRequest);

        // add the product to the database
        Product? addedProduct = await _productsRepository.AddProduct(productInput);

        if (addedProduct is null) return null;

        // map the added product to ProductResponse
        ProductResponse addProductResponse = _mapper.Map<ProductResponse>(addedProduct);

        return addProductResponse;

    }

    public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest ProductUpdateRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteProduct(Guid ProductID)
    {
        throw new NotImplementedException();
    }
}
