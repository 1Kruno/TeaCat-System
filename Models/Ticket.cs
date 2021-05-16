using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AgentID { get; set; }
        public int? DepartmentID { get; set; }
        public string RequesterID { get; set; }

        public enum TicketStatus
        {
            Open = 1,
            Solved = 2
        }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual Department Department { get; set; }
    }
}
