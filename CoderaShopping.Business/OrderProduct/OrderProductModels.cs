using System;
using System.Collections.Generic;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Models
{
    public class OrderProductViewModel
    {
        public Guid Id { get; set; }
        public OrderViewModel Order { get; set; }
        public ProductViewModel Product { get; set; }
        public IList<ProductViewModel> Products { get; set; }
        public int Quantity { get; set; }
    }
}
