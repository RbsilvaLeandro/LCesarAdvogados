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
        public ActionResult Index()
        {
            var UsuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_UsuarioAplicacao.GetAll());
            return View(UsuarioViewModel);
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

        public ActionResult Edit(int id)
        {
            var Usuario = _UsuarioAplicacao.GetById(id);
            var UsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(Usuario);

            return View(UsuarioViewModel);
        }

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

        public ActionResult Delete(int id)
        {
            var Usuario = _UsuarioAplicacao.GetById(id);
            var UsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(Usuario);

            return View(UsuarioViewModel);
        }

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
