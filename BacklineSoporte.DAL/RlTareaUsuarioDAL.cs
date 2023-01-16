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
    public class RlTareaUsuarioDAL
    {
        public static void GuardarRLTareaUsuario(BacklineSoporte.Entity.RlTareaUsuario rlTareaUsuario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_TAREA_USUARIO_INS");

            db.AddInParameter(dbCommand, "TAR_ID", DbType.Int32, rlTareaUsuario.Tar_Id);
            db.AddInParameter(dbCommand, "USR_ID", DbType.String, rlTareaUsuario.Usr_Id);
            db.AddInParameter(dbCommand, "CONTADOR", DbType.Int32, rlTareaUsuario.Contador);

            db.ExecuteNonQuery(dbCommand);
        }

        public static List<Entity.RlTareaUsuario> ObtenerRlUsuarioTarea(Entity.Filtro filtro)
        {
            List<BacklineSoporte.Entity.RlTareaUsuario> listaRetorno = new List<BacklineSoporte.Entity.RlTareaUsuario>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_USUARIO_TAREA_LEER");

            db.AddInParameter(dbCommand, "TAR_ID", DbType.Int32, filtro.Tar_Id);
            
            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int TAR_ID = reader.GetOrdinal("TAR_ID");
                int USR_ID = reader.GetOrdinal("USR_ID");
                int NOMBRE = reader.GetOrdinal("NOMBRE");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.RlTareaUsuario obj = new BacklineSoporte.Entity.RlTareaUsuario();
                    //BeginFields
                    obj.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    obj.Tar_Id = (int)(!reader.IsDBNull(TAR_ID) ? reader.GetValue(TAR_ID) : 0);
                    obj.Usr_Id = (int)(!reader.IsDBNull(USR_ID) ? reader.GetValue(USR_ID) : 0);
                    obj.Nombre = (String)(!reader.IsDBNull(NOMBRE) ? reader.GetValue(NOMBRE) : string.Empty);
                    //EndFields

                    listaRetorno.Add(obj);
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

            return listaRetorno;

        }
    }
}
