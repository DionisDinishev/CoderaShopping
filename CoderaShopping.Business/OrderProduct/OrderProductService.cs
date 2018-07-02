using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CoderaShopping.Business.Mappers;
using CoderaShopping.Business.Models;
using CoderaShopping.DataNHibernate;
using CoderaShopping.DataNHibernate.Repositories;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Services
{
    public interface IOrderProductService
    {
        //CRUD
        IList<IList<ProductViewModel>> GetAll();
        IList<OrderProductViewModel> GetAllOrders();
        void Add(OrderProductViewModel orderProduct);
        IList<ProductViewModel> GetAllProductsForOrder(Guid orderId);
        //Search
        List<OrderProductViewModel> SearchByUserName(string user);
        List<OrderProductViewModel> SearchByProduct(string product);
        //Order
        List<OrderProductViewModel> OrderByUserName(bool ascendingOrder);
        List<OrderProductViewModel> OrderByProductCount(bool ascendingOrder);


        int GetOrdersCount();
        List<OrderProductViewModel> GetOrdersOnPage(int page, int size);
    }
    public class OrderProductService:IOrderProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderProductRepositry _orderProductRepository;
        private readonly IOrderRepository _orderRepositry;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
       

        public OrderProductService(IUnitOfWork unitOfWork, IOrderProductRepositry orderProductRepository, IOrderRepository orderRepositry, IProductRepository productRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _orderProductRepository = orderProductRepository;
            _orderRepositry = orderRepositry;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public IList<OrderProductViewModel> GetAllOrders()
        {
            _unitOfWork.BeginTransaction();
            var result = new List<OrderProductViewModel>();
            var orderIds = _orderProductRepository.GetAll().Select(x => x.Order.Id).Distinct().ToList();
            var orderProducts = orderIds
                .Select(GetAllProductsForOrder)
                .ToList();
            
            var i = 0;
            foreach (var orderId in orderIds)
            {
                result.Add(new OrderProductViewModel()
                {
                    Order = _orderRepositry.GetById(orderId).MapToViewModel(),
                    Products = orderProducts[i++],
                    Quantity = _orderRepositry.GetById(orderId).MapToViewModel().Quantity
                });
            }
            _unitOfWork.Commit();
            return result;
        }

        public void Add(OrderProductViewModel orderProduct)
        {
            _unitOfWork.BeginTransaction();
            var user = _userRepository.GetById(orderProduct.Order.User.Id);
           
           
            var productIds = orderProduct.Products.Select(x => x.Id);

            var products = productIds.Select(productId => _productRepository.GetById(productId)).ToList();
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                User = user,
                Quantity = orderProduct.Order.Quantity,
                Product = null,
                Products = products
            };
            _orderRepositry.Add(order);

            foreach (var product in products)
            {

                var orderProductModel = new OrderProduct
                {
                    Id = Guid.NewGuid(),
                    Order = order,
                    Product = product,
                    Products = products,
                    Quantity = orderProduct.Quantity
                };
                _orderProductRepository.Add(orderProductModel);
            }

            _unitOfWork.Commit();
        }
        public IList<IList<ProductViewModel>> GetAll()
        {
            _unitOfWork.BeginTransaction();
            var orderIds = _orderProductRepository.GetAll().Select(x => x.Order.Id).Distinct().ToList();
            var orderProducts = orderIds
                    .Select(GetAllProductsForOrder)
                    .ToList();
            _unitOfWork.Commit();
            return orderProducts;
        }
        public IList<ProductViewModel> GetAllProductsForOrder(Guid orderId)
        {
            var products = _orderProductRepository.GetAll().Where(x => x.Order.Id == orderId)
                .Select(y => _productRepository.GetById(y.Product.Id).MapToViewModel()).ToList();


            return products;
        }

        public List<OrderProductViewModel> SearchByUserName(string user)
        {
            _unitOfWork.BeginTransaction();
            var result = GetAllOrders().Where(x => x.Order.User.Name.ToLower().Contains(user.ToLower())).Select(x => x).ToList();
          
            _unitOfWork.Commit();
            return result;
        }

        public List<OrderProductViewModel> SearchByProduct(string product)
        {

            _unitOfWork.BeginTransaction();
            var filteredListByProductName = _orderProductRepository.GetAll().Where(x=>x.Product.Name.Contains(product)).Select(x=>x.MapToViewModel()).ToList();

            _unitOfWork.Commit();
            return filteredListByProductName;

        }

        public List<OrderProductViewModel> OrderByUserName(bool ascendingOrder)
        {
            _unitOfWork.BeginTransaction();
            var orderdByUserName = _orderProductRepository.GetAll().OrderBy(x => x.Order.User.Name).Select(x=>x.MapToViewModel()).ToList();
            _unitOfWork.Commit();
            if (!ascendingOrder)
                orderdByUserName.Reverse();

            return orderdByUserName;
        }

        public List<OrderProductViewModel> OrderByProductCount(bool ascendingOrder)
        {
            _unitOfWork.BeginTransaction();
            var orderdByOrderCount = _orderProductRepository.GetAll().OrderBy(x => x.Products.Count).Select(x=>x.MapToViewModel()).ToList();
            _unitOfWork.Commit();
            if (!ascendingOrder)
                orderdByOrderCount.Reverse();

            return orderdByOrderCount;
        }

        public int GetOrdersCount()
        {
            _unitOfWork.BeginTransaction();
            var result = GetAllOrders().Count;
            _unitOfWork.Commit();

            return result;
        }

        public List<OrderProductViewModel> GetOrdersOnPage(int page, int size)
        {
            _unitOfWork.BeginTransaction();
            var result = GetAllOrders().Skip((page - 1) * size).Take(size).Select(x => x).ToList();
            _unitOfWork.Commit();
            return result;
        }
    }
}
