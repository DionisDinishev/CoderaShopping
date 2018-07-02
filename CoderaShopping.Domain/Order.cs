using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderaShopping.Domain
{
    public class Order
    {
        private Guid _id;
        private int _quantity;
        private User _user;
        private Product _product;
        private IList<Product> _products;

        public Order()
        {
            _products = new List<Product>();
        }

        public Order(Guid id, int quantity, User user,Product product)
        {
            _id = id;
            _quantity = quantity;
            _user = user;
            _product = product;
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
        
        public virtual IList<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public virtual Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public virtual User User
        {
            get { return _user; }
            set { _user = value; }
        }

    }
}
