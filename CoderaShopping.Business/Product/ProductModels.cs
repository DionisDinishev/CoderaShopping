using CoderaShopping.Domain;
using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace CoderaShopping.Business.Models
{
    [Validator(typeof(ProductViewModelValidator))]
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LookupViewModel Category { get; set; }

    }

    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .Length(4, 50).WithMessage("Name should be at least 4 letters");

        

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Category should not be empty");
        }
    }
}
