using System.Linq.Expressions;
using eCommerce.DataAccessLayer.Entities;
using eCommerce.BusinessLogicLayer.DTO;

namespace eCommerce.BusinessLogicLayer.ServiceContracts;
public interface IProductService
{
    /// <summary>
    /// Retrieves a list of products from the product repository.
    /// </summary>
    /// <returns>Returns a list of ProductResponse objects</returns>
    Task<List<ProductResponse?>> GetProducts();

    /// <summary>
    /// Retrieves a list of products matching the condition
    /// </summary>
    /// <param name="conditionExpression">Expression that represents condition to check</param>
    /// <returns>Returns matching products</returns>
    Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);

    /// <summary>
    /// Retrieves a products matching the condition
    /// </summary>
    /// <param name="conditionExpression">Expression that represents condition to check</param>
    /// <returns>Returns matching product or null</returns>
    Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);
    /// <summary>
    /// Adds a product to the table using product repository
    /// </summary>
    /// <param name="ProductAddRequest">Product to insert</param>
    /// <returns>Product after inserting or null if unsuccessful</returns>
    Task<ProductResponse?> AddProduct(ProductAddRequest ProductAddRequest);
    /// <summary>
    /// Updates an existing product in the table using product repository
    /// </summary>
    /// <param name="ProductUpdateRequest">Product updated</param>
    /// <returns>Returns Product updated after successful updating; otherwise null</returns>
    Task<ProductResponse?> UpdateProduct(ProductUpdateRequest ProductUpdateRequest);
    /// <summary>
    /// Delete an existing product in the table using product repository on given productID
    /// </summary>
    /// <param name="ProductID">Product ID to search and delete</param>
    /// <returns>Return trun if the deletion is successful; otherwise false</returns>
    Task<bool> DeleteProduct(Guid ProductID);
}
