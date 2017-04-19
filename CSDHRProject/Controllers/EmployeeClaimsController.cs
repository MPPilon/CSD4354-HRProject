using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSDHRProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CSDHRProject.Controllers
{
    public class EmployeeClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeClaims
        public ActionResult Index()
        {
            var appUser = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
            var claims = db.EmployeeClaims.Where(x => x.User.Id == appUser.Id).ToList();
            return View();
        }

        // GET: EmployeeClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeClaim employeeClaim = db.EmployeeClaims.Find(id);
            if (employeeClaim == null)
            {
                return HttpNotFound();
            }
            return View(employeeClaim);
        }

        // GET: EmployeeClaims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Amount,Date,Service")] EmployeeClaim employeeClaim)
        {
            if (ModelState.IsValid)
            {
                var appUser = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
                employeeClaim.User = appUser;
                db.EmployeeClaims.Add(employeeClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeClaim);
        }

        // GET: EmployeeClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeClaim employeeClaim = db.EmployeeClaims.Find(id);
            if (employeeClaim == null)
            {
                return HttpNotFound();
            }
            return View(employeeClaim);
        }

        // POST: EmployeeClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Amount,Date,Service")] EmployeeClaim employeeClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeClaim);
        }

        // GET: EmployeeClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeClaim employeeClaim = db.EmployeeClaims.Find(id);
            if (employeeClaim == null)
            {
                return HttpNotFound();
            }
            return View(employeeClaim);
        }

        // POST: EmployeeClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeClaim employeeClaim = db.EmployeeClaims.Find(id);
            db.EmployeeClaims.Remove(employeeClaim);
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
