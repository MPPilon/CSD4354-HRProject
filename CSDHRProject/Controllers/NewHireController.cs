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
    public class NewHireController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewHire
        public ActionResult Index()
        {
            return View(db.NewHireModels.ToList());
        }

        // GET: NewHire/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewHireModel newHireModel = db.NewHireModels.Find(id);
            if (newHireModel == null)
            {
                return HttpNotFound();
            }
            return View(newHireModel);
        }

        // GET: NewHire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewHire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Sin,BenefitNumber,RateOfPay,VacationDays,SickDays,BenefitCertificateFileName,TrainingCertificateFileName")] NewHireModel newHireModel)
        {
            if (ModelState.IsValid)
            {
                db.NewHireModels.Add(newHireModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newHireModel);
        }

        // GET: NewHire/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewHireModel newHireModel = db.NewHireModels.Find(id);
            if (newHireModel == null)
            {
                return HttpNotFound();
            }
            return View(newHireModel);
        }

        // POST: NewHire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sin,BenefitNumber,RateOfPay,VacationDays,SickDays,BenefitCertificateFileName,TrainingCertificateFileName")] NewHireModel newHireModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newHireModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newHireModel);
        }

        // GET: NewHire/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewHireModel newHireModel = db.NewHireModels.Find(id);
            if (newHireModel == null)
            {
                return HttpNotFound();
            }
            return View(newHireModel);
        }

        // POST: NewHire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewHireModel newHireModel = db.NewHireModels.Find(id);
            db.NewHireModels.Remove(newHireModel);
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
