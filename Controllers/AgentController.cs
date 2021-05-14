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
    public class AgentController : Controller
    {
        private TicketContext db = new TicketContext();
        private ApplicationDbContext dbc = new ApplicationDbContext();


        // GET: Agent
        [Authorize(Roles = "TCAdmin")]
        //[Authorize(Roles = "TCManager")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "surn_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "dept_desc" : "";
            // SEARCH FUNCTION
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var agents = from s in db.Agents
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                agents = agents.Where(s => s.Surname.Contains(searchString)
                                        || s.FirstName.Contains(searchString)
                                        || s.Email.Contains(searchString)
                                        || s.Department.DepartmentName.Contains(searchString)
                                        );
            }

            // SORTING AGENTS BY PARAMETERS
            switch (sortOrder)
            {
                // SORT ALPHABETICALLY BY SURNAME
                case "surn_desc":
                    agents = agents.OrderByDescending(s => s.Surname);
                    break;
                // SORT ALPHABETICALLY BY NAME
                case "name_desc":
                    agents = agents.OrderBy(s => s.FirstName);
                    break;
                // SORT ALPHABETICALLY BY EMAIL
                case "email_desc":
                    agents = agents.OrderByDescending(s => s.Email);
                    break;
                // SORT ALPHABETICALLY BY DEPARTMENT NAME
                case "dept_desc":
                    agents = agents.OrderBy(s => s.Department.DepartmentName);
                    break;
                // DEFAULT  - SORT ALPHABETICALLY BY SURNAME
                default:
                    agents = agents.OrderBy(s => s.Surname);
                    break;
            }
            // LIMIT RESULTS TO 10 PER PAGE
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(agents.ToPagedList(pageNumber, pageSize));
        }



        // GET: Agent/Details/5
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // GET: Agent/Create
        [Authorize(Roles = "TCAdmin")]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.UserId = new SelectList(dbc.Users, "Id", "UserName");
            ViewBag.Email = new SelectList(dbc.Users, "Email", "Email");
            return View();
        }

        // POST: Agent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgentID,Surname,FirstName,Email,DepartmentID,Id,UserName,Email,UserId")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                var oldnextAgentId = this.db.Agents.Max(theagent => theagent.AgentID);
                var newAgentId = oldnextAgentId + 1;
                agent.AgentID = newAgentId;
                db.Agents.Add(agent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Email = new SelectList(dbc.Users, "Email", "Email", agent.Email);
            ViewBag.UserId = new SelectList(dbc.Users, "Id", "UserName", agent.UserId);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID",null , agent.DepartmentID);
            return View(agent);
        }

        // GET: Agent/Edit/5
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View(agent);
        }

        // POST: Agent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgentID,Surname,FirstName,Email,DepartmentID")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", agent.DepartmentID);
            return View(agent);
        }

        // GET: Agent/Delete/5
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agent agent = db.Agents.Find(id);
            db.Agents.Remove(agent);
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
