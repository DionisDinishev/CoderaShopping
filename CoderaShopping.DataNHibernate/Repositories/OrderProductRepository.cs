using CoderaShopping.Domain;

namespace CoderaShopping.DataNHibernate.Repositories
{
    public interface IOrderProductRepositry : IRepository<OrderProduct>
    {

    }
    public class OrderProductRepository : RepositoryBase<OrderProduct>, IOrderProductRepositry
    {
        public OrderProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

