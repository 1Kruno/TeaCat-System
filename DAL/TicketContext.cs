using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.DAL
{
    public class TicketContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<KeywordsDepartment> KeywordsDepartments { get; set; }

        public TicketContext() : base("TicketContext")
        {
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers").Property(p => p.Id).HasColumnName("UserId"); ;
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            
        }


    }


}
