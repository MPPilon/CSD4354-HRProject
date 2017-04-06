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
    public class PayrollController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PayrollModels
        public ActionResult Index()
        {
            return View(db.PayrollModels.ToList());
        }

        // GET: PayrollModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayrollModels payrollModels = db.PayrollModels.Find(id);
            if (payrollModels == null)
            {
                return HttpNotFound();
            }
            return View(payrollModels);
        }

        // GET: PayrollModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayrollModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ManagerId,ManagerName,PayRate,Position")] PayrollModels payrollModels)
        {
            if (ModelState.IsValid)
            {
                db.PayrollModels.Add(payrollModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payrollModels);
        }

        // GET: PayrollModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayrollModels payrollModels = db.PayrollModels.Find(id);
            if (payrollModels == null)
            {
                return HttpNotFound();
            }
            return View(payrollModels);
        }

        // POST: PayrollModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ManagerId,ManagerName,PayRate,Position")] PayrollModels payrollModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payrollModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payrollModels);
        }

        // GET: PayrollModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayrollModels payrollModels = db.PayrollModels.Find(id);
            if (payrollModels == null)
            {
                return HttpNotFound();
            }
            return View(payrollModels);
        }

        // POST: PayrollModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PayrollModels payrollModels = db.PayrollModels.Find(id);
            db.PayrollModels.Remove(payrollModels);
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

        // GET: PayrollModels/Instructions
        public ActionResult Instructions(int? id)
        {
            PayrollModels payrollModels = db.PayrollModels.Find(id);

            if (ModelState.IsValid)
            {
                db.Entry(payrollModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Instructions");
            }
            return View(payrollModels);
        }

        // GET: PayrollModels/TimesheetEntry
        public ActionResult TimesheetEntry()
        {
            return View();
        }

        // POST: PayrollModels/TimesheetEntry
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TimesheetEntry([Bind(Include = "Id,Name,ManagerId,ManagerName,PayRate,Position")] PayrollModels payrollModels)
        {
            if (ModelState.IsValid)
            {
                db.PayrollModels.Add(payrollModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payrollModels);
        }

        // GET: PayrollModels/Calendar
        public ActionResult Calendar()
        {
            return View();
        }

        // POST: PayrollModels/Calendar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calendar([Bind(Include = "Id,Name,ManagerId,ManagerName,PayRate,Position")] PayrollModels payrollModels)
        {
            if (ModelState.IsValid)
            {
                db.PayrollModels.Add(payrollModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payrollModels);
        }
    }
}
