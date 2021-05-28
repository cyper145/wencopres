
using System.Data.SqlClient;
namespace wencove.conexion.model.dao
{
    class Conexion
    {
        //singleton
        private static Conexion objConexion = null;
        private SqlConnection con;

        private Conexion()
        {
            con = new SqlConnection("Data Source=DESKTOP-6OG4V32\\SQLEXPRESS;Initial Catalog=BDWENCO;Integrated Security=True");
        }

        public static Conexion saberEstado()
        {
            if (objConexion == null)
            {
                objConexion = new Conexion();
            }
            return objConexion;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void cerrarConexion()
        {
            objConexion = null;
        }
    }
}
