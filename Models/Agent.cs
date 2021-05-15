using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WebApplication5.Models
{
    public class Agent
    {
        public int AgentID { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public string Role { get; set; }
        public int TicketsAssigned { get; set; }
        public int TicketsPending { get; set; }
        public int TicketsSolved { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual Department Department { get; set; }
    }
}