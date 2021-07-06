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
        public List<RequisicionCompra> findAllPendientes()
        {
            return objUserDao.findAllPendientes();
        }

        public RequisicionCompra find(string codigo)
        {
            return objUserDao.find(codigo);
        }

        public List<CentroCosto> findAllCentroCostos()
        {
            return objUserDao.findAllCentroCostos();
        }
        public string nextNroDocument()
        {
            string last = objUserDao.newNroRequerimiento();
            int nextDocumet = 0;
            if (last != "")
            {
                nextDocumet = int.Parse(last) + 1;
            }
            string fmt = "0000000000.##";
            string next = nextDocumet.ToString(fmt);
            return next;
        }

        public void create(RequisicionCompra objUser)
        {
            objUserDao.updateNroRequerimiento(objUser.NROREQUI);
            objUserDao.create(objUser);
            objUserDao.createDetail(objUser);
        }
    }
}