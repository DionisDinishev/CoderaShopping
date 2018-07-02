using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CoderaShopping.Business.Models;
using CoderaShopping.Business.Services;

namespace CoderaShopping.Controllers.Api
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            return Json(user,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                return Json("Yeah");
            }
            return ValidationResult();
        }
        [HttpPost]
        public void UpdateUser(UserViewModel user)
        {

            _userService.Update(user);
        }

        [HttpPost]
        public void DeleteUser(UserViewModel user)
        {
            _userService.Delete(user);
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

        public ActionResult OrderByName(bool ascendingOrder)
        {
            return Json(_userService.OrderByName(ascendingOrder), JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderByEmail(bool ascendingOrder)
        {
            return Json(_userService.OrderByEmail(ascendingOrder), JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderByPhone(bool ascendingOrder)
        {
            return Json(_userService.OrderByPhone(ascendingOrder), JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderByUserType(bool ascendingOrder)
        {
            return Json(_userService.OrderByUserType(ascendingOrder), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchByUserName(string userName)
        {
            return Json(_userService.SearchByName(userName),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersOnPage(int page, int size)
        {
            return Json(_userService.GetUsersOnPage(page, size), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersCount()
        {
            return Json(_userService.GetUsersCount(), JsonRequestBehavior.AllowGet);
        }
    }
}