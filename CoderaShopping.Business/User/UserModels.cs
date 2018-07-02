using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CoderaShopping.Domain;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;

namespace CoderaShopping.Business.Models
{
    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }


    }

    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .Length(4, 50).WithMessage("Name should be between 4 and 50 characters");

            RuleFor(x=>x.Name).Must(name=>{
                foreach (var c in name)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        return false;
                    }
                }

                return true;
            }).When(x=>x.Name!=null).WithMessage("Name should only contains letters and numbers");

            RuleFor(x => x.UserType)
                .NotEmpty().WithMessage("UserType must be Internal or External")
                .NotEqual("Undefined").WithMessage("UserType must be Internal or External");

            RuleFor(x => x.Name)
                .EmailAddress().WithMessage("Email is not in valid format");

        }

        private bool ValidateUserName(string user)
        {
            foreach (var c in user)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
