using AutoMapper;
using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.Dominio.Servicos;
using LCesarAdvogados.MVC.Filtros;
using LCesarAdvogados.MVC.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LCesarAdvogados.MVC.Controllers
{
    //[AutorizacaoFilterAttribute]
    public class PostsController : Controller
    {
      
        private readonly IPostAppServicos _PostAplicacao;
        public PostsController(IPostAppServicos PostAplicacao)
        {
            _PostAplicacao = PostAplicacao;
        }

        //
        // GET: /Posts/
        public ActionResult Index()
        {
            var PostViewModel = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(_PostAplicacao.GetAll());
            return View(PostViewModel);
        }

        //
        // GET: /Posts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Posts/Create
       
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
                    post.ImagemPost = path.Replace("C:\\WebSites\\LCesarAdvogados\\LCesarAdvogados.MVC\\","");
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

        //
        // GET: /Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var Post = _PostAplicacao.GetById(id);
            var PostsViewModel = Mapper.Map<Posts, PostViewModel>(Post);

            return View(PostsViewModel);
        }

        //
        // POST: /Posts/Edit/5
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

        //
        // GET: /Posts/Delete/5
        public ActionResult Delete(int id)
        {
            var Posts = _PostAplicacao.GetById(id);
            var PostViewModel = Mapper.Map<Posts, PostViewModel>(Posts);

            return View(PostViewModel);
        }

        //
        // POST: /Posts/Delete/5
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
