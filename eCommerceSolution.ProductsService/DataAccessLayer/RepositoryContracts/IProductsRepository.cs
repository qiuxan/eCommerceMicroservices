using System.Linq.Expressions;
using eCommerce.DataAccessLayer.Entities;

namespace eCommerce.DataAccessLayer.RepositoryContracts;
/// <summary>
/// Represents a repository for managing products table in the database
/// </summary>
public interface IProductsRepository
{
    /// <summary>
    /// retrieves all products asynchronously
    /// </summary>
    /// <returns> returns all products from the table</returns>
    Task<IEnumerable<Product>> GetProducts();

    /// <summary>
    /// retrieves all products asynchronously based on specified condition.
    /// </summary>
    /// <param name="conditionExpression">The condition to filter the products in linq</param>
    /// <returns>Return a collection of matching products</returns>
    Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product,bool>> conditionExpression);

    /// <summary>
    /// retrieves a single asynchronously based on specified condition.
    /// </summary>
    /// <param name="conditionExpression">The condition to filter the product in linq</param>
    /// <returns>Return a matching product or null</returns>
    Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);


    /// <summary>
    /// add a product to the database asynchronously
    /// </summary>
    /// <param name="product">the product to be added</param>
    /// <returns>returns the added product object or null if unsuccessful</returns>
    Task<Product?> AddProduct(Product product);


    /// <summary>
    /// update a product to the database asynchronously
    /// </summary>
    /// <param name="product">the product to be updated</param>
    /// <returns>returns the updated product object or null if unsuccessful</returns>
    Task<Product?> UpdateProduct(Product product);

    /// <summary>
    /// delete a product from the database asynchronously
    /// </summary>
    /// <param name="productID">The product ID to be deleted</param>
    /// <returns>Returns true if the deletion is successful, false otherwise</returns>
    Task<bool> DeleteProduct(Guid productID);
}
