using System.Web.Mvc;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.ViewModel;
using AutoMapper;
using LCesarAdvogados.Aplicacao.Interface;

namespace LCesarAdvogados.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioAppServico _usuarioApp;
        public LoginController(IUsuarioAppServico usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel Log)
        {
            if (ModelState.IsValid)
            {
                var Login = Mapper.Map<LoginViewModel, Usuario>(Log);
                Usuario usuario = _usuarioApp.Login(Login);
                if (usuario != null)
                {
                    Session["UsuarioLogado"] = usuario;
                    return RedirectToAction("Index", "Usuarios");
                }
                else
                {
                    ModelState.AddModelError("Erro de Login", "Login ou Senha inválidos!");
                    return View("Index");
                }
            }
            else
            {
                ModelState.AddModelError("Erro de Login", "Usuário não encontrado");
                return View("Index");
            }
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
