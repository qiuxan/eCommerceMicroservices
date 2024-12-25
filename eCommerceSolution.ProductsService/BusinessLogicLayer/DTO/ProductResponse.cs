namespace eCommerce.BusinessLogicLayer.DTO;

public record ProductResponse(Guid ProductID, string ProductName, CategoryOptions Category, double? UnitPrice, int? QuantityInstock)
{
    public ProductResponse() : this(default, default, default, default, default)
    {

    }
}