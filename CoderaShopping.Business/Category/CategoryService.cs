using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoderaShopping.Business.Mappers;
using CoderaShopping.Business.Models;
using CoderaShopping.DataNHibernate;
using CoderaShopping.DataNHibernate.Repositories;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Services
{

    public interface ICategoryService
    {
        //CRUD
        CategoryViewModel GetById(Guid id);
        IList<CategoryViewModel> GetAll();
        void Add(CategoryViewModel category);
        void Update(CategoryViewModel category);
        void Delete(CategoryViewModel category);
        //Search
        List<CategoryViewModel> SearchByName(string name);
        List<CategoryViewModel> SearchByStatus(bool status);
        //Order

        List<CategoryViewModel> OrderByName(bool ascendingOrder);
        List<CategoryViewModel> OrderByStatus(bool ascendingOrder);
        int GetCategoriesCount();
        List<CategoryViewModel> GetCategoriesOnPage(int page, int size);
    }
    class CategoryService:ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public CategoryViewModel GetById(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var category = _categoryRepository.GetById(id);

            if (category == null)
            {
                throw new Exception("CATEGORY NOT FOUND");
            }

            _unitOfWork.Commit();

            return category.MapToViewModel();
        }

        public IList<CategoryViewModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            var category = _categoryRepository.GetAll().OrderByDescending(x=>x.IsDefault).Select(x => x.MapToViewModel()).ToList();
            _unitOfWork.Commit();

            return category;
        }

        public void Add(CategoryViewModel category)
        {
            _unitOfWork.BeginTransaction();

            var addCategory = new Category(Guid.NewGuid(), category.Name,category.Status,category.IsDefault);

            var list = _categoryRepository.GetAll().OrderByDescending(x=>x.IsDefault).ToList();

            if (category.IsDefault)
            {
                foreach (var c in _categoryRepository.GetAll())
                {
                    c.IsDefault = false;
                }
            }

            _categoryRepository.Add(addCategory);
            _unitOfWork.Commit();
        }

        public void Update(CategoryViewModel category)
        {
            _unitOfWork.BeginTransaction();
            var updateCategory = new Category(category.Id, category.Name, category.Status,category.IsDefault);
            _categoryRepository.Update(updateCategory);
            _unitOfWork.Commit();
        }

        public void Delete(CategoryViewModel category)
        {
            _unitOfWork.BeginTransaction();
            var deleteCategory = _categoryRepository.GetById(category.Id);
            if (deleteCategory.IsDefault)
            {
                _categoryRepository.GetAll().FirstOrDefault().MapToViewModel().IsDefault = true;
            }
            _categoryRepository.Delete(deleteCategory);
            _unitOfWork.Commit();
        }

        public List<CategoryViewModel> SearchByName(string name)
        {
            _unitOfWork.BeginTransaction();
            var result= _categoryRepository.GetAll().Where(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => x.MapToViewModel())
                .ToList();
            _unitOfWork.Commit();
            return result;
        }

        public List<CategoryViewModel> SearchByStatus(bool status)
        {
            _unitOfWork.BeginTransaction();
            var result =_categoryRepository.GetAll().Where(x => x.Status==status).Select(x => x.MapToViewModel())
                .ToList();
            _unitOfWork.Commit();
            return result;
        }

        public List<CategoryViewModel> OrderByName(bool ascendingOrder)
        {

            _unitOfWork.BeginTransaction();
            var result = _categoryRepository.GetAll().OrderBy(x => x.Name).Select(x => x.MapToViewModel()).ToList();
            if (!ascendingOrder)
                result.Reverse();
            _unitOfWork.Commit();
            return result;

        }

        public List<CategoryViewModel> OrderByStatus(bool ascendingOrder)
        {
            _unitOfWork.BeginTransaction();
            var result = _categoryRepository.GetAll().OrderBy(x => x.Status).Select(x => x.MapToViewModel()).ToList();
            if (!ascendingOrder)
                result.Reverse();
            _unitOfWork.Commit();
            return result;

        }

        public int GetCategoriesCount()
        {
            _unitOfWork.BeginTransaction();
            var result = _categoryRepository.GetAll().Count();
            _unitOfWork.Commit();
            return result;
        }

        public List<CategoryViewModel> GetCategoriesOnPage(int page, int size)
        {

            _unitOfWork.BeginTransaction();
            var result = _categoryRepository.GetAll().Skip((page - 1) * size).Take(size).Select(x => x.MapToViewModel())
                .ToList();
            _unitOfWork.Commit();
            return result;
        }
    }
}
