using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Infrastructure;

namespace WebApplication5.DAL
{
    public class TicketContext : DbContext
    {

        public TicketContext() : base("TicketContext")
        {

        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<KeywordsDepartment> KeywordsDepartments { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public static TicketContext Create()
        {
            return new TicketContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

     






        //public System.Data.Entity.DbSet<WebApplication5.Models.Department> Departments { get; set; }

        //public System.Data.Entity.DbSet<WebApplication5.Models.KeywordsDepartment> KeywordsDepartments { get; set; }


    }
}