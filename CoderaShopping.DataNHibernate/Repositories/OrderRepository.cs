using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoderaShopping.Domain;

namespace CoderaShopping.DataNHibernate.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {

    }
    public class OrderRepository:RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
