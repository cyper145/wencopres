using DevExpress.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using wencove.conexion.model.entity;
using wencove.conexion.model.neg;

namespace wencove.Model
{
    public static class GridViewHelper
    {


        public  static List<DetalleOrdenCompra> detalles = new List<DetalleOrdenCompra>();

        public static List<OrdenCompra> OrdenCompras = new List<OrdenCompra>();

        public static List<DetalleRequisicion> detalleRequisicions = new List<DetalleRequisicion>();
        public static List<RequisicionCompra> requisicionCompras = new List<RequisicionCompra>();
        public static string OC_CDOCREF ="";

        public static DateRangePickerModel dateRange = new DateRangePickerModel();
        public static void GetDetalles()
        {
            if (detalles == null)
            {
                detalles = new List<DetalleOrdenCompra>();
            }

        }
        public static void ClearDetalles()
        {
           
                detalles = new List<DetalleOrdenCompra>();    
        }
        public static void GetOrdenCompras()
        {
            if (OrdenCompras == null)
            {
                OrdenCompras = new List<OrdenCompra>();
            }
        }

        public static void GetDetallesRequision()
        {
            if (detalleRequisicions == null)
            {
                detalleRequisicions = new List<DetalleRequisicion>();
            }

        }
        public static void ClearDetallesRequision()
        {

            detalleRequisicions = new List<DetalleRequisicion>();
        }
        public static void GetRequisionComprasObjetc()
        {
            if (requisicionCompras == null)
            {
                requisicionCompras = new List<RequisicionCompra>();
            }
        }

        public static List<RequisicionCompra> GetRequisionCompras()
        {
            RequisicionCompraNeg userNeg = new RequisicionCompraNeg();
            return userNeg.findAll();
        }
        public static List<CentroCosto> GetCentroCostos()
        {
            RequisicionCompraNeg userNeg = new RequisicionCompraNeg();
            return userNeg.findAllCentroCostos();
        }
        public static List<Issue> GetIssues()
        {
            UserNeg userNeg = new UserNeg();
            return DataProvider.GetIssues();
        }

        public static List<User> getUsers()
        {
            UserNeg userNeg = new UserNeg();
            return userNeg.findAll();
        }

        public static List<Empresa> getEmpresas()
        {
            EmpresaNeg userNeg = new EmpresaNeg();
            return userNeg.findAll();
        }
        public static List<Proveedor> getProveedor()
        {
            ProveedorNeg userNeg = new ProveedorNeg();
            return userNeg.findAll();
        }

        public static List<Articulo> getArticulos()
        {
            ArticuloNeg  userNeg = new ArticuloNeg();
            return userNeg.findAll();
        }
        public static List<Solicitud> GetSolitud()
        {
            OrdenCompraNeg userNeg = new OrdenCompraNeg();
            return userNeg.findAllSolicitud();
        }
        public static List<FormaPago> GetFormaPago()
        {
            OrdenCompraNeg userNeg = new OrdenCompraNeg();
            return userNeg.findAllFormasPago();
        }

        public static List<Contact> GetCustomers()
        {
            return DataProvider.GetContacts();
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(User issue)
        {
            UserNeg userNeg = new UserNeg();
            userNeg.create(issue);
        }

        public static void UpdateRecord(User issue)
        {
            UserNeg userNeg = new UserNeg();
            userNeg.update(issue);
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            UserNeg userNeg = new UserNeg();
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            userNeg.DeleteUser(selectedIds);
        }
    }
}