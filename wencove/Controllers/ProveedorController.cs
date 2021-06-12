﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wencove.conexion.model.entity;
using wencove.conexion.model.neg;
using wencove.Model;
namespace wencove.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor

        private ProveedorNeg userNeg;
        public ProveedorController()
        {
            userNeg = new ProveedorNeg();
        }
        public ActionResult Index()
        {
            return View(userNeg.findAll());
        }
        public ActionResult GridViewPartial()
        {

            return PartialView("GridViewPartial", userNeg.findAll());
        }
    }
}