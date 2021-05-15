using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.DAL;
using WebApplication5.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication5.Controllers
{
    public class TicketController : Controller
    {
        private TicketContext db = new TicketContext();

        // GET: Ticket
        [Authorize(Roles = "TCAdmin,TCManager,TCAgent")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "body_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tickets = from s in db.Tickets
            //IQueryable<Ticket> tickets = from s in db.Tickets
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Title.Contains(searchString)
                                        || s.Body.Contains(searchString)
                                        || s.Status.ToString().Contains(searchString)
                                        || s.TicketID.ToString().Contains(searchString)
                                        || s.CreatedAt.ToString().Contains(searchString)
                                        || s.Agent.FirstName.ToString().Contains(searchString)
                                        || s.Department.DepartmentName.ToString().Contains(searchString)
                                        );
            }

            switch (sortOrder)
            {
                case "title_desc":
                    tickets = tickets.OrderByDescending(s => s.Title);
                    break;
                case "body_desc":
                    tickets = tickets.OrderBy(s => s.Body);
                    break;
                case "status_desc":
                    tickets = tickets.OrderByDescending(s => s.Status);
                    break;
                case "id_desc":
                    tickets = tickets.OrderBy(s => s.TicketID);
                    break;
                case "date_desc":
                    tickets = tickets.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    tickets = tickets.OrderBy(s => s.TicketID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tickets.ToPagedList(pageNumber, pageSize));
        }

        // GET: Ticket/Details/5
        [Authorize(Roles = "TCAdmin,TCManager,TCAgent")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            //ViewBag.TicketName = db.Tickets.Find(id);
            //var comment = db.TicketComments.Where(x => x.TicketID.Equals(id)).ToList();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET ALL TICKETS SUBMITTED BY LOGGED IN USER
        [Authorize]
        public ActionResult MyTickets()
        {
            string currentUserId = User.Identity.GetUserId();
            ViewBag.myTicketList = db.Tickets.Where(m => m.RequesterID.Contains(currentUserId)).ToList();
            var theResult = db.Tickets.Where(m => m.RequesterID.Contains(currentUserId)).ToList();
            return View(theResult);
        }

        // GET: Ticket/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "TicketID,Title,Body,Status,CreatedAt,AgentID,DepartmentID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                // ASSIGNMENT OPERATION
                int numberOdDepartments = this.db.Departments.Max(thedepartment => thedepartment.DepartmentID); // GET THE NUMBER OF DEPARTMENTS
                int[][] DepartmentIDandKeywordMatches = new int[numberOdDepartments][]; // CREATE A JAGGED ARRAY FOR EACH DEPARTMENT
                System.Diagnostics.Debug.WriteLine("There are " + numberOdDepartments + " departments.");
                int matchScore; // INSTANTIATE THE MATCH SCORE
                int matchDepartment = 1;
                int agentLeastTicketsID = 1;

                // CREATE A JAGGED ARRAY FOR EACH DEPARTMENT [DEPARTMENT ID][# OF MATCHES]
                for (int i=0; i< numberOdDepartments; i++)
                {
                    DepartmentIDandKeywordMatches[i] = new int[] { 0 };
                }

                string ticketTitleWord = ticket.Title.ToString(); // TAKE INPUT FROM TICKET TITLE
                string ticketBodyWord = ticket.Body.ToString(); // TAKE INPUT FROM TICKET BODY
                string titleAndBodyWord = ticketTitleWord + " " + ticketBodyWord; // COMBINE INTO 1 STRING
                string[] ticketWordList = titleAndBodyWord.Split(null); // ISOLATE EACH WORD

                foreach (var word in ticketWordList) // ITERATE THROUGH TICKET WORDS
                {
                    var result1 = db.KeywordsDepartments.Where(x => x.Keyword.Contains(word)).ToList(); // FETCH KEYWORDS
                    var result = result1.ToString();
                    foreach(var keyword in result1) // ITERATE THROUGH KEYWORDS
                    {
                        bool matches = word.Equals(keyword.Keyword.ToString(), StringComparison.OrdinalIgnoreCase); // COMPARE
                        if (matches) // IF THEY MATCH
                        {
                            System.Diagnostics.Debug.WriteLine("Match found.");
                            int targetDepartmentID = keyword.DepartmentID; // GET DEPARTMENT INDEX FROM DB
                            int y = DepartmentIDandKeywordMatches[targetDepartmentID][0]; // GET DEPARTMENT ID FROM ARRAY
                            int z = y + 1; // INCREMENT SCORE FOR # OF MATCHES
                            DepartmentIDandKeywordMatches[targetDepartmentID][0] = z; // UPDATE THE SCORE

                            //int matchScore; // INSTANTIATE THE MATCH SCORE
                            //int matchDepartment;
                            for (int n = 0; n < DepartmentIDandKeywordMatches.Length; n++) // ITERATE THROUGH ARRAY
                            {
                                for (int k = 0; k < DepartmentIDandKeywordMatches[n].Length; k++)
                                {
                                    matchScore = DepartmentIDandKeywordMatches[0][0]; // MATCH SCORE IS THE 1ST SCORE IN ARRAY
                                    if(DepartmentIDandKeywordMatches[n][k] > matchScore) // IF THE BIGGER SCORE IS FOUND
                                    {
                                        matchScore = DepartmentIDandKeywordMatches[n][k]; // MATCH SCORE IS THE BIGGER SCORE
                                        matchDepartment = n; // DEPARTMENT ID WITH MOST MATCHES
                                        System.Diagnostics.Debug.WriteLine("Score: " + matchScore);
                                    }
                                }
                            }
                        }
                    }
                }
   
                var agentsResult = db.Agents.Where(m => m.DepartmentID.Equals(matchDepartment)).ToList(); // FETCH AGENTS FROM TARGET DEPARTMENT
                bool firstAgent = true; // BOOL TO TAKE THE VALUE FROM 1ST AGENT AS PARAM
                int agentLeastTickets = 500; // INSTANTIATE
                foreach(var agent in agentsResult)
                {
                    if (firstAgent) // SET 1ST AFENT AS COMPARISON
                    {
                        agentLeastTickets = agent.TicketsAssigned;
                        agentLeastTicketsID = agent.AgentID;
                        firstAgent = false; // MAKE THIS PART UNAVAILABLE FOR THE REST
                    }
                    if (agent.TicketsAssigned < agentLeastTickets) // IF THERE'S AN AGENT WITH LESS TICKETS THAN 1ST AGENT
                    {
                        agentLeastTickets = agent.TicketsAssigned; // TICKET COUNT FOR THAT AGENT
                        agentLeastTicketsID = agent.AgentID; // TARGET THAT AGENT
                        System.Diagnostics.Debug.WriteLine(" New data: Agent with least tickets: " + agent.FirstName + " and ID:" + agent.AgentID);
                    }
                    System.Diagnostics.Debug.WriteLine("Agent with least tickets: " + agent.FirstName + " and ID:" + agent.AgentID + " and ticket count " + agent.TicketsAssigned +". Current least ID is: " + agentLeastTicketsID);
                }

                var listOfAgents = db.Agents.Where(n => n.AgentID.Equals(agentLeastTicketsID)).ToList(); // FIND AGENT
                foreach(var agent in listOfAgents)
                {
                    int noOfAssignedTickets = agent.TicketsAssigned + 1; // UPDATE TICKET COUNT
                    agent.TicketsAssigned = noOfAssignedTickets;
                    System.Diagnostics.Debug.WriteLine("Agent has " + noOfAssignedTickets + " tickets assigned");
                }
                
                System.Diagnostics.Debug.WriteLine("Ticket goes to ID:" + agentLeastTicketsID);

                int oldnextTicketId = this.db.Tickets.Max(theticket => theticket.TicketID); // GET THE LAST INDEX
                int newTicketId = oldnextTicketId + 1; // INCREMENT INDEX BY 1
                ticket.TicketID = newTicketId; // ASSIGN INDEX FOR THE TICKET
                ticket.Status = Ticket.TicketStatus.Open;
                ticket.CreatedAt = DateTime.Now;
                ticket.AgentID = agentLeastTicketsID; // ASSIGN TICKET TO AGENT WITH LEAST AMOUNT OF TICKETS
                ticket.RequesterID = User.Identity.GetUserId();
                ticket.DepartmentID = db.Agents.Find(agentLeastTicketsID).DepartmentID;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: Ticket/Edit/5
        [Authorize(Roles = "TCAdmin,TCManager,TCAgent")]
        public ActionResult Edit(int? id)
        {
            System.Diagnostics.Debug.WriteLine("I got here 1:");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            System.Diagnostics.Debug.WriteLine("I got here 2:");
            ViewBag.AgentID = new SelectList(db.Agents, "AgentId", "FirstName"); // GET LIST OF AGENTS
            
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "TCAdmin,TCManager,TCAgent")]
        public ActionResult Edit([Bind(Include = "TicketID,Title,Body,Status,CreatedAt,AgentID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                
                if (ticket.Status.Equals(Ticket.TicketStatus.Solved))
                {
                    int targetAgentId = ticket.AgentID;
                    var targetAgent = db.Agents.Find(targetAgentId).AgentID;
                    int ticketSolvedCount = db.Agents.Find(targetAgent).TicketsSolved;
                    int newSolvedTicketCount = ticketSolvedCount + 1;
                    db.Agents.Find(targetAgent).TicketsSolved = newSolvedTicketCount;

                    int ticketOpenedCount = db.Agents.Find(targetAgent).TicketsAssigned;
                    int newticketOpenedCount = ticketOpenedCount - 1;
                    db.Agents.Find(targetAgent).TicketsAssigned = newticketOpenedCount;
                }
                ticket.CreatedAt = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentId", "FirstName", ticket.AgentID);
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
