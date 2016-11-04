using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbank.Controllers
{
    public class NettbankController : Controller
    {
        // GET: Nettbank
        public ActionResult Index()
        {
            return View();
        }

        // GET: Nettbank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nettbank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nettbank/Create
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

        // GET: Nettbank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nettbank/Edit/5
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

        // GET: Nettbank/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nettbank/Delete/5
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
