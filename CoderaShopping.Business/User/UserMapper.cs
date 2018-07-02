using CoderaShopping.Business.Models;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel MapToViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                UserType = user.UserType.ToString(),
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}
