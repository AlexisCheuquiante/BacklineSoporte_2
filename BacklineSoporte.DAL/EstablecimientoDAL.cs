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
    public class EstablecimientoDAL
    {
        public static void InsertarEstablecimiento(BacklineSoporte.Entity.Establecimiento establecimiento)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EST_ESTABLECIMIENTO_INS");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, establecimiento.Id);
            db.AddInParameter(dbCommand, "FICH_ID", DbType.Int32, establecimiento.Fich_Id);
            db.AddInParameter(dbCommand, "NOMBRE_ESTABLECIMIENTO", DbType.String, establecimiento.NombreEstablecimiento != "" ? establecimiento.NombreEstablecimiento.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "AFECTA_IVA", DbType.Byte, establecimiento.BE_Afecta_IVA == true ? 1 : 0);
            db.AddInParameter(dbCommand, "ELIMINADO", DbType.Byte, establecimiento.Eliminado == true ? 1 : 0);

            db.ExecuteNonQuery(dbCommand);
        }
        public static List<BacklineSoporte.Entity.Establecimiento> ObtenerEstablecimientos(Entity.Filtro filtro)
        {
            List<Entity.Establecimiento> listaEstablecimientos = new List<Entity.Establecimiento>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EST_ESTABLECIMIENTO_LEER");

            db.AddInParameter(dbCommand, "FICH_ID", DbType.Int32, filtro.Ficha_Cliente_Id != 0 ? filtro.Ficha_Cliente_Id : (object)null);
            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);



            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int NOMBRE_ESTABLECIMIENTO = reader.GetOrdinal("NOMBRE_ESTABLECIMIENTO");
                int AFECTA_IVA = reader.GetOrdinal("AFECTA_IVA");
                int RAZON_SOCIAL = reader.GetOrdinal("RAZON_SOCIAL");
                

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Establecimiento OBJ = new BacklineSoporte.Entity.Establecimiento();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Razon_Social = (String)(!reader.IsDBNull(RAZON_SOCIAL) ? reader.GetValue(RAZON_SOCIAL) : string.Empty);
                    OBJ.NombreEstablecimiento = (String)(!reader.IsDBNull(NOMBRE_ESTABLECIMIENTO) ? reader.GetValue(NOMBRE_ESTABLECIMIENTO) : string.Empty);
                    OBJ.BE_Afecta_IVA = (bool)(reader.IsDBNull(AFECTA_IVA) == false ? reader.GetValue(AFECTA_IVA) : false);
                    //EndFields

                    listaEstablecimientos.Add(OBJ);
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

            return listaEstablecimientos;

        }
        public static void EliminarEstablecimiento(int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EST_ESTABLECIMIENTO_DEL");

            db.AddInParameter(dbCommand, "@ID", DbType.Int32, id);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
