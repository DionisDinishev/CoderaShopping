using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoderaShopping.Domain;

namespace CoderaShopping.DataNHibernate.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {

    }
    public class ProductRepository:RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
