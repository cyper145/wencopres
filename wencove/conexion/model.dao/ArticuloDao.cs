using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wencove.conexion.model.entity;
using wencove.Model;

namespace wencove.conexion.model.dao
{
    public class ArticuloDao : Obligatorio<Articulo>
    {

        private Conexion objConexion;
        private SqlCommand comando;

        public ArticuloDao()
        {
            ApplicationUser user =   AuthHelper.GetLoggedInUserInfo();

            objConexion = Conexion.saberEstado( user.Empresa+ "BDCOMUN");
        }

        public void create(Articulo obj)
        {


            //   string create = "insert into dk_users(ACODIGO,ACODIGO2,ADESCRI,ADESCRI2, UMREFERENCIA,AFAMILIA,AMODELO,AGRUPO,APESO,ATIPO,AUSER, AESTADO,AFECHA,AFSERIE,AFLOTE,ACODMON,AIGVPOR,AFLAGIGV,AMARCA,ACOLOR,ATALLA,AFOTO,ACOMENTA,AFSTOCK,ACLASIFICACION )values('" + obj.id + "','" + obj.username + "','" + obj.password + "','" + obj.email + "','" + obj.photo + "','" + creat + "','" + updte + "','" + obj.isactive + "','" + last + "','" + obj.rol_id + "')";

            string create="";
             
            
            try
            {
                comando = new SqlCommand(create, objConexion.getCon());
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
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
        }

        public void delete(Articulo obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Articulo obj)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> findAll()
        {
            throw new NotImplementedException();
        }

        public void update(Articulo obj)
        {
            throw new NotImplementedException();
        }
    }
}