using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.neg
{
    public class RequisicionCompraNeg
    {

        private RequisicionCompraDao objUserDao;
        public RequisicionCompraNeg()
        {
            objUserDao = new RequisicionCompraDao();
        }
        public List<RequisicionCompra> findAll()
        {
            return objUserDao.findAll();
        }
        public List<DetalleRequisicion> findAllDetail(string NROREQUI)
        {
            return objUserDao.findAllDetail(NROREQUI);

        }
        public RequisicionCompra find(string codigo)
        {
            return objUserDao.find(codigo);
        }

        public List<CentroCosto> findAllCentroCostos()
        {
            return objUserDao.findAllCentroCostos();
        }
    }
}