﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.dao
{
    public class EmpresaDao
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public EmpresaDao()
        {
            objConexion = Conexion.saberEstado();
        }

        public List<Empresa> findAll()
        {
            List<Empresa> listUsers = new List<Empresa>();

            string findAll = "select*from EMPRESA";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Empresa user = new Empresa();              
                    user.codigoEmpresa = read[0].ToString();
                    user.RazonSocial = read[1].ToString();

                    listUsers.Add(user);
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
            return listUsers;
        }
    }
}