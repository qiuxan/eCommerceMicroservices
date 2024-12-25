using System.Linq.Expressions;
using DataAccessLayer.Entities;
using eCommerce.DataAccessLayer.Context;
using eCommerce.DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DataAccessLayer.Repositories;
public class ProductsRepository: IProductsRepository
{
    private readonly ApplicationDbContext _DbContext;

    public ProductsRepository(ApplicationDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _DbContext.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        return await _DbContext.Products.Where(conditionExpression).ToListAsync();
    }

    public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        return await _DbContext.Products.FirstOrDefaultAsync(conditionExpression);
    }

    public async Task<Product?> AddProduct(Product product)
    {
        _DbContext.Products.Add(product);
        await _DbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        Product? existingProduct = await _DbContext.Products.FirstOrDefaultAsync(p => p.ProductID == product.ProductID);

        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.ProductName = product.ProductName;
        existingProduct.Category = product.Category;
        existingProduct.UnitPrice = product.UnitPrice;
        existingProduct.QuantityInStock = product.QuantityInStock;

        await _DbContext.SaveChangesAsync();

        return product;
    }

    public async Task<bool> DeleteProduct(Guid productID)
    {
        Product? existintProductroduct = await _DbContext.Products.FirstOrDefaultAsync(p => p.ProductID == productID);
        if (existintProductroduct == null)
        {
            return false;
        }
        _DbContext.Products.Remove(existintProductroduct);

        int rowsAffected = await _DbContext.SaveChangesAsync();

        return rowsAffected>0;
    }
}
