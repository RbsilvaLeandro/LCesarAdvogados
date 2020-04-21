using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LCesarAdvogados.MVC.Controllers
{
    public class AreaAdministrativaController : Controller
    {        

        //
        // GET: /AreaAdministrativa/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AreaAdministrativa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AreaAdministrativa/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AreaAdministrativa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
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

        //
        // GET: /AreaAdministrativa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AreaAdministrativa/Edit/5
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

        //
        // GET: /AreaAdministrativa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AreaAdministrativa/Delete/5
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
