using wencove.Controllers;
using System;
using System.Web;
using System.Web.Mvc;
using wencove.Model;

namespace wencove.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private ApplicationUser oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (ApplicationUser)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is AccountController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Account/SignIn");
                    }



                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Account/SignIn");
            }

        }
    }
}