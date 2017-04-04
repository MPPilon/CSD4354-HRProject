using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDHRProject.Controllers
{
    public class NewHireController : Controller
    {
        // GET: NewHire
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewHire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewHire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewHire/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewHire/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewHire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewHire/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewHire/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
