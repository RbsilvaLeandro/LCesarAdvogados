using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LCesarAdvogados.MVC.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object Usuario = filterContext.HttpContext.Session["UsuarioLogado"];
            if (Usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                          new { controller = "Login", action = "Index" }
                        )
                    );
            }
        }
    }
}