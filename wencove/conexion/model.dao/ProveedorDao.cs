﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wencove.conexion.model.entity;
using wencove.Model;

namespace wencove.conexion.model.dao
{
    public class ProveedorDao : Obligatorio<Proveedor>
    {


        private Conexion objConexion;
        private SqlCommand comando;

        public ProveedorDao()
        {
            ApplicationUser user = AuthHelper.GetLoggedInUserInfo();
            if (user != null)
            {
                objConexion = Conexion.saberEstado(user.codEmpresa + "BDCOMUN");
            }
        }
        public void create(Proveedor obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Proveedor obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Proveedor obj)
        {
            throw new NotImplementedException();
        }

        public List<Proveedor> findAll()
        {
            List<Proveedor> listArticulos = new List<Proveedor>();
            string findAll = "SELECT prvccodigo,prvcnombre,prvcdirecc,prvctelef1,PRVCRUC FROM maeprov ";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.PRVCCODIGO = read[0].ToString();
                    proveedor.PRVCNOMBRE = read[1].ToString();
                    proveedor.PRVCDIRECC = read[2].ToString();
                    proveedor.PRVCTELEF1 = read[3].ToString(); 
                    proveedor.PRVCRUC= read[4].ToString();
                    listArticulos.Add(proveedor);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
            return listArticulos;
        }

        public void update(Proveedor obj)
        {
            throw new NotImplementedException();
        }
    }
}