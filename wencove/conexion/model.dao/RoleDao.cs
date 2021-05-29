using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wencove.conexion.model.entity;
namespace wencove.conexion.model.dao
{
    class RoleDao : Obligatorio<Role>
    {

        private Conexion objConexion;
        private SqlCommand comando;

        public RoleDao()
        {
            objConexion = Conexion.saberEstado();
        }
        public void create(Role obj)
        {
            
            string create = "insert into dk_roles(id,name,description)values('" + obj.id + "','" + obj.name + "','" + obj.description  + "')";
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
        public void delete(Role obj)
        {
            string delete = "delete from dk_roles where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexion.getCon());
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
        public bool find(Role obj)
        {
            bool hayRegistros;
            string find = "select*from dk_roles where id='" + obj.id + "' ";
            try
            {
                comando = new SqlCommand(find, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                hayRegistros = read.Read();
                if (hayRegistros)
                {
                    obj.id = Convert.ToInt32(read[0].ToString());
                    obj.name = read[1].ToString();
                    obj.description = read[2].ToString();               
                }
                else
                {
                    obj.estado = 1;
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
            return hayRegistros;
        }
        public Role find(int id)
        {
            bool hayRegistros;
            string find = "select*from dk_roles where id='" + id + "' ";
            Role role = new Role();
            try
            {
                comando = new SqlCommand(find, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                hayRegistros = read.Read();
                if (hayRegistros)
                {
                    role.id = Convert.ToInt32(read[0].ToString());
                    role.name = read[1].ToString();
                    role.description = read[2].ToString();                
                    return role;
                }
                else
                {
                    role.estado = 1;
                    return null;
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
            return null;
        }
        public List<Role> findAll()
        {
            List<Role> listUsers = new List<Role>();

            string findAll = "select*from dk_roles";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Role user = new Role();
                    user.id = Convert.ToInt32(read[0].ToString());
                    user.name = read[1].ToString();
                    user.description = read[2].ToString();
                   
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
        public void update(Role obj)
        {
          
            string update = "update  dk_roles set username='" + obj.name + "',password='" + obj.description +  "' where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(update, objConexion.getCon());
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
    }
}