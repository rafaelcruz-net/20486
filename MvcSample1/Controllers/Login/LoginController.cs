using MvcSample.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MvcSample.Controllers.Login
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return Index();

            if (WebSecurity.Login(model.UserName, model.Password, false))
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Username ou senha invalidos");
            return View("Index",model);

        }
        
        public ActionResult SignOut()
        {
            WebSecurity.Logout();
            return Redirect("/Login");
        }

    }
}
