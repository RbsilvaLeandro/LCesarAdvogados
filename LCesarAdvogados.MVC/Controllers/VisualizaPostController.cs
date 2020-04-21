using AutoMapper;
using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LCesarAdvogados.MVC.Controllers
{
    public class VisualizaPostController : Controller
    {
        
        private readonly IPostAppServicos _PostAplicacao;
        public VisualizaPostController(IPostAppServicos PostAplicacao)
        {
            _PostAplicacao = PostAplicacao;
        }
        //
        // GET: /VisualizaPost/
        public ActionResult Index()
        {
            var VisualizaPostViewModel = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(_PostAplicacao.GetAll());
            return View(VisualizaPostViewModel);  
        }
        public ActionResult GetForId(int id)
        {
            ViewData["IdPost"] = id;
            var VisualizaPostViewModelID = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(_PostAplicacao.GetAllForDate());            
            return View(VisualizaPostViewModelID);
        }

        //
        // GET: /VisualizaPost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /VisualizaPost/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VisualizaPost/Create
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

        //
        // GET: /VisualizaPost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /VisualizaPost/Edit/5
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
        // GET: /VisualizaPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /VisualizaPost/Delete/5
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
