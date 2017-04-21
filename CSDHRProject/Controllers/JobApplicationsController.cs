using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSDHRProject.Models;
using System.IO;

namespace CSDHRProject.Controllers
{
    public class JobApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobApplications
        public ActionResult Index()
        {
            return View(db.JobApplications.ToList());
        }

        // GET: JobApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobApplicationId,ApplicantFirstName,ApplicantLastName,ApplicantEmail,ResumeFileName,CoverLetterFileName,ApplicantStatus")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                db.JobApplications.Add(jobApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobApplication);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJobApplication(ApplicationEditViewModel jevm)
        {
            JobApplication jobApplication = jevm.Item;
            
            if (ModelState.IsValid)
            {
                if(jevm.ResumeFile != null && jevm.ResumeFile.ContentLength > 0)
                {
                    var applicationFolder = "/Content/JobApplications/";
                    var filename = DateTime.Now.ToBinary().ToString("x") +
                        Path.GetFileName(jevm.ResumeFile.FileName);
                    var path = Path.Combine(Server.MapPath("~" + applicationFolder), filename);
                    jevm.ResumeFile.SaveAs(path);
                    jevm.Item.ResumeFileName = applicationFolder + filename;

                }

                if (jevm.CoverLetterFile != null && jevm.CoverLetterFile.ContentLength > 0)
                {
                    var applicationFolder = "/Content/JobApplications/";
                    var filename = DateTime.Now.ToBinary().ToString("x") +
                        Path.GetFileName(jevm.CoverLetterFile.FileName);
                    var path = Path.Combine(Server.MapPath("~" + applicationFolder), filename);
                    jevm.CoverLetterFile.SaveAs(path);
                    jevm.Item.CoverLetterFileName = applicationFolder + filename;
                }
                db.JobApplications.Add(jobApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        // GET: JobApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobApplicationId,ApplicantFirstName,ApplicantLastName,ApplicantEmail,ResumeFileName,CoverLetterFileName,ApplicantStatus")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            db.JobApplications.Remove(jobApplication);
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


  

        // POST: JobApplications/Details/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "ApplicantStatus")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobApplication);
        }
    }
}
