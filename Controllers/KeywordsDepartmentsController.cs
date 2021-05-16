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
    public class KeywordsDepartmentsController : Controller
    {
        private TicketContext db = new TicketContext();

        // GET: KeywordsDepartments
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Index()
        {
            var keywordsDepartments = db.KeywordsDepartments.Include(k => k.Department);
            return View(keywordsDepartments.ToList());
        }

        // GET: KeywordsDepartments/Details/5
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordsDepartment keywordsDepartment = db.KeywordsDepartments.Find(id);
            if (keywordsDepartment == null)
            {
                return HttpNotFound();
            }
            return View(keywordsDepartment);
        }

        // GET: KeywordsDepartments/Create
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: KeywordsDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Create([Bind(Include = "KeywordID,Keyword,DepartmentID")] KeywordsDepartment keywordsDepartment)
        {
            if (ModelState.IsValid)
            {
                db.KeywordsDepartments.Add(keywordsDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName", keywordsDepartment.DepartmentID);
            return View(keywordsDepartment);
        }

        // GET: KeywordsDepartments/Edit/5
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordsDepartment keywordsDepartment = db.KeywordsDepartments.Find(id);
            if (keywordsDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName", keywordsDepartment.DepartmentID);
            return View(keywordsDepartment);
        }

        // POST: KeywordsDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Edit([Bind(Include = "KeywordID,Keyword,DepartmentID")] KeywordsDepartment keywordsDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keywordsDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "DepartmentName", keywordsDepartment.DepartmentID);
            return View(keywordsDepartment);
        }

        // GET: KeywordsDepartments/Delete/5
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeywordsDepartment keywordsDepartment = db.KeywordsDepartments.Find(id);
            if (keywordsDepartment == null)
            {
                return HttpNotFound();
            }
            return View(keywordsDepartment);
        }

        // POST: KeywordsDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "TCAdmin,TCManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            KeywordsDepartment keywordsDepartment = db.KeywordsDepartments.Find(id);
            db.KeywordsDepartments.Remove(keywordsDepartment);
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
