using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoderaShopping.Business.Models;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel MapToViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Quantity = order.Quantity,
                User = order.User.MapToViewModel(),
                Products = order.Products.Select(x=>x.Id).ToList()
                
            };
        }
    }
}
