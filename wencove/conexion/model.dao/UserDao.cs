using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.dao
{
     class UserDao: Obligatorio<User>
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public UserDao()
        {
            objConexion = Conexion.saberEstado();
        }

        public void create(User obj)
        {
            string create = "insert into dk_users(id,username,password,email, photo,created_at,updated_at,isactive,last_login)values('" + obj.id + "','" + obj.username + "','" + obj.password + "','" + obj.email + "','" + obj.photo + "','" + obj.created_at + "','" + obj.update_at + "','" + obj.isactive + "','" + obj.lastlogin + "')";
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

        public void delete(User obj)
        {
            throw new NotImplementedException();
        }

        public bool find(User user)
        {
            bool hayRegistros;
            string find = "select*from dk_users where id='" + user.id + "' ";

            try
            {
                comando = new SqlCommand(find, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                hayRegistros = read.Read();
                if (hayRegistros)
                {
                    user.id = Convert.ToInt32(read[0].ToString());
                    user.username = read[1].ToString();
                    user.password = read[2].ToString();
                    user.email = read[3].ToString();
                    user.photo = read[4].ToString();
                    user.created_at = DateTime.Parse(read[5].ToString());
                    user.update_at = DateTime.Parse(read[6].ToString());
                    user.isactive = Convert.ToInt32(read[8].ToString());
                    user.lastlogin = DateTime.Parse(read[9].ToString());
                    user.estado = 99;
                }
                else
                {
                    user.estado = 1;
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

        public List<User> findAll()
        {
            List<User> listUsers = new List<User>();

            string findAll = "select*from dk_users";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    User user = new User();
                    user.id = Convert.ToInt32(read[0].ToString());
                    user.username = read[1].ToString();
                    user.password = read[2].ToString();
                    user.email = read[3].ToString();
                    user.photo = read[4].ToString();
                    user.created_at = DateTime.Parse(read[5].ToString());
                    user.update_at = DateTime.Parse(read[6].ToString());
                    user.isactive = Convert.ToInt32(read[8].ToString());
                    user.lastlogin = DateTime.Parse(read[9].ToString());
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
        public void update(User obj)
        {
            string update = "update  dk_users set username='" + obj.username + "',password='" + obj.password + "',email='" + obj.email + "',updated_at='" + obj.update_at + "',isactive='" + obj.isactive + "',last_login='" + obj.lastlogin + "' where idAlumno='" + obj.id + "'";
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
