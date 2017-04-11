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
    public class BenefitRegistrationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BenefitRegistrations
        public ActionResult Index()
        {
            return View(db.BenefitRegistrations.ToList());
        }

        // GET: BenefitRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitRegistration benefitRegistration = db.BenefitRegistrations.Find(id);
            if (benefitRegistration == null)
            {
                return HttpNotFound();
            }
            return View(benefitRegistration);
        }

        // GET: BenefitRegistrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BenefitRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RealtionshipStatus,BenefitType,Dental,,Optical,,Paramedical")] BenefitRegistration benefitRegistration)
        {
            if (ModelState.IsValid)
            {
                db.BenefitRegistrations.Add(benefitRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benefitRegistration);
        }

        // GET: BenefitRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitRegistration benefitRegistration = db.BenefitRegistrations.Find(id);
            if (benefitRegistration == null)
            {
                return HttpNotFound();
            }
            return View(benefitRegistration);
        }

        // POST: BenefitRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RealtionshipStatus,BenefitType,Dental,Optical,Paramedical")] BenefitRegistration benefitRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benefitRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benefitRegistration);
        }

        // GET: BenefitRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitRegistration benefitRegistration = db.BenefitRegistrations.Find(id);
            if (benefitRegistration == null)
            {
                return HttpNotFound();
            }
            return View(benefitRegistration);
        }

        // POST: BenefitRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenefitRegistration benefitRegistration = db.BenefitRegistrations.Find(id);
            db.BenefitRegistrations.Remove(benefitRegistration);
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
