using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wencove.conexion.model.neg;
namespace wencove.Controllers
{
    public class OrdenCompraController : Controller
    {
        // GET: OrdenCompra
        private ProveedorNeg userNeg;
        public OrdenCompraController()
        {
            userNeg = new ProveedorNeg();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GridViewPartial()
        {

            return PartialView("GridViewPartial", userNeg.findAll());
        }
    }
}