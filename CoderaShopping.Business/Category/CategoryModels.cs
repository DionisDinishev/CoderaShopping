using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace CoderaShopping.Business.Models
{
    [Validator(typeof(CategoryViewModelValidator))]
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsDefault { get; set; }
    }

    public class CategoryViewModelValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be null")
                .Length(4, 50).WithMessage("Name should be betweent 4 and 50 characters");


        }
    }
}
