using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.neg
{
    public class ProveedorNeg
    {
        private ProveedorDao objUserDao;
        public ProveedorNeg()
        {
            objUserDao = new ProveedorDao();
        }
        public List<Proveedor> findAll()
        {
            return objUserDao.findAll();
        }
        
    }
}