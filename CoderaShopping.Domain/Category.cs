using System;
using System.Collections.Generic;

namespace CoderaShopping.Domain
{
    public class Category
    {
        private Guid _id;
        private string _name;
        private bool _status;
        private bool _isDefault;
        private IList<Product> _products;
        protected Category()
        {
            _products=new List<Product>();
        }

        public Category(Guid id, string name, bool status, bool isDefault)
        {
            _id = id;
            _name = name;
            _status = status;
            _isDefault = isDefault;
            _products = new List<Product>();
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

        public virtual bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public virtual bool IsDefault
        {
            get { return _isDefault;}
            set { _isDefault = value; }
        }
        public virtual IList<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
    }
}
