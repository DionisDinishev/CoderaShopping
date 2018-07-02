using System;
using System.Web.Mvc;
using CoderaShopping.Business.Models;
using CoderaShopping.Business.Services;

namespace CoderaShopping.Controllers.Api
{
    public class OrderProductsController : Controller
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductsController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }
        // GET: OrderProducts
        public ActionResult GetAll()
        {
            return Json(_orderProductService.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllProductsForOrder(Guid id)
        {
            return Json(_orderProductService.GetAllProductsForOrder(id),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(OrderProductViewModel orderProduct)
        {
            _orderProductService.Add(orderProduct);
            return Json("YEAH");
        }

        public ActionResult GetAllOrders()
        {
            return Json(_orderProductService.GetAllOrders(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GenerateGuid()
        {
            var guid = Guid.NewGuid();
            return Json(guid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchByProduct(string product)
        {
            return Json(_orderProductService.SearchByProduct(product), JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderByUserName(bool ascendingOrder)
        {
            return Json(_orderProductService.OrderByUserName(ascendingOrder), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchOrderByUserName(string userName)
        {
            return Json(_orderProductService.SearchByUserName(userName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrdersCount()
        {
            return Json(_orderProductService.GetOrdersCount(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrdersOnPage(int page, int size)
        {
            return Json(_orderProductService.GetOrdersOnPage(page, size), JsonRequestBehavior.AllowGet);
        }
    }
}