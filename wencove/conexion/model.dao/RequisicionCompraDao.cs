using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wencove.conexion.model.entity;
using wencove.Model;

namespace wencove.conexion.model.dao
{
    public class RequisicionCompraDao : Obligatorio<RequisicionCompra>
    {
        private Conexion objConexion;
        private SqlCommand comando;


        List<RequisicionCompra> OrdenCompras;
        public RequisicionCompraDao()
        {
            if (OrdenCompras == null)
            {
                OrdenCompras = new List<RequisicionCompra>();
            }

            ApplicationUser user = AuthHelper.GetLoggedInUserInfo();
            if (user != null)
            {
                objConexion = Conexion.saberEstado(user.codEmpresa + "BDCOMUN");
            }
        }
        public void create(RequisicionCompra obj)
        {
            string SQLC = "INSERT INTO requisc (nrorequi,tiporequi,codsolic,fecrequi,";
            SQLC += "glosa,area, estrequi,prioridad,FecEntrega) VALUES ('" + obj.NROREQUI + "','RQ','" + obj.CODSOLIC + "','";
            SQLC += obj.FECREQUI.ToString("yyyy-MM-dd") + "','";
            SQLC += obj.GLOSA + "','" + obj.AREA + "','P'," + obj.prioridad+"," +  verDate(obj.FecEntrega) + ")";
            try
            {
                comando = new SqlCommand(SQLC, objConexion.getCon());
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
        public void createDetail(RequisicionCompra obj)
        {
            int nextDocumet = 0;
            string item = "";
            item += "INSERT INTO REQUISD (nrorequi,tiporequi,codpro,cantid,";
            item += "estrequi,fecreque,descpro,unipro,reqitem, cencost, remaq, saldo,ESPTECNICA) VALUES";
            obj.detalles.ForEach(element => {
                ++nextDocumet;

                item += "('" + obj.NROREQUI + "',";
                item += " 'RQ','" + element.codpro + "'," + element.CANTID + ",'P',";
                item += "'" + obj.FECREQUI.ToString("yyyy-MM-dd") + "','" + element.DESCPRO + "'";
                item += ",'" + element.UNIPRO + "'," + nextDocumet + ",'" + obj.CODSOLIC + "', '" + element.REMAQ + "',";
                item +=  "" + element.SALDO + ",'" +element.ESPTECNICA+ "'),";             
            });
            item=item.Remove(item.Length - 1);
            try
            {
                comando = new SqlCommand(item, objConexion.getCon());
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


        public string verDate(DateTime date)
        {
            string datec = "null";
            if (date != DateTime.MinValue)
            {
                datec= "'"+date.ToShortDateString()+"'";
            }
            return datec;
        }
        public void updateNroRequerimiento(string nroRequerimiento)
        {
            string updateNumCompras = "UPDATE num_doccompras SET ctnnumero='" + nroRequerimiento + "' WHERE ctncodigo='RQ'";
            try
            {
                comando = new SqlCommand(updateNumCompras, objConexion.getCon());
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
        public void delete(RequisicionCompra obj)
        {
            throw new NotImplementedException();
        }

        public bool find(RequisicionCompra obj)
        {
            throw new NotImplementedException();
        }
        public RequisicionCompra find(string codigo)
        {
            string findAll = "SELECT * FROM requisc where tiporequi = 'RQ' and NROREQUI='"+ codigo+"'";
            RequisicionCompra user = null;
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                if (read.Read())
                {
                    user = new RequisicionCompra();
                    user.NROREQUI = read[0].ToString();
                    user.CODSOLIC = read[1].ToString();
                    user.FECREQUI = DateTime.Parse(read[2].ToString());
                    user.GLOSA = read[3].ToString();
                    user.AREA = read[4].ToString();
                    user.ESTREQUI = read[5].ToString();
                    user.TIPOREQUI = read[6].ToString();
                    user.prioridad = int.Parse(read[7].ToString());
                    user.FecEntrega = ParseDateTime(read[8].ToString());
                    user.flgCerrado = int.Parse(read[9].ToString());
                    user.IndAutorizado = int.Parse(read[10].ToString());
                    user.UsrAutoriza = read[11].ToString();
                    user.comrechazo = read[12].ToString();


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
            return user;
        }
        public List<RequisicionCompra> findAll()
        {

            string findAll = "SELECT * FROM requisc where tiporequi = 'RQ'";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    RequisicionCompra user = new RequisicionCompra();
                    user.NROREQUI = read[0].ToString();
                    user.CODSOLIC = read[1].ToString();                   
                    user.FECREQUI = DateTime.Parse(read[2].ToString());                   
                    user.GLOSA = read[3].ToString();
                    user.AREA = read[4].ToString();
                    user.ESTREQUI = read[5].ToString();
                    user.TIPOREQUI = read[6].ToString();
                    user.prioridad =int.Parse( read[7].ToString());
                    user.FecEntrega = ParseDateTime(read[8].ToString());
                    user.flgCerrado = int.Parse(read[9].ToString());
                    user.IndAutorizado = int.Parse(read[10].ToString());        
                    user.UsrAutoriza = read[11].ToString();
                    user.comrechazo = read[12].ToString();                  
                    OrdenCompras.Add(user);
   
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
            return OrdenCompras;
        }


        public List<RequisicionCompra> findAllPendientes()
        {

            string findAll = "SELECT * FROM requisc where tiporequi = 'RQ' and ESTREQUI='P'";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    RequisicionCompra user = new RequisicionCompra();
                    user.NROREQUI = read[0].ToString();
                    user.CODSOLIC = read[1].ToString();
                    user.FECREQUI = DateTime.Parse(read[2].ToString());
                    user.GLOSA = read[3].ToString();
                    user.AREA = read[4].ToString();
                    user.ESTREQUI = read[5].ToString();
                    user.TIPOREQUI = read[6].ToString();
                    user.prioridad = int.Parse(read[7].ToString());
                    user.FecEntrega = ParseDateTime(read[8].ToString());
                    user.flgCerrado = int.Parse(read[9].ToString());
                    user.IndAutorizado = int.Parse(read[10].ToString());
                    user.UsrAutoriza = read[11].ToString();
                    user.comrechazo = read[12].ToString();
                    OrdenCompras.Add(user);

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
            return OrdenCompras;
        }
        public List<DetalleRequisicion> findAllDetail(string NROREQUI)
        {
            List<DetalleRequisicion> listUsers = new List<DetalleRequisicion>();

           // OrdenCompra ordenCompra = OrdenCompras.Find(X => X.OC_CNUMORD == oc_cnumord);// ver si exite
            string findAll = "SELECT * FROM REQUISD WHERE tiporequi='RQ' AND REQUISD.NROREQUI = '" + NROREQUI + "'";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    DetalleRequisicion user = new DetalleRequisicion();
                    user.NROREQUI = read[0].ToString();
                    user.codpro = read[1].ToString();
                    user.DESCPRO = read[2].ToString();
                    user.UNIPRO = read[3].ToString();
                    user.CANTID = ParseDecimal(read[4].ToString());
                    user.ESTREQUI = read[5].ToString();
                    user.FECREQUE = DateTime.Parse(read[6].ToString());
                    user.REQITEM = int.Parse( read[7].ToString());
                    user.SALDO = ParseDecimal(read[8].ToString());
                    user.CENCOST = read[9].ToString();
                    user.GLOSA = read[10].ToString();
                    user.REMAQ = read[11].ToString();
                    user.TIPOREQUI =read[12].ToString();
                    user.ESPTECNICA = read[13].ToString();
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

        public List<CentroCosto> findAllCentroCostos()
        {
            List<CentroCosto> list = new List<CentroCosto>();

            // OrdenCompra ordenCompra = OrdenCompras.Find(X => X.OC_CNUMORD == oc_cnumord);// ver si exite
            string findAll = "Select CENCOST_CODIGO,CENCOST_DESCRIPCION from CENTRO_COSTOS WHERE LEN(CENCOST_CODIGO)=(3 )*2";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    CentroCosto data = new CentroCosto();
                    data.CENCOST_CODIGO = read[0].ToString();
                    data.CENCOST_DESCRIPCION = read[1].ToString();                
                    list.Add(data);
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
            return list;
        }


        public void update(RequisicionCompra obj)
        {
            throw new NotImplementedException();
        }


        public string newNroRequerimiento()
        {
            string findAll = "SELECT ctnnumero FROM num_doccompras WHERE ctncodigo='RQ'";
            NumDocCompras user = new NumDocCompras();
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                if (read.Read())
                {
                    user.CTNNUMERO = read[0].ToString();
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
            return user.CTNNUMERO;
        }
        public decimal ParseDecimal(string data)
        {
            if (data == "")
            {
                return 0;
            }
            else
            {
                return Decimal.Parse(data);
            }
        }
        public DateTime ParseDateTime(string data)
        {
            if (data == "")
            {
                return DateTime.MinValue;
            }
            else
            {
                return DateTime.Parse(data);
            }
        }
    }
}