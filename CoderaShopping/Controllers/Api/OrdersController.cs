using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoderaShopping.Business.Models;
using CoderaShopping.Business.Services;

namespace CoderaShopping.Controllers.Api
{
    public class OrdersController : Controller
    {

        private readonly IOrderService _orderService;
        // GET: Orders
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public int Count()
        {
            return _orderService.Count();
        }
        public ActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(Guid id)
        {
            var order = _orderService.GetById(id);
            return Json(order, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrderOnPage(int page,int items)
        {
            var pageData=_orderService.GetOrdersOnPage(page,items);
            return Json(pageData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(OrderViewModel order)
        {
            var orderId = Guid.NewGuid();
            /*foreach (var p in products)
            {
                var orderTest = new OrderViewModel()
                {
                    Id = orderId,
                    User = new UserViewModel()
                    {
                        Id = Guid.Parse("AFBB4C3F-F4F2-4AE5-A8D5-15CE72F09C9E")
                    },
                    Product = new ProductViewModel()
                    {
                        Id = p.Id
                    }
                    
                
                };
                _orderService.Add(orderTest);
            }*/
           


           /* if (!ModelState.IsValid)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(ModelState.Values.Where(x => x.Errors.Any()).Select(x => x.Errors.Select(y => y.ErrorMessage)));
            }*/

            _orderService.Add(order);
            return Json(true);
        }

        [HttpPost]
        public void Update(OrderViewModel order)
        {
            _orderService.Update(order);
        }
        [HttpPost]
        public void Delete(OrderViewModel order)
        {
            _orderService.Delete(order);
        }
    }
}