using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    /*
    public enum Department
    {
        CSS, Sales, Tech, Loyalty, Marketing
    }
    */
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int AgentID { get; set; }
        public int TicketID { get; set; }

        //public Department? Department { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Agent Agent { get; set; }
    }
}