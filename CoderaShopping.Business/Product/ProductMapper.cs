using CoderaShopping.Business.Models;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel MapToViewModel(this Product product)
        {

            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = new LookupViewModel
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };
        }
    }
}
