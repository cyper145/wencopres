using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wencove.conexion.model.entity;
using wencove.conexion.model.neg;
namespace wencove.Controllers
{
    public class AreaController : BaseController
    {

        private AreaNeg areaNeg;
        public AreaController()
        {
            areaNeg = new AreaNeg();
        }
        // GET: Area
        public ActionResult Index()
        {
            return View();
        }
    }
}