using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.neg
{
    public class EmpresaNeg
    {
        EmpresaDao objRoleDao;
        public EmpresaNeg()
        {
            objRoleDao = new EmpresaDao();
        }

        public List<Empresa> findAll()
        {
            return objRoleDao.findAll();
        }
    }
}