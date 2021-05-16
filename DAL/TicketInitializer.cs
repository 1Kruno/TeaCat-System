using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.DAL
{
    public class TicketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TicketContext>
    {

        protected override void Seed(TicketContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var departments = new List<Department>
            {
            new Department{DepartmentID=1,DepartmentName="CSS"},
            new Department{DepartmentID=2,DepartmentName="Loyalty"},
            new Department{DepartmentID=3,DepartmentName="Sales"},
            new Department{DepartmentID=4,DepartmentName="Tech Support"},
            new Department{DepartmentID=5,DepartmentName="Marketing"},
            new Department{DepartmentID=6,DepartmentName="Retention"}
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var agents = new List<Agent>
            {
            new Agent{AgentID=1,FirstName="Mike",Surname="Smith",Email="mike@gmail.com",DepartmentID=1,TicketsAssigned=4},
            new Agent{AgentID=2,FirstName="Luke",Surname="Donnell",Email="luke@gmail.com",DepartmentID=1},
            new Agent{AgentID=3,FirstName="Dennis",Surname="Andersen",Email="dennis@gmail.com",DepartmentID=2,TicketsAssigned=3},
            new Agent{AgentID=4,FirstName="Peter",Surname="Schmidt",Email="pete@gmail.com",DepartmentID=2},
            new Agent{AgentID=5,FirstName="Derek",Surname="Kovach",Email="derek@gmail.com",DepartmentID=3,TicketsAssigned=3},
            new Agent{AgentID=6,FirstName="Pat",Surname="OBrien",Email="pat@gmail.com",DepartmentID=3},
            new Agent{AgentID=7,FirstName="Laura",Surname="Wolf",Email="laura@gmail.com",DepartmentID=4},
            new Agent{AgentID=8,FirstName="Jess",Surname="Madeira",Email="jess@gmail.com",DepartmentID=4}
            };

            agents.ForEach(s => context.Agents.Add(s));
            context.SaveChanges();

            var tickets = new List<Ticket>
            {
            new Ticket{TicketID=1,Title="Help regarding the sales",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=1},
            new Ticket{TicketID=2,Title="I need info about pricing",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=1},
            new Ticket{TicketID=3,Title="I need help",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=1},
            new Ticket{TicketID=4,Title="How do I log in?",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=1},
            new Ticket{TicketID=5,Title="Where do I view things?",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=3},
            new Ticket{TicketID=6,Title="????",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=3},
            new Ticket{TicketID=7,Title="Bug found",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=3},
            new Ticket{TicketID=8,Title="Who can help me with PC?",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=5},
            new Ticket{TicketID=9,Title="I found something cheaper",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=5},
            new Ticket{TicketID=10,Title="I want to leave",Body="Sample text for the ticket",CreatedAt=DateTime.Parse("2020-12-12"),Status=Ticket.TicketStatus.Open,AgentID=5}
            };
            tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();

            
        }
    }
}
