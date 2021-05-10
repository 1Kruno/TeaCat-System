using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.DAL;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class TicketController : Controller
    {
        private TicketContext db = new TicketContext();

        // GET: Ticket
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
                                        || s.Status.Contains(searchString)
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
        public ActionResult Details(int? id)
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

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,Title,Body,Status,CreatedAt,AgentID,DepartmentID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var oldnextTicketId = this.db.Tickets.Max(theticket => theticket.TicketID);
                var newTicketId = oldnextTicketId + 1;
                ticket.TicketID = newTicketId;
                ticket.Status = "New";
                ticket.CreatedAt = DateTime.Now;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,Title,Body,Status,CreatedAt,AgentID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Ticket/Delete/5
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
