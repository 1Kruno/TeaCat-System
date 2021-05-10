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

        public TicketContext() : base("TicketContext")
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<WebApplication5.Models.Department> Departments { get; set; }
    }
}