using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace BacklineSoporte.DAL
{
    public class EmpresaDAL
    {
        public static List<BacklineSoporte.Entity.Empresa> ObtenerEmpresas()
        {
            List<Entity.Empresa> listaEmpresas = new List<Entity.Empresa>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPCO_EMP_EMPRESAS_CONSULTA_LEER");



            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int ALIAS = reader.GetOrdinal("ALIAS");
                int TEXTO_AVISO = reader.GetOrdinal("TEXTO_AVISO");
                int INTERVALO_AVISO_CORTE = reader.GetOrdinal("INTERVALO_AVISO_CORTE");
                int MOSTRAR_AVISO_NO_PAGO = reader.GetOrdinal("MOSTRAR_AVISO_NO_PAGO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Empresa OBJ = new BacklineSoporte.Entity.Empresa();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.NombreEmpresa = (String)(!reader.IsDBNull(ALIAS) ? reader.GetValue(ALIAS) : string.Empty);
                    OBJ.TextoAviso = (String)(!reader.IsDBNull(TEXTO_AVISO) ? reader.GetValue(TEXTO_AVISO) : string.Empty);
                    OBJ.IntervaloTiempo = (int)(!reader.IsDBNull(INTERVALO_AVISO_CORTE) ? reader.GetValue(INTERVALO_AVISO_CORTE) : 0);
                    OBJ.MostrarAviso = (bool)(!reader.IsDBNull(MOSTRAR_AVISO_NO_PAGO) ? reader.GetValue(MOSTRAR_AVISO_NO_PAGO) : false);
                    //EndFields

                    listaEmpresas.Add(OBJ);
                }
            }
            catch (Exception ex)
            {
                //GlobalesDAO.InsertErrores(ex);
                throw ex;
            }
            finally
            {
                reader.Close();
            }

            //if (listaUsuario != null & listaUsuario.Count == 1)
            //{
            //    listaUsuario[0].Roles = DAL.RelacionUsrRolDAL.ObtenerRolUsuario(listaUsuario[0].Id);
            //}

            return listaEmpresas;

        }
        public static List<Entity.Empresa> ObtenerAviso(Entity.Filtro Filtro)
        {
            List<Entity.Empresa> lista = new List<Entity.Empresa>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_AVISO_CORTE_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int TEXTO_AVISO = reader.GetOrdinal("TEXTO_AVISO");

                while (reader.Read())
                {
                    Entity.Empresa requerimiento = new Entity.Empresa();
                    requerimiento.TextoAviso = (string)(reader.IsDBNull(TEXTO_AVISO) == false ? reader.GetValue(TEXTO_AVISO) : "");

                    lista.Add(requerimiento);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return lista;
        }
        public static BacklineSoporte.Entity.Empresa UpdateMensajeCorte(BacklineSoporte.Entity.Empresa aviso)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_UPDATE_AVISO_COBRO");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, aviso.Id != 0 ? aviso.Id : (object)null);
            db.AddInParameter(dbCommand, "INTERVALO_AVISO_CORTE", DbType.Int32, aviso.IntervaloTiempo != 0 ? aviso.IntervaloTiempo : (object)null);
            db.AddInParameter(dbCommand, "TEXTO_AVISO", DbType.String, aviso.TextoAviso != "" ? aviso.TextoAviso.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "MOSTRAR_AVISO_NO_PAGO", DbType.Byte, aviso.MostrarAviso == true ? 1 : 0);

            db.ExecuteNonQuery(dbCommand);

            return aviso;
        }
        public static List<BacklineSoporte.Entity.Empresa> ObtenerEmpresasEdit(Entity.Filtro Filtro)
        {
            List<Entity.Empresa> listaEmpresas = new List<Entity.Empresa>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPCO_EMP_EMPRESAS_CONSULTA_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int ALIAS = reader.GetOrdinal("ALIAS");
                int TEXTO_AVISO = reader.GetOrdinal("TEXTO_AVISO");
                int INTERVALO_AVISO_CORTE = reader.GetOrdinal("INTERVALO_AVISO_CORTE");
                int MOSTRAR_AVISO_NO_PAGO = reader.GetOrdinal("MOSTRAR_AVISO_NO_PAGO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Empresa OBJ = new BacklineSoporte.Entity.Empresa();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.NombreEmpresa = (String)(!reader.IsDBNull(ALIAS) ? reader.GetValue(ALIAS) : string.Empty);
                    OBJ.TextoAviso = (String)(!reader.IsDBNull(TEXTO_AVISO) ? reader.GetValue(TEXTO_AVISO) : string.Empty);
                    OBJ.IntervaloTiempo = (int)(!reader.IsDBNull(INTERVALO_AVISO_CORTE) ? reader.GetValue(INTERVALO_AVISO_CORTE) : 0);
                    OBJ.MostrarAviso = (bool)(!reader.IsDBNull(MOSTRAR_AVISO_NO_PAGO) ? reader.GetValue(MOSTRAR_AVISO_NO_PAGO) : false);
                    //EndFields

                    listaEmpresas.Add(OBJ);
                }
            }
            catch (Exception ex)
            {
                //GlobalesDAO.InsertErrores(ex);
                throw ex;
            }
            finally
            {
                reader.Close();
            }

            //if (listaUsuario != null & listaUsuario.Count == 1)
            //{
            //    listaUsuario[0].Roles = DAL.RelacionUsrRolDAL.ObtenerRolUsuario(listaUsuario[0].Id);
            //}

            return listaEmpresas;

        }
    }
}
