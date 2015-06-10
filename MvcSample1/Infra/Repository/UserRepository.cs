using MvcSample.Infra.Data;
using MvcSample.Infra.Repository.Interfaces;
using MvcSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace MvcSample.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        Context context = new Context();

        public IEnumerable<User> GetAll()
        {
            return (from x in context.Users
                    select x);
        }
        public User GetById(int id)
        {
            return (from x in context.Users
                    where x.Id == id
                    select x).FirstOrDefault();
        }

        public void Update(User user)
        {
            context.Users.Attach(user);
            this.ChangeState(user, EntityState.Modified);
            this.context.SaveChanges();
        }

        public void Insert(User obj)
        {
            WebSecurity.CreateUserAndAccount(obj.UserName, obj.Password, new
            {
                Name = obj.Name,
                Email = obj.Email,
                CreationDate = obj.CreationDate,
                Password = obj.Password
            }, false);
        }

        public void Delete(User obj)
        {
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(obj.UserName);
            this.context.Users.Remove(obj);
            this.ChangeState(obj, EntityState.Deleted);
            this.context.SaveChanges();
        }

        public void ChangeState(User user, EntityState state)
        {
            ((IObjectContextAdapter)this.context)
                           .ObjectContext
                           .ObjectStateManager
                           .ChangeObjectState(user,
                           state);
        }



    
    }
}