using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wencove.conexion.model.neg;
using wencove.conexion.model.entity;
using wencove.Code;

namespace wencove.Controllers
{
    public class RoleController : BaseController
    {

        private RoleNeg negocio;
        public RoleController()
        {
            negocio = new RoleNeg();
        }

        // GET: Role
        public ActionResult Index()
        {
            return View(negocio.findAll());
        }
        public ActionResult GridViewDetailsPage(int id)
        {
            ViewBag.ShowBackButton = true;
            Role obj = new Role(id);
            negocio.find(obj);
            return View(obj);
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", RoleHelper.getroles());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(Role issue)
        {
            return UpdateModelWithDataValidation(issue, RoleHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(Role issue)
        {
            return UpdateModelWithDataValidation(issue, RoleHelper.UpdateRecord);
        }
        private ActionResult UpdateModelWithDataValidation(Role issue, Action<Role> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(issue));
            else
                ViewBag.GeneralError = "Please, correct all errors.";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                RoleHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
       
    }
}
