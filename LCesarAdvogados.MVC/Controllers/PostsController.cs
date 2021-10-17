using AutoMapper;
using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LCesarAdvogados.MVC.Controllers
{
    public class PostsController : Controller
    {
      
        private readonly IPostAppServicos _PostAplicacao;
        public PostsController(IPostAppServicos PostAplicacao)
        {
            _PostAplicacao = PostAplicacao;
        }

        public ActionResult Index()
        {
            var PostViewModel = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(_PostAplicacao.GetAll());
            return View(PostViewModel);
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
        public ActionResult Create(PostViewModel post, HttpPostedFileBase file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);          
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/img/Posts"), fileName);
                    file.SaveAs(path);
                    post.ImagemPost = "../img/Posts/" + fileName;
                }
                var PostDominio = Mapper.Map<PostViewModel, Posts>(post);
                _PostAplicacao.Add(PostDominio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var Post = _PostAplicacao.GetById(id);
            var PostsViewModel = Mapper.Map<Posts, PostViewModel>(Post);

            return View(PostsViewModel);
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel Post)
        {
            try
            {
                var PostDomain = Mapper.Map<PostViewModel, Posts>(Post);
                _PostAplicacao.Update(PostDomain);
                return RedirectToAction("Index");
            }
            catch
            {

            }
            return View(Post);
        }

        public ActionResult Delete(int id)
        {
            var Posts = _PostAplicacao.GetById(id);
            var PostViewModel = Mapper.Map<Posts, PostViewModel>(Posts);

            return View(PostViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            var Post = _PostAplicacao.GetById(id);
            _PostAplicacao.Remove(Post);

            return RedirectToAction("Index");
        }
    }
}
