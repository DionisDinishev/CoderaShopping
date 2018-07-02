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
    public interface IProductService
    {
        //CRUD
        ProductViewModel GetById(Guid id);
        IList<ProductViewModel> GetAll();
        void Add(ProductViewModel product);
        void Update(ProductViewModel product);
        void Delete(ProductViewModel product);
        //Search
        List<ProductViewModel> SearchByName(string name);
        List<ProductViewModel> SearchByDescription(string description);
        List<ProductViewModel> SearchByCategory(string category);
        //Order
        List<ProductViewModel> OrderhByName(bool acsending);
        List<ProductViewModel> OrderByDescription(bool acsending);
        List<ProductViewModel> OrderByCategory(bool acsending);
        //Count
        int GetProductsCount();
        List<ProductViewModel> GetProductsOnPage(int page, int size);


    }
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public ProductViewModel GetById(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var product = _productRepository.GetById(id);
            var viewModel = product.MapToViewModel();
            if (viewModel == null)
            {
                throw new Exception("PRODUCT NOT FOUND");
            }
            _unitOfWork.Commit();

            return viewModel;
        }

        public IList<ProductViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            var products = _productRepository.GetAll().Select(x => x.MapToViewModel()).ToList();


            _unitOfWork.Commit();
            return products;
       }

        public void Add(ProductViewModel product)
        {
            _unitOfWork.BeginTransaction();
            if (product?.Category?.Id == null)
            {
                throw new Exception("CATEGORY CANNOT BE EMPTY");
            }
            var category = _categoryRepository.GetById(product.Category.Id);

            var addProduct = new Product(new Guid(), product.Name, product.Description,category);
           
            _productRepository.Add(addProduct);


            _unitOfWork.Commit();
        }

        public void Update(ProductViewModel product)
        {
            _unitOfWork.BeginTransaction();

            var category = _categoryRepository.GetById(product.Category.Id);

            var updateProduct = new Product(product.Id, product.Name, product.Description, category);
            _productRepository.Update(updateProduct);


            _unitOfWork.Commit();
        }

        public void Delete(ProductViewModel product)
        {
            _unitOfWork.BeginTransaction();
            var category = _categoryRepository.GetById(product.Category.Id);

            var deleteProduct = new Product(product.Id, product.Name, product.Description, category);
            _productRepository.Delete(deleteProduct);


            _unitOfWork.Commit();
        }

        public List<ProductViewModel> SearchByName(string name)
        {
            _unitOfWork.BeginTransaction();
            var result= _productRepository.GetAll().Where(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => x.MapToViewModel()).ToList();
            _unitOfWork.Commit();
            return result;
        }

        public List<ProductViewModel> SearchByDescription(string description)
        {
            _unitOfWork.BeginTransaction();
            var result = _productRepository.GetAll().Select(x => x.MapToViewModel()).Where(x => x.Description.Contains(description)).ToList();
            _unitOfWork.Commit();
            return result;
        }

        public List<ProductViewModel> SearchByCategory(string category)
        {
            _unitOfWork.BeginTransaction();
            var result= _productRepository.GetAll().Select(x => x.MapToViewModel()).Where(x => _categoryRepository.GetById(x.Category.Id).Name.Contains(category)).ToList();
            _unitOfWork.Commit();
            return result;
        }

        public List<ProductViewModel> OrderhByName(bool acsending)
        {
            _unitOfWork.BeginTransaction();
            var result= _productRepository.GetAll().OrderBy(x => x.Name).Select(x => x.MapToViewModel()).ToList();
            if (!acsending)
                result.Reverse();
            _unitOfWork.Commit();
            return result;
        }

        public List<ProductViewModel> OrderByDescription(bool acsending)
        {
            _unitOfWork.BeginTransaction();
            var result = _productRepository.GetAll().OrderBy(x => x.Description).Select(x => x.MapToViewModel()).ToList();
            if (!acsending)
                result.Reverse();
            _unitOfWork.Commit();
            return result;

        }

        public List<ProductViewModel> OrderByCategory(bool acsending)
        {
            _unitOfWork.BeginTransaction();
            var result = _productRepository.GetAll().OrderBy(x=>x.Category.Name).Select(x => x.MapToViewModel()).ToList();
            if (!acsending)
                result.Reverse();
            _unitOfWork.Commit();
            return result;

        }

        public int GetProductsCount()
        {
            _unitOfWork.BeginTransaction();
            var result = _productRepository.GetAll().Count();
            _unitOfWork.Commit();
            return result;
        }

        public List<ProductViewModel> GetProductsOnPage(int page, int size)
        {
            _unitOfWork.BeginTransaction();
            var result = _productRepository.GetAll().Skip((page - 1) * size).Take(size).Select(x=>x.MapToViewModel()).ToList();
            _unitOfWork.Commit();
            return result;

        }
    }
}
