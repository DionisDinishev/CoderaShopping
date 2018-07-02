using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CoderaShopping.Business.Models;
using CoderaShopping.Business.Services;

namespace CoderaShopping.Controllers.Api
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult GetAll()
        {
            return Json(_categoryService.GetAll(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(Guid id)
        {
            if (ModelState.IsValid)
            {
                return Json(_categoryService.GetById(id), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return ValidationResult();
            }
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult();
            }
            else
            {
                _categoryService.Add(category);
                return Json("Yeah");
            }
        }

        [HttpPost]
        public ActionResult Update(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                return Json("Yeah");

            }
            else
            {
                return ValidationResult();
            }
        }
        [HttpPost]
        public void Delete(CategoryViewModel category)
        {
            _categoryService.Delete(category);
        }

        public ActionResult OrderByName(bool ascendingOrder)
        {
            return Json(_categoryService.OrderByName(ascendingOrder), JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderByStatus(bool ascendingOrder)
        {
            return Json(_categoryService.OrderByStatus(ascendingOrder), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchByCategoryName(string categoryName)
        {
            return Json(_categoryService.SearchByName(categoryName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoriesCount()
        {
            return Json(_categoryService.GetCategoriesCount(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoriesOnPage(int page,int size)
        {

            return Json(_categoryService.GetCategoriesOnPage(page,size), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidationResult()
        {
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            var error = new
            {
                hasError = true,
                errorMessage = ModelState.Values.Where(x => x.Errors.Any())
                    .Select(x => x.Errors.Select(y => y.ErrorMessage))
            };
            return Json(error);
        }

    }
}