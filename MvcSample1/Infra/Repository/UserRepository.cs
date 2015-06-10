using MvcSample.Infra.Data;
using MvcSample.Infra.Repository.Interfaces;
using MvcSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

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

        public void ChangeState(User user, EntityState state)
        {
            ((IObjectContextAdapter)this.context)
                           .ObjectContext
                           .ObjectStateManager
                           .ChangeObjectState(user,
                           state);
        }



        public void Insert(User obj)
        {
            context.Users.Attach(obj);
            this.ChangeState(obj, EntityState.Added);
            this.context.SaveChanges();
        }

        public void Delete(User obj)
        {
            this.context.Users.Remove(obj);
            this.ChangeState(obj, EntityState.Deleted);
            this.context.SaveChanges();
        }
    }
}