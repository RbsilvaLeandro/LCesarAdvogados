using AutoMapper;
using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LCesarAdvogados.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostAppServicos _PostAplicacao;
        public HomeController(IPostAppServicos PostAplicacao)
        {
            _PostAplicacao = PostAplicacao;
        }

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ResumoPost()
        {
            var VisualizaResumoPost = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(_PostAplicacao.GetAll());   
            return PartialView(VisualizaResumoPost);
        }
        [HttpPost]
        public ActionResult EnviarContato(String Nome, String Email, String Assunto, String Mensagem)
        {
            //Enviando Email de contato

            RetornoFuncao obj_RETORNO = new RetornoFuncao();

            EnvioEmail em = new EnvioEmail();

            if (em.EnvioEmailCliente(Mensagem, "peterlsouza@gmail.com", Assunto, Email))
            {
                obj_RETORNO.MsgError = "";
                obj_RETORNO.MsgSucesso = "Falha ao enviar o Email";
            }
            else
            {
                obj_RETORNO.MsgSucesso = "";
                obj_RETORNO.MsgError = "Falha ao enviar o Email";
            }
            return Json(obj_RETORNO);

        }

    }
}