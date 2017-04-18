using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
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
            return View(new NewHireEditViewModel { NewHire = newHireModel });
        }

        // POST: NewHire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item, File")] NewHireEditViewModel nhvm)
        {
            if (ModelState.IsValid)
            {
                if (nhvm.BenefitFile != null && nhvm.TrainingFile != null && nhvm.BenefitFile.ContentLength > 0 && nhvm.TrainingFile.ContentLength > 0)
                {
                    var fileFolder = "fileDocuments";
                    var BenefitFileName = DateTime.Now.ToBinary().ToString("X") + Path.GetFileName(nhvm.BenefitFile.FileName);
                    var TrainingFileName = DateTime.Now.ToBinary().ToString("X") + Path.GetFileName(nhvm.TrainingFile.FileName);
                    var path1 = Path.Combine(Server.MapPath("~" + fileFolder), BenefitFileName);
                    var path2 = Path.Combine(Server.MapPath("~" + fileFolder), TrainingFileName);
                    nhvm.BenefitFile.SaveAs(path1);
                    nhvm.TrainingFile.SaveAs(path2);
                    nhvm.NewHire.BenefitCertificateFileName = fileFolder + BenefitFileName;
                    nhvm.NewHire.TrainingCertificateFileName = fileFolder + TrainingFileName;

                }
                db.Entry(nhvm.NewHire.BenefitCertificateFileName).State = EntityState.Modified;
                db.Entry(nhvm.NewHire.TrainingCertificateFileName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhvm);
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
