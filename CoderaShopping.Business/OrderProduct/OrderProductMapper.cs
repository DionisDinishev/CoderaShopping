using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoderaShopping.Business.Models;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Mappers
{
    public static class OrderProductMapper 
    {
        public static OrderProductViewModel MapToViewModel(this OrderProduct orderProduct)
        {
            return new OrderProductViewModel
            {
                Id = orderProduct.Id,
                Order = orderProduct.Order.MapToViewModel(),
                Product = orderProduct.Product.MapToViewModel(),
                Products = orderProduct.Products.Select(x=>x.MapToViewModel()).ToList(),
                Quantity = orderProduct.Quantity
            };
        }
    }
}
