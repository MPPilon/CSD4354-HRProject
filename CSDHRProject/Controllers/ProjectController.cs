using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSDHRProject.Models;

namespace CSDHRProject.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project_Model
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Project_Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project_Model = db.Projects.Find(id);
            if (project_Model == null)
            {
                return HttpNotFound();
            }
            return View(project_Model);
        }

        // GET: Project_Model/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project_Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Date,Description,Author")] Project project_Model)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project_Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project_Model);
        }

        // GET: Project_Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project_Model = db.Projects.Find(id);
            if (project_Model == null)
            {
                return HttpNotFound();
            }
            return View(project_Model);
        }

        // POST: Project_Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Date,Description,Author,Lead")] Project project_Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project_Model);
        }

        // GET: Project_Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project_Model = db.Projects.Find(id);
            if (project_Model == null)
            {
                return HttpNotFound();
            }
            return View(project_Model);
        }

        // POST: Project_Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project_Model = db.Projects.Find(id);
            db.Projects.Remove(project_Model);
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
