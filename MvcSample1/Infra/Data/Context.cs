using MvcSample.Infra.Mapping;
using MvcSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcSample.Infra.Data
{
    public class Context : DbContext
    {
        private const String CONNECTION_NAME = "DefaultConnection";

        public DbSet<User> Users
        {
            get;
            set;
        }


        public Context()
            : base(CONNECTION_NAME)
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());

            this.Database.Log = (message) => {
                Trace.WriteLine(message);
            };
            

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            
            base.OnModelCreating(modelBuilder);
        }

    }
}