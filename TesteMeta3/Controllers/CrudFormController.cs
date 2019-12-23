using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteMeta2.Controllers
{
    public class CrudFormController : Controller
    {
        // GET: CrudForm
        public ActionResult Index( int id )
        {



            return View();
        }

        // GET: CrudForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CrudForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrudForm/Create
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

        // GET: CrudForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CrudForm/Edit/5
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

        // GET: CrudForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CrudForm/Delete/5
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
