using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        readonly TodolistMemberProvider membershipProveider = new TodolistMemberProvider();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName, Password")] LoginViewModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                if (this.membershipProveider.ValidateUser(loginInfo.UserName, loginInfo.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginInfo.UserName, false);
                    return RedirectToAction("Index", "Todolists");
                }
            }

            ViewBag.Message = "ログインに失敗しました。";
            return View(loginInfo);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}