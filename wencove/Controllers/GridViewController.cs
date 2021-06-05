using System;
using System.Web.Mvc;
using wencove.conexion.model.entity;
using wencove.conexion.model.neg;
using wencove.Model;

namespace wencove.Controllers
{
    public class GridViewController : BaseController
    {


        private UserNeg userNeg;
        public GridViewController()
        {
            userNeg = new UserNeg();
        }
        // GET: GridView
        public ActionResult Index()
        {
            return View(userNeg.findAll());
        }
        public ActionResult GridViewDetailsPage(int id)
        {
            ViewBag.ShowBackButton = true;
          
            return View(GridViewHelper.getEmpresas());
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", GridViewHelper.getUsers());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(User issue)
        {
            return UpdateModelWithDataValidation(issue, GridViewHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(User issue)
        {
            return UpdateModelWithDataValidation(issue, GridViewHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(User issue, Action<User> updateMethod)
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
                GridViewHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}