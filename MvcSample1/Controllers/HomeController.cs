using MvcSample.Infra.Repository;
using MvcSample.Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MvcSample.Controllers
{
    [Authorize]
    public class HomeController : Base.BaseController
    {
        IUserRepository userRepository;

        public HomeController()
        {
            userRepository = new UserRepository();
        }

        public HomeController(IUserRepository repository)
        {
            this.userRepository = repository;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var userId = WebSecurity.CurrentUserId;
            var user = userRepository.GetById(userId);
            return PartialView("~/Views/Partial/_LoggedUserMenu.cshtml", user);
        }
    }
}
