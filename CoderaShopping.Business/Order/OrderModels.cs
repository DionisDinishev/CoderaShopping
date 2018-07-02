using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoderaShopping.Domain;
using FluentValidation;
using FluentValidation.Attributes;

namespace CoderaShopping.Business.Models
{
    [Validator(typeof(OrderViewModelValidator))]
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public UserViewModel User { get; set; }
        public IList<Guid> Products { get; set; }
    }

    public class OrderViewModelValidator : AbstractValidator<OrderViewModel>
    {
        public OrderViewModelValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage("GET FCKED, GIVE ME QUANTITY");
        }
    }
}
