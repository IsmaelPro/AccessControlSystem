using Infra.Enums;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base ("DatabaseContext")
        {
            //System.Data.Entity.Database.SetInitializer(new UniDBInitializer<DatabaseContext>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }


        public DbSet<Visit> Visit { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Images> Images { get; set; }

    }
    

}
