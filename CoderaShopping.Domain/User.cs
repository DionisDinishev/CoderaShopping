using System;
using System.Collections.Generic;

namespace CoderaShopping.Domain
{
    public enum UserType
    {
        Undefined,
        Internal,
        External
    }
    public class User
    {
        private Guid _id;
        private string _name;
        private string _email;
        private string _phone;
        private UserType _userType;
        private IList<Order> _orders;

        protected User()
        {
            _orders=new List<Order>();
        }

        public User(Guid id, string name, string email, string phone, UserType userType)
        {
            _id = id;
            _name = name;
            _email = email;
            _phone = phone;
            _userType = userType;
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

        public virtual IList<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public virtual UserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
        public virtual string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}
