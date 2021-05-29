using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wencove.conexion.model.entity;

namespace wencove.conexion.model.dao
{
      public class UserDao: Obligatorio<User>
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public UserDao()
        {
            objConexion = Conexion.saberEstado();
        }

        public void create(User obj)
        {

            string creat = obj.created_at.ToString("MM/dd/yyyy HH:mm:ss");
            string updte = obj.update_at.ToString("MM/dd/yyyy HH:mm:ss");
            string last = obj.lastlogin.ToString("MM/dd/yyyy HH:mm:ss");

            string create = "insert into dk_users(id,username,password,email, photo,created_at,updated_at,isactive,last_login)values('" + obj.id + "','" + obj.username + "','" + obj.password + "','" + obj.email + "','" + obj.photo + "','" + creat + "','" + updte + "','" + obj.isactive + "','" + last + "')";
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
            string delete = "delete from dk_users where id='" + obj.id + "'";
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



        public User find(int id)
        {
            bool hayRegistros;
            string find = "select*from dk_users where id='" + id + "' ";
            User user = new User();
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
                    return user;
                }
                else
                {
                    user.estado = 1;
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
            string updte = obj.update_at.ToString("MM/dd/yyyy HH:mm:ss");
            string update = "update  dk_users set username='" + obj.username + "',password='" + obj.password + "',email='" + obj.email + "',isactive='" + obj.isactive + "',updated_at='" + updte + "' where id='" + obj.id + "'";
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
        public static bool tienePrograma(int user_id, string programa)
        {
            Conexion objConexion;
            SqlCommand comando;
            objConexion = Conexion.saberEstado();
            string permisos = "select*from dk_users ";
            try
            {
                comando = new SqlCommand(permisos, objConexion.getCon());
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

            return true;
        }
        public static bool tieneModulo(int user_id, string programa)
        {
            Conexion objConexion;
            SqlCommand comando;
            objConexion = Conexion.saberEstado();
            string permisos = "select*from dk_users ";
            try
            {
                comando = new SqlCommand(permisos, objConexion.getCon());
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

            return true;
        }

    }
}
