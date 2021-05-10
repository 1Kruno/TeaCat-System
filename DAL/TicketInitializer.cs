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
        /*
        public override void InitializeDatabase(TicketContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
        */

        protected override void Seed(TicketContext context)
        {
            var departments = new List<Department>
            {
            new Department{DepartmentId=0,DepartmentName="Unassigned"},
            new Department{DepartmentId=1,DepartmentName="CSS"},
            new Department{DepartmentId=2,DepartmentName="Loyalty"},
            new Department{DepartmentId=3,DepartmentName="Sales"},
            new Department{DepartmentId=4,DepartmentName="Tech Support"},
            new Department{DepartmentId=5,DepartmentName="Marketing"},
            new Department{DepartmentId=6,DepartmentName="Retention"}
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var agents = new List<Agent>
            {
            new Agent{AgentID=0,FirstName="Unassigned",Surname="Unassigned",Email="Unassigned",DepartmentID=0},
            new Agent{AgentID=1,FirstName="Mike",Surname="Smith",Email="mike@gmail.com",DepartmentID=1},
            new Agent{AgentID=2,FirstName="Luke",Surname="Donnell",Email="luke@gmail.com",DepartmentID=6},
            new Agent{AgentID=3,FirstName="Dennis",Surname="Andersen",Email="dennis@gmail.com",DepartmentID=1},
            new Agent{AgentID=4,FirstName="Peter",Surname="Schmidt",Email="pete@gmail.com",DepartmentID=2},
            new Agent{AgentID=5,FirstName="Derek",Surname="Kovach",Email="derek@gmail.com",DepartmentID=3},
            new Agent{AgentID=6,FirstName="Pat",Surname="OBrien",Email="pat@gmail.com",DepartmentID=4},
            new Agent{AgentID=7,FirstName="Laura",Surname="Wolf",Email="laura@gmail.com",DepartmentID=4},
            new Agent{AgentID=8,FirstName="Jess",Surname="Madeira",Email="jess@gmail.com",DepartmentID=5}
            };

            agents.ForEach(s => context.Agents.Add(s));
            context.SaveChanges();

            var tickets = new List<Ticket>
            {
            new Ticket{TicketID=0,Title="Help with something",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=1},
            new Ticket{TicketID=1,Title="Help regarding the sales",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=1},
            new Ticket{TicketID=2,Title="I need info about pricing",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=2},
            new Ticket{TicketID=3,Title="I need help",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=3},
            new Ticket{TicketID=4,Title="How do I log in?",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=1},
            new Ticket{TicketID=5,Title="Where do I view things?",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=4},
            new Ticket{TicketID=6,Title="????",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=4},
            new Ticket{TicketID=7,Title="Bug found",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=1},
            new Ticket{TicketID=8,Title="Who can help me with PC?",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=5},
            new Ticket{TicketID=9,Title="I found something cheaper",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=1},
            new Ticket{TicketID=10,Title="I want to leave",Body="Hi, hope you're well. I'm writing from the local cafe bonanza 65 and I would like to ask you for some help regarding boosting my sales as they haven't been doing so well lately. Please call me back at 0899996622 or send me an email to briana@gmail.com. Thanks!",CreatedAt=DateTime.Parse("2020-12-12"),Status="New",AgentID=6}
            };
            tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();

            /*
            var assignments = new List<Assignment>
            {
            new Assignment{AgentID=1,TicketID=1},
            new Assignment{AgentID=1,TicketID=2},
            new Assignment{AgentID=2,TicketID=3},
            new Assignment{AgentID=3,TicketID=4},
            new Assignment{AgentID=3,TicketID=5},
            new Assignment{AgentID=3,TicketID=6},
            new Assignment{AgentID=4,TicketID=7},
            new Assignment{AgentID=4,TicketID=8},
            new Assignment{AgentID=5,TicketID=9},
            new Assignment{AgentID=6,TicketID=10}
            };
            assignments.ForEach(s => context.Assignments.Add(s));
            context.SaveChanges();
            */
            
        }
    }
}