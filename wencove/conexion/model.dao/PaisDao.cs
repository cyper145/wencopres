﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wencove.conexion.model.entity;
using wencove.Model;

namespace wencove.conexion.model.dao
{
    public class PaisDao : Obligatorio<Pais>
    {

        private Conexion objConexion;
        private SqlCommand comando;

        public PaisDao()
        {
            ApplicationUser user = AuthHelper.GetLoggedInUserInfo();

            objConexion = Conexion.saberEstado(user.codEmpresa + "BDCOMUN");
        }
        public void create(Pais obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Pais obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Pais obj)
        {
            throw new NotImplementedException();
        }

        public List<Pais> findAll()
        {
            List<Pais> listPais = new List<Pais>();
            string str_sql = "SELECT [COD_PAIS],[NOM_PAIS] FROM pais ORDER BY [NOM_PAIS]";

            try
            {
                comando = new SqlCommand(str_sql, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Pais articulo = new Pais();
                    articulo.codigo = read[0].ToString();
                    articulo.nombrePais = read[1].ToString();
                    listPais.Add(articulo);
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

            return listPais;
        }

        public void update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}