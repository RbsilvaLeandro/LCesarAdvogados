using AutoMapper;
using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.Filtros;
using LCesarAdvogados.MVC.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LCesarAdvogados.MVC.Controllers
{
   //[AutorizacaoFilterAttribute]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppServico _UsuarioAplicacao;
        public UsuariosController(IUsuarioAppServico UsuarioAplicacao)
        {
            _UsuarioAplicacao = UsuarioAplicacao;
        }

        //
        // GET: /Usuarios/
        public ActionResult Index()
        {
            var UsuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_UsuarioAplicacao.GetAll());
            return View(UsuarioViewModel);
        }

        //
        // GET: /Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuarios/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            try
            {
                var UsuarioDominio = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                _UsuarioAplicacao.Add(UsuarioDominio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            var Usuario = _UsuarioAplicacao.GetById(id);
            var UsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(Usuario);

            return View(UsuarioViewModel);
        }

        //
        // POST: /Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel Usuario)
        {
            try
            {              
                    var UsuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(Usuario);
                    _UsuarioAplicacao.Update(UsuarioDomain);
                    return RedirectToAction("Index");                
            }
            catch
            {

            }
            return View(Usuario);
        }

        //
        // GET: /Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            var Usuario = _UsuarioAplicacao.GetById(id);
            var UsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(Usuario);

            return View(UsuarioViewModel);
        }

        //
        // POST: /Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Usuario = _UsuarioAplicacao.GetById(id);
            _UsuarioAplicacao.Remove(Usuario);

            return RedirectToAction("Index");
        }
    }
}
