using MvcSample.Filters;
using MvcSample.Infra.Data;
using MvcSample.Infra.Repository;
using MvcSample.Infra.Repository.Interfaces;
using MvcSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace MvcSample.Controllers
{
    [Authorize(Roles="Administrator")]
    public class UserController : Base.BaseController
    {
        IUserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        public UserController(IUserRepository repository)
        {
            this.userRepository = repository;
        }

            
        public ActionResult Index()
        {
            IEnumerable<User> result = userRepository.GetAll();
            return View(result);
        }

        [LogAction]
        public ActionResult Edit(int id)
        {
            User user = userRepository.GetById(id);
            
            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        [LogAction]
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
                return Edit(model.Id);


            this.userRepository.Update(model);
            Roles.RemoveUserFromRoles(model.UserName, Roles.GetRolesForUser());
            Roles.AddUserToRole(model.UserName, model.Perfil);

            ViewBag.Success = "Operacao Realizada com Sucesso";

            IEnumerable<User> result 
                = this.userRepository.GetAll();

            return View("Index", result);
        }

        [HttpDelete]

        public ActionResult Delete(int id)
        {
            User user = userRepository.GetById(id);

            if (user == null)
                return HttpNotFound();
            
            this.userRepository.Delete(user);

            return Json("OK");

        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(User model)
        {
            if (!ModelState.IsValid)
                return New();

            try
            {

                this.userRepository.Insert(model);
                Roles.RemoveUserFromRoles(model.UserName, Roles.GetRolesForUser());
                Roles.AddUserToRole(model.UserName, model.Perfil);
                ViewBag.Success = "Operacao Realizada com Sucesso";
                IEnumerable<User> result  = this.userRepository.GetAll();
                return View("Index", result);
              
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return New();

        }

       



    }
}
