using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wencove.conexion.model.neg;
using wencove.conexion.model.entity;
using DevExpress.Web.Mvc;
using wencove.Models;
using wencove.Model;
using Newtonsoft.Json;

namespace wencove.Controllers
{
    public class OrdenCompraController : BaseController
    {
        // GET: OrdenCompra
        private OrdenCompraNeg userNeg;
        private ProveedorNeg proveedorNeg;
        private ArticuloNeg articuloNeg;
        static OrdenCompra OrdeCurrent;


        public OrdenCompraController()
        {
            userNeg = new OrdenCompraNeg();
            articuloNeg = new ArticuloNeg();
            proveedorNeg = new ProveedorNeg();
            if (OrdeCurrent == null)
                OrdeCurrent = new OrdenCompra();
        }
        public ActionResult Index()
        {
            ViewData["Proveedores"] = proveedorNeg.findAll();
            ViewData["FormasPago"] = userNeg.findAllFormasPago();
            ViewData["Solicitud"] = userNeg.findAllSolicitud();
            ViewData["DocRef"] = userNeg.findAllDocRef();

            if (GridViewHelper.OrdenCompras.Count == 0)
            {
                GridViewHelper.OrdenCompras.AddRange(userNeg.findAll());

            }
            return View(GridViewHelper.OrdenCompras);
        }
        public ActionResult GridViewPartial()
        {
          
          //  Dictionary<string, Object> nodes = JsonConvert.DeserializeObject<Dictionary<string, Object>>(fecha);
              
            if (GridViewHelper.OrdenCompras.Count == 0)
            {
                    GridViewHelper.OrdenCompras.AddRange(userNeg.findAll());
               
            }
           
            return PartialView("GridViewPartial", GridViewHelper.OrdenCompras);
        }



        public ActionResult ExternalEditFormPartial()
        {

            return PartialView("ExternalEditFormPartial", userNeg.findAll());
        }

        public ActionResult ExternalEditFormEdit(string id = "")
        {

            //solo para pruebas
            string codigo = "0000000000001";


            OrdeCurrent = userNeg.find(codigo);
            // EditableProduct editProduct = NorthwindDataProvider.GetEditableProduct(productID);
            if (OrdeCurrent == null)
            {
                OrdeCurrent = new OrdenCompra();
                OrdeCurrent.OC_CNUMORD = "-1";
            }
            return View("EditingForm", OrdeCurrent);
        }


        /// para el grid 
        public ActionResult EditPartialForm()
        {

            //solo para pruebas
            string codigo = "0000000000001";


            OrdeCurrent = userNeg.find(codigo);
            return PartialView(userNeg.findAllDetail(OrdeCurrent.OC_CNUMORD));
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


        public ActionResult MultiSelectPartial(string CurrentCategory)
        {

        
            if (CurrentCategory == null)
                CurrentCategory = "";
            return PartialView(new Articulo() { codigo = CurrentCategory });

            
        }
        public ActionResult MultiSelectProveedor(string CurrentCategory)
        {

            ViewData["Proveedores"] = proveedorNeg.findAll();
            if (CurrentCategory == null)
                CurrentCategory = "";
            return PartialView(new Proveedor() { PRVCCODIGO = CurrentCategory });
        }

        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(OrdenCompra issue, FormCollection data)
        {
            var codArticulo = data["gridLookupProveedor"];
            issue.oc_ccodpro = codArticulo.ToString();
            issue.OC_CSITORD = "03";
            issue.EST_NOMBRE = "EMITIDA";
            
            /*
            var length =   HttpUtility.HtmlDecode(data["grid"]);
            Dictionary<string, object> nodes = JsonConvert.DeserializeObject<Dictionary<string, object>>(length);
            var datad =  nodes["batchEditClientModifiedValues"].ToString();
            Dictionary<string, object> nodeinsert = JsonConvert.DeserializeObject<Dictionary<string, object>>(datad);
            var datainsert = nodeinsert["EditState"].ToString();
            Dictionary<string, object> nodeinsertreal = JsonConvert.DeserializeObject<Dictionary<string, object>>(datainsert);
            var datainsertreal = nodeinsertreal["insertedRowValues"].ToString();
            Dictionary<string, object> insertreal = JsonConvert.DeserializeObject<Dictionary<string, object>>(datainsertreal);

            List<DetalleOrdenCompra> articulos = new List<DetalleOrdenCompra>();
            foreach (var entry in insertreal)
            {
                string dataArticulo = entry.Value.ToString();

                DetalleOrdenCompra articulo = JsonConvert.DeserializeObject<DetalleOrdenCompra>(dataArticulo);
                articulos.Add(articulo);
            }
            */

            issue.detalles = GridViewHelper.detalles;

            decimal importe = 0;
            GridViewHelper.detalles.ForEach((elem) =>
            {

                importe += elem.OC_NTOTVEN;
            }
            );
            issue.OC_NVENTA= importe;
            issue.OC_NIMPORT = importe;
            return UpdateModelWithDataValidation(issue, AddNewRecord);
        }

         private void AddNewRecord(OrdenCompra issue)
        {
            GridViewHelper.OrdenCompras.Add(issue);
            GridViewHelper.ClearDetalles();
         }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(OrdenCompra issue, HttpRequest request)
        {
            return UpdateModelWithDataValidation(issue, UpdateRecord);
        }
        private void UpdateRecord(OrdenCompra issue)
        {

        }
        private ActionResult UpdateModelWithDataValidation(OrdenCompra issue, Action<OrdenCompra> updateMethod)
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

        //para el nuevo forma de agregar

        public ActionResult Toolbar(string CurrentCategory = "-1")
        {
            string codigo = "0000000000001";
            if (CurrentCategory == null)
            {
                CurrentCategory = "-1";

            }
            ViewData["codigoOrden"] = CurrentCategory;
            OrdeCurrent = userNeg.find(CurrentCategory);
            if (OrdeCurrent == null)
            {
                ViewData["codigoOrden"] = CurrentCategory;
                GridViewHelper.GetDetalles();
                return PartialView("Toolbar", GridViewHelper.detalles);
            }

            return PartialView("Toolbar", userNeg.findAllDetail(OrdeCurrent.OC_CNUMORD));
        }
        public ActionResult ToolbarPartial(string codigoOrden)
        {
            string codigo = "0000000000001";
            ViewData["codigoOrden"] = codigoOrden;
            OrdeCurrent = userNeg.find(codigoOrden);
            if (OrdeCurrent == null)
            {
                GridViewHelper.GetDetalles();
                return PartialView("ToolbarPartial", GridViewHelper.detalles);
            }

            ViewData["Detalles"] = userNeg.findAllDetail(OrdeCurrent.OC_CNUMORD);
            return PartialView("ToolbarPartial", ViewData["Detalles"]);
        }

        [ValidateInput(false)]
        public ActionResult ToolbarAddNewPartial(DetalleOrdenCompra product, FormCollection dataForm)
        {

            // obtener  codarticulo
            var codArticulo = dataForm["gridLookup"];
            product.oc_ccodigo = codArticulo.ToString();
            if (ModelState.IsValid)
                SafeExecute(() => InsertProduct(product));
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var data=ViewData["codigoOrden"];
            if (data == null)
            {
                return ToolbarPartial("-1");
            }
            return ToolbarPartial(ViewData["codigoOrden"].ToString());
        }

        public void InsertProduct(DetalleOrdenCompra product)
        {
            GridViewHelper.detalles.Add(product);
        }



        [ValidateInput(false)]
        public ActionResult ToolbarUpdatePartial(DetalleOrdenCompra product)
        {
            if (ModelState.IsValid)
                SafeExecute(() => UpdateProduct(product));
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var data = ViewData["codigoOrden"];
            if (data == null)
            {
                return ToolbarPartial("-1");
            }

            return ToolbarPartial(ViewData["codigoOrden"].ToString());
        }

        public void UpdateProduct(DetalleOrdenCompra product)
        {
            // crear la logica para agregar un producto
        }

        [ValidateInput(false)]
        public ActionResult ToolbarDeletePartial(string codigo = "")
        {
            if (codigo != "")
                SafeExecute(() => DeleteProduct(codigo));
            return ToolbarPartial(ViewData["codigoOrden"].ToString());
        }

        public void DeleteProduct(string product)
        {
            // crear la logica para agregar un producto
        }


        // parte 
        public ActionResult MultiSelectDocRef(string OC_CDOCREF = "-1", FormCollection dataR=null)
        {
            if (dataR != null)
            {
                string v = dataR["gridLookupDocRef"];
                GridViewHelper.OC_CDOCREF = v;
            }
          
            ViewData["DocRef"] = userNeg.findAllDocRef();
            if (OC_CDOCREF != "-1")
                OC_CDOCREF = "";
            return PartialView("MultiSelectDocRef", new  NumDocCompras () { CTNCODIGO = OC_CDOCREF });
   
        }

    }
}