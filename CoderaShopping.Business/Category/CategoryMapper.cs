using CoderaShopping.Business.Models;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryViewModel MapToViewModel(this Category category)
        {
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Status = category.Status,
                IsDefault = category.IsDefault
            };
        }

    }
}
