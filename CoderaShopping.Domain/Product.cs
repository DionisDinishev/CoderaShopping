using System;
using System.Collections.Generic;

namespace CoderaShopping.Domain
{
    public class Product
    {
        private Guid _id;
        private string _name;
        private string _description;
        private Category _category;
        private Order _order;
        private IList<Order> _orders;

        public Product()
        {
            _orders = new List<Order>();
        }

        public Product(Guid id, string name, string description, Category category)
        {
            _id = id;
            _name = name;
            _description = description;
            _category = category;
            _orders = new List<Order>();
        }

        public virtual Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public virtual Category Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public virtual IList<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        public virtual Order Order
        {
            get { return _order; }
            set { _order = value; }
        }
    }
}
