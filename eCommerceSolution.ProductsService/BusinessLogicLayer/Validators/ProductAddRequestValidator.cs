using eCommerce.BusinessLogicLayer.DTO;
using FluentValidation;

namespace eCommerce.BusinessLogicLayer.Validators;
public class ProductAddRequestValidator:AbstractValidator<ProductAddRequest>
{
    public ProductAddRequestValidator()
    {
        RuleFor(p=>p.ProductName)
            .NotEmpty().WithMessage("Product Name can't be blank");

        RuleFor(p => p.Category)
            .IsInEnum();

        RuleFor(p => p.UnitPrice)
            .InclusiveBetween(0,double.MaxValue).WithMessage($"Unit Price must be between 0 and {double.MaxValue}");

        RuleFor(p => p.QuantityInstock)
            .InclusiveBetween(0, int.MaxValue).WithMessage($"Unit Price must be between 0 and {int.MaxValue}");

    }
}
