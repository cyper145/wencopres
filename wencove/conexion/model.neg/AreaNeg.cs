﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.neg
{
    public class AreaNeg
    {
        AreaDao objAreaDao;
        public AreaNeg()
        {
            objAreaDao = new AreaDao();
        }
        public List<Area> findAll()
        {
            return objAreaDao.findAll();
        }
        public void create(Area objUser)
        {
           
            //validar Nombre Alumno estado=2
            string nombre = objUser.AREA_CODIGO;
            if (nombre == null)
            {          
                return;
            }
            objAreaDao.create(objUser);
        }

        public bool find(Area objAlumno)
        {
            return objAreaDao.find(objAlumno);
        }
        public Area find(string codigo)
        {
            return objAreaDao.find(codigo);
        }

        public void update(Area objUser)
        {
            string nombre = objUser.AREA_CODIGO;
            if (nombre == null)
            {
                return;
            }        
            objAreaDao.update(objUser);

        }

        public void delete(Area obj)
        {
            bool verificacion;
            Area objUserAux = new Area();
            objUserAux.AREA_CODIGO = obj.AREA_CODIGO;
            verificacion = objAreaDao.find(objUserAux);
            if (!verificacion)
            {
                return;
            }
            objAreaDao.delete(obj);
        }
        public void delete(string AREA_CODIGO)
        {
            bool verificacion;
            Area objUserAux = new Area();
            objUserAux.AREA_CODIGO =AREA_CODIGO;
            verificacion = objAreaDao.find(objUserAux);
            if (!verificacion)
            {
                return;
            }
            objAreaDao.delete(AREA_CODIGO);
        }

    }
}