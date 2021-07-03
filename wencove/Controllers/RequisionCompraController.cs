﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wencove.Code.Helpers;
using wencove.conexion.model.entity;
using wencove.conexion.model.neg;
using wencove.Model;

namespace wencove.Controllers
{
    public class RequisionCompraController : BaseController
    {
        private OrdenCompraNeg userNeg;
        private RequisicionCompraNeg requisicionNeg;
        private ProveedorNeg proveedorNeg;
        private ArticuloNeg articuloNeg;
        private AreaNeg areaNeg;
        private ResponsableCmpNeg responsable;
        private RequisicionCompra requisicionCompra;
        public RequisionCompraController()
        {
            requisicionNeg = new RequisicionCompraNeg();
            userNeg = new OrdenCompraNeg();
            articuloNeg = new ArticuloNeg();
            proveedorNeg = new ProveedorNeg();
            responsable = new ResponsableCmpNeg();
            areaNeg = new AreaNeg();


        }
        // GET: RequisionCompra
        public ActionResult Index()
        {
            return View(GridViewHelper.GetRequisionCompras());
        }
        public ActionResult DataRequisicionPartial()
        {
            return PartialView("DataRequisicionPartial", GridViewHelper.GetRequisionCompras());
        }

        [ValidateInput(false)]
        public ActionResult RequisicionAddNewPartial(RequisicionCompra product)
        {
            if (ModelState.IsValid)
                SafeExecute(() => InsertProduct(product));
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return DataRequisicionPartial();
        }

        public void InsertProduct(RequisicionCompra product)
        {

        }

        [ValidateInput(false)]
        public ActionResult RequisicionUpdatePartial(RequisicionCompra product)
        {
            if (ModelState.IsValid)
                SafeExecute(() => UpdateProduct(product));
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return DataRequisicionPartial();
        }

        public void UpdateProduct(RequisicionCompra product)
        {
            
        }
        [ValidateInput(false)]
        public ActionResult RequisicionDeletePartial(string NROREQUI = "")
        {
            if (NROREQUI != "")
                SafeExecute(() =>DeleteProduct(NROREQUI));
            return DataRequisicionPartial();
        }
        public void DeleteProduct(string NROREQUI)
        {

        }

        public ActionResult ExportTo(string customExportCommand)
        {
            switch (customExportCommand)
            {
                case "CustomExportToXLS":
                case "CustomExportToXLSX":
                    return GridViewExportDemoHelper.ExportFormatsInfo[customExportCommand](
                        GridViewToolbarHelper.ExportGridSettings, GridViewHelper.GetRequisionCompras());
                default:
                    return RedirectToAction("Toolbar");
            }
        }

        // para eñ solicitante
    
        public ActionResult MultiSelectSolicitante(string TCLAVE = "-1")
        {
           

            ViewData["Solicitante"] = userNeg.findAllSolicitud();
            if (TCLAVE == "-1")
                TCLAVE = "";
            return PartialView("MultiSelectSolicitante", new Solicitud() { TCLAVE = TCLAVE });

        }
        public ActionResult MultiSelectArea(string AREA_CODIGO = "-1")
        {
            ViewData["Area"] = areaNeg.findAll();
            if (AREA_CODIGO == "-1")
                AREA_CODIGO = "";
            return PartialView("MultiSelectArea", new Area() { AREA_CODIGO = AREA_CODIGO });

        }

        // detalle 
        public ActionResult Detail(string NROREQUI = "-1")
        {        
            if (NROREQUI == null)
            {
                NROREQUI = "-1";

            }
            ViewData["codigoOrden"] = NROREQUI;
            requisicionCompra = requisicionNeg.find(NROREQUI);
           
            if (requisicionCompra == null)
            {
                ViewData["codigoOrden"] = NROREQUI;
                GridViewHelper.GetDetalles();
                return PartialView("Detail", GridViewHelper.detalleRequisicions);
            }

            return PartialView("Detail", requisicionNeg.findAllDetail(requisicionCompra.NROREQUI));
        }
        public ActionResult DetailRequestPartial(string NROREQUI = "-1")
        {
            if (NROREQUI == null)
            {
                NROREQUI = "-1";

            }
            ViewData["codigoOrden"] = NROREQUI;
            requisicionCompra = requisicionNeg.find(NROREQUI);

            if (requisicionCompra == null)
            {
                ViewData["codigoOrden"] = NROREQUI;
                GridViewHelper.GetDetalles();
                return PartialView("DetailRequestPartial", GridViewHelper.detalleRequisicions);
            }
            GridViewHelper.detalleRequisicions = requisicionNeg.findAllDetail(requisicionCompra.NROREQUI);
            return PartialView("DetailRequestPartial", GridViewHelper.detalleRequisicions);
        }
        public ActionResult DetailRequestAddNewPartial(DetalleRequisicion product, FormCollection dataForm)
        {
            // obtener  codarticulo             
            var codArticulodata = dataForm["DXMVCEditorsValues"];

            string[] words = codArticulodata.Split(',');
            string codCostos = codArticulodata[0] + words[10] + codArticulodata[codArticulodata.Length - 1];
            codArticulodata = words[0] +","+ words[10]+ codArticulodata[codArticulodata.Length-1];
          
            Dictionary<string, object> nodes = JsonConvert.DeserializeObject<Dictionary<string, object>>(codArticulodata);
            var codArticulo = nodes["gridLookup"];
            var codCosto = nodes["gridLookupCostos"];

            JArray array = (JArray)codArticulo;
            JArray arraycosto = (JArray)codCosto;

            var description = dataForm["gridLookup"];
            product.codpro = array.First.ToString();
            product.DESCPRO = description.ToString();
            product.CENCOST = arraycosto.First.ToString();
            if (ModelState.IsValid)
                SafeExecute(() => InsertProduct(product));
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var data = ViewData["codigoOrden"];
            if (data == null)
            {
                return DetailRequestPartial("-1");
            }
            return DetailRequestPartial(ViewData["codigoOrden"].ToString());
        }
        public void InsertProduct(DetalleRequisicion product)
        {
            GridViewHelper.detalleRequisicions.Add(product);
        }

        [ValidateInput(false)]
        public ActionResult detailRequestUpdatePartial(DetalleRequisicion product, FormCollection dataForm)
        {
            var codArticulodata = dataForm["DXMVCEditorsValues"];
            Dictionary<string, object> nodes = JsonConvert.DeserializeObject<Dictionary<string, object>>(codArticulodata);
            var codArticulo = nodes["gridLookup"];

            JArray array = (JArray)codArticulo;
            var description = dataForm["gridLookup"];
            product.codpro = array.First.ToString();
            product.DESCPRO = description.ToString();
            //Request.Params
            if (ModelState.IsValid)
                SafeExecute(() => UpdateProduct(product));
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var data = ViewData["codigoOrden"];
            if (data == null)
            {
                return DetailRequestPartial("-1");
            }

            return DetailRequestPartial(ViewData["codigoOrden"].ToString());
        }
        public void UpdateProduct(DetalleRequisicion product)
        {

            DetalleRequisicion detalleOrdenCompra = GridViewHelper.detalleRequisicions.Find(element => element.codpro == product.codpro);
            detalleOrdenCompra.GLOSA = product.GLOSA;
            detalleOrdenCompra.CANTID = product.CANTID;          
            // crear la logica para agregar un producto
        }
        [ValidateInput(false)]
        public ActionResult DetailRequestDeletePartial(string codpro = "")
        {
            if (codpro != "")
                SafeExecute(() => Delete(codpro));
            var data = ViewData["codigoOrden"];
            if (data == null)
            {
                return DetailRequestPartial("-1");
            }
            return DetailRequestPartial(ViewData["codigoOrden"].ToString());
        }
        public void Delete(string product)
        {
            GridViewHelper.detalleRequisicions.Remove(GridViewHelper.detalleRequisicions.Find(element => element.codpro == product));
            // crear la logica para agregar un producto
        }

        // para el detalle
        public ActionResult MultiSelectCentroCostos(string CENCOST_CODIGO = "-1")
        {


            ViewData["centro_costos"] = requisicionNeg.findAllCentroCostos();
            if (CENCOST_CODIGO == "-1")
                CENCOST_CODIGO = "";
            return PartialView("MultiSelectCentroCostos", new CentroCosto() { CENCOST_CODIGO = CENCOST_CODIGO });

        }
        public ActionResult MultiSelectPartial(string CurrentCategory="")
        {
            if (CurrentCategory == null)
                CurrentCategory = "";
            return PartialView(new Articulo() { codigo = CurrentCategory });


        }

    }
}