using AutoMapper;
using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.ViewModel;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            var VisualizaPostViewModel = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(_PostAplicacao.GetAll());
            return View(VisualizaPostViewModel);  
        }
        public ActionResult GetForId(int id)
        {
            ViewData["IdPost"] = id;
            var VisualizaPostViewModelID = Mapper.Map<Posts, PostViewModel>(_PostAplicacao.GetById(id));

            if (VisualizaPostViewModelID != null)
                return View(VisualizaPostViewModelID);
            else
                return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
