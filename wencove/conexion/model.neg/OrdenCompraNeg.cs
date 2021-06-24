using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.neg
{
    public class OrdenCompraNeg
    {

        private OrdenCompraDao objUserDao;
        public OrdenCompraNeg()
        {
            objUserDao = new OrdenCompraDao();
        }
        public List<OrdenCompra> findAll()
        {
            return objUserDao.findAll();
        }
        public List<DetalleOrdenCompra> findAllDetail( string OC_CNUMORD)
        {
            return objUserDao.findAllDetail(OC_CNUMORD);
        }
        public List<FormaPago> findAllFormasPago()
        {
            return objUserDao.findAllFormasPago();
        }
        public List<Solicitud> findAllSolicitud()
        {
            return objUserDao.findAllSolitud();
        }
        public OrdenCompra find(string id)
        {
            return objUserDao.find(id);
        }


    }
}