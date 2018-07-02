using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CoderaShopping.Business.Models;
using CoderaShopping.Business.Services;

namespace CoderaShopping.Controllers.Api
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Products
        public ActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(Guid id)
        {
            var product = Json(_productService.GetById(id), JsonRequestBehavior.AllowGet);
            return product;
        }
        [HttpPost]
        public ActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return Json("Yeah");
            }

            return ValidationResult();

        }

        [HttpPost]
        public ActionResult Update(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return Json("Yeah");
            }
            else
            {
                return ValidationResult();
            }
        }

        [HttpPost]
        public ActionResult Delete(ProductViewModel product)
        {

            _productService.Delete(product);
            return Json("Yeah");
        }

        public ActionResult OrderByName(bool ascendingOrder)
        {
            return Json(_productService.OrderhByName(ascendingOrder), JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderByDescription(bool ascendingOrder)
        {
            return Json(_productService.OrderByDescription(ascendingOrder), JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderByCategory(bool ascendingOrder)
        {
            return Json(_productService.OrderByCategory(ascendingOrder), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchByProductName(string productName)
        {
            return Json(_productService.SearchByName(productName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductsCount()
        {
            return Json(_productService.GetProductsCount(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductsOnPage(int page, int size)
        {
            return Json(_productService.GetProductsOnPage(page, size), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidationResult()
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
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