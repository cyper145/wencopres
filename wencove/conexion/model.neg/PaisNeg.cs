﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wencove.conexion.model.dao;
using wencove.conexion.model.entity;
namespace wencove.conexion.model.neg
{
    public class PaisNeg
    {
        private PaisDao objUserDao;
        public PaisNeg()
        {
            objUserDao = new PaisDao();
        }
        public List<Pais> findAll()
        {
            return objUserDao.findAll();
        }
    }
}