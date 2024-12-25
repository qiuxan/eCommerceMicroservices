namespace eCommerce.BusinessLogicLayer.DTO;

public record ProductUpdateRequest(Guid ProductID, string ProductName, CategoryOptions Category, double? UnitPrice, int? QuantityInstock)
{
    public ProductUpdateRequest() : this(default,default, default, default, default)
    {

    }
}