using System;
using System.Linq;
using CoderaShopping.Domain;

namespace CoderaShopping.DataNHibernate.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        bool IsEmpty(Guid categoryId);
    }
    public class CategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public bool IsEmpty(Guid categoryId)
        {
            return !(Session.Query<Category>().FirstOrDefault(x => x.Id == categoryId)?.Products.Any() ?? false);
            //return !Session.Query<Product>().Any(x => x.Category.Id == categoryId);
        }
    }
}
