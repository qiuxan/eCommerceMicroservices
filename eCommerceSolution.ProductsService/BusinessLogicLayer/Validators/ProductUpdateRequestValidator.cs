using eCommerce.BusinessLogicLayer.DTO;
using FluentValidation;

namespace eCommerce.BusinessLogicLayer.Validators;
public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
{
    public ProductUpdateRequestValidator()
    {
        RuleFor(p => p.ProductID)
            .NotEmpty().WithMessage("Product ID can't be blank");

        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("Product Name can't be blank");

        RuleFor(p => p.Category)
            .IsInEnum();

        RuleFor(p => p.UnitPrice)
            .InclusiveBetween(0, double.MaxValue).WithMessage($"Unit Price must be between 0 and {double.MaxValue}");

        RuleFor(p => p.QuantityInstock)
            .InclusiveBetween(0, int.MaxValue).WithMessage($"Unit Price must be between 0 and {int.MaxValue}");

    }
}