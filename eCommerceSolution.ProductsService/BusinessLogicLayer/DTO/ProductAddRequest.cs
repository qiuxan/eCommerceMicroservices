namespace eCommerce.BusinessLogicLayer.DTO;

public record ProductAddRequest(string ProductName, CategoryOptions Category, double? UnitPrice, int? QuantityInstock)
{
    public ProductAddRequest():this(default, default,default,default)
    {
        
    }
}
