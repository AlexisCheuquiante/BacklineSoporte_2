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
    public class ModuloDAL
    {
        public static void GuardaModulo(BacklineSoporte.Entity.Modulo modulo)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_MOD_MODULOS_INS");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, modulo.Id);
            db.AddInParameter(dbCommand, "MODULO", DbType.String, modulo.ModuloStr);

            db.ExecuteNonQuery(dbCommand);
        }
        public static List<BacklineSoporte.Entity.Modulo> ObtenerModulos(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.Modulo> listaModulos = new List<BacklineSoporte.Entity.Modulo>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_MOD_MODULOS_GET");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int MODULO = reader.GetOrdinal("MODULO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Modulo OBJ = new BacklineSoporte.Entity.Modulo();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.ModuloStr = (String)(!reader.IsDBNull(MODULO) ? reader.GetValue(MODULO) : string.Empty);
                    //EndFields

                    listaModulos.Add(OBJ);
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



            return listaModulos;

        }
        public static void EliminarModulo(int idModulo)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_MOD_MODULOS_DEL");

            db.AddInParameter(dbCommand, "@ID", DbType.Int32, idModulo);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
