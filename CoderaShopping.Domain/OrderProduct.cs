using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderaShopping.Domain
{
    public class OrderProduct
    {
        private Guid _id;
        private Product _product;
        private Order _order;
        private int _quantity;
        private IList<Product> _products;

        public OrderProduct()
        {
            _products = new List<Product>();
        }

        public OrderProduct(Guid id, Product product, Order order, int quantity)
        {
            _id = id;
            _product = product;
            _order = order;
            _quantity = quantity;
            _products = new List<Product>();
        }

        public virtual Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public virtual Product Product
        {
            get { return _product; }
            set { _product= value; }
        }
        public virtual Order Order
        {
            get { return _order; }
            set { _order = value; }
        }
        public virtual IList<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
    }
}
