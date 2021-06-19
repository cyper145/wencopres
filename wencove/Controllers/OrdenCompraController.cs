using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wencove.conexion.model.neg;
using wencove.conexion.model.entity;
using DevExpress.Web.Mvc;
using wencove.Models;

namespace wencove.Controllers
{
    public class OrdenCompraController : Controller
    {
        // GET: OrdenCompra
        private OrdenCompraNeg userNeg;
        private ProveedorNeg proveedorNeg;
        private ArticuloNeg articuloNeg;
         static OrdenCompra OrdeCurrent;


        public OrdenCompraController()
        {
            userNeg = new OrdenCompraNeg();
            articuloNeg= new ArticuloNeg();
            proveedorNeg = new ProveedorNeg();
            if (OrdeCurrent==null)
                OrdeCurrent=new OrdenCompra();
        }
        public ActionResult Index()
        {
            return View(userNeg.findAll());
        }
        public ActionResult GridViewPartial()
        {

            return PartialView("GridViewPartial", userNeg.findAll());
        }

        public ActionResult ExternalEditFormPartial()
        {
            
            return PartialView("ExternalEditFormPartial", userNeg.findAll());
        }

        public ActionResult ExternalEditFormEdit(   string id = "")
        {

            //solo para pruebas
            string codigo = "0000000000001";


            OrdeCurrent =   userNeg.find(codigo);
           // EditableProduct editProduct = NorthwindDataProvider.GetEditableProduct(productID);
            if (OrdeCurrent == null)
            {
                OrdeCurrent = new OrdenCompra();
                OrdeCurrent.OC_CNUMORD = "-1";
            }
            return View( "EditingForm", OrdeCurrent);
        }


        /// para el grid 
        public ActionResult EditPartialForm( )
        {

            //solo para pruebas
            string codigo = "0000000000001";


            OrdeCurrent = userNeg.find(codigo);
            return PartialView(userNeg.findAllDetail (OrdeCurrent.OC_CNUMORD));
        }
        public ActionResult GridViewCustomActionUpdate(Proveedor mainModel)
        {
            ViewData["SuccessFlag"] = UpdateAllValues(null, mainModel);
            return PartialView("GridViewPartial", userNeg.findAll());
        }
        /* save all changes to a data base in this action */
        public bool UpdateAllValues(MVCxGridViewBatchUpdateValues<GridDataItem, int> batchValues, Proveedor mainModel)
        {
            if (batchValues != null)
            {
                foreach (var item in batchValues.Insert)
                {
                    if (batchValues.IsValid(item))
                        BatchEditRepository.InsertNewItem(item, batchValues);
                    else
                        batchValues.SetErrorText(item, "Correct validation errors");
                }
                foreach (var item in batchValues.Update)
                {
                    if (batchValues.IsValid(item))
                        BatchEditRepository.UpdateItem(item, batchValues);
                    else
                        batchValues.SetErrorText(item, "Correct validation errors");
                }
                foreach (var itemKey in batchValues.DeleteKeys)
                {
                    BatchEditRepository.DeleteItem(itemKey, batchValues);
                }
            }
            bool result = false;
            if (mainModel != null)
            {
                //custom actions
                result = true;
            }
            return result && (batchValues == null || batchValues.EditorErrors.Count == 0);
        }
        public ActionResult BatchUpdatePartial(MVCxGridViewBatchUpdateValues<GridDataItem, int> batchValues, Proveedor mainModel)
        {
            ViewData["SuccessFlag"] = UpdateAllValues(batchValues, mainModel);
            return PartialView("GridViewPartial", BatchEditRepository.GridData);
        }
        public ActionResult Success()
        {
            return View("Success");
        }


        public ActionResult MultiSelectPartial()
        {
            return PartialView("MultiSelectPartial", articuloNeg.findAll());
        }
        public ActionResult MultiSelectProveedor(string CurrentCategory)
        {

            ViewData["Proveedores"] = proveedorNeg.findAll();
            if (CurrentCategory == null)
                CurrentCategory = "";
            return PartialView(new Proveedor() { PRVCCODIGO = CurrentCategory });    
        }
    }
}