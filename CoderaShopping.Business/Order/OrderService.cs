using System;
using System.Collections.Generic;
using System.Linq;
using CoderaShopping.Business.Mappers;
using CoderaShopping.Business.Models;
using CoderaShopping.DataNHibernate;
using CoderaShopping.DataNHibernate.Repositories;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Services
{
    public interface IOrderService  
    {
        IList<OrderViewModel> GetAll();
        IList<OrderViewModel> GetOrdersOnPage(int page,int items);
        IList<OrderViewModel> GetAllForUser(Guid userId);
        OrderViewModel GetById(Guid orderId);
        void Add(OrderViewModel order);
        void Update(OrderViewModel order);
        void Delete(OrderViewModel order);
        int Count();

    }
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public IList<OrderViewModel> GetOrdersOnPage(int page,int items)
        {
            var skip = (page-1) * items;
            var test = _orderRepository.GetAll().Skip(skip).Take(items);
            var data= _orderRepository.GetAll().Skip(skip).Take(items).Select(x => x.MapToViewModel()).ToList();
            return data;
        }
        public IList<OrderViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();
           
            var products = _orderRepository.GetAll().Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();
            return products;
        }

        public IList<OrderViewModel> GetAllForUser(Guid userId)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(userId);
            var products = user.Orders.Select(x => x.MapToViewModel()).ToList();

            _unitOfWork.Commit();

            return products;
        }

        public OrderViewModel GetById(Guid orderId)
        {
            _unitOfWork.BeginTransaction();
            var order = _orderRepository.GetById(orderId).MapToViewModel();
            if (order == null)
            {
                throw new Exception("ORDER NOT FOUND");
            }
            _unitOfWork.Commit();
            return order;
        }

        public void Add(OrderViewModel order)
        {
            _unitOfWork.BeginTransaction();

            foreach (var productId in order.Products)
            {
                var product = _productRepository.GetById(productId);
                var user = _userRepository.GetById(order.User.Id);
                var addOrder = new Order(Guid.NewGuid(), order.Quantity, user, product);
                _orderRepository.Add(addOrder);
            }
            
            _unitOfWork.Commit();
        }

        public void Update(OrderViewModel order)
        {
            _unitOfWork.BeginTransaction();
            var product = _productRepository.GetById(order.Products[0]);
            var user = _userRepository.GetById(order.User.Id);
            IList<Product> products=new List<Product>();
            var updateOrder = new Order(order.Id, order.Quantity, user,product);
            _orderRepository.Update(updateOrder);
            _unitOfWork.Commit();
        }

        public void Delete(OrderViewModel order)
        {
            _unitOfWork.BeginTransaction();
            var product = _productRepository.GetById(order.Products[0]);
            var user = _userRepository.GetById(order.User.Id);
            IList<Product> products = new List<Product>();
            var deleteOrder = new Order(order.Id, order.Quantity, user,product);
            _orderRepository.Delete(deleteOrder);
            _unitOfWork.Commit();
        }

        public int Count()
        {
            _unitOfWork.BeginTransaction();
            var count=_orderRepository.GetAll().Count();
            _unitOfWork.Commit();
            return count;
        }
    }
}
