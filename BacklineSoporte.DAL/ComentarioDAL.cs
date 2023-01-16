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
    public class ComentarioDAL
    {
        public static List<Entity.Comentario> ObtenerComentario(Entity.Comentario comentarioFiltro)
        {
            List<Entity.Comentario> listaRetorno = new List<Entity.Comentario>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_REL_COMENTARIO_REQUERIMIENTO_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, comentarioFiltro.Id != 0 ? comentarioFiltro.Id : (object)null);
            db.AddInParameter(dbCommand, "REQUE_ID", DbType.Int32, comentarioFiltro.Requerimiento_Id != 0 ? comentarioFiltro.Requerimiento_Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int REQUE_ID = reader.GetOrdinal("REQUE_ID");
                int COMENTARIO = reader.GetOrdinal("COMENTARIO");
                int USR_CREADOR_ID = reader.GetOrdinal("USR_CREADOR_ID");
                int NOMBRE = reader.GetOrdinal("NOMBRE");

                while (reader.Read())
                {
                    Entity.Comentario comentario = new Entity.Comentario();
                    comentario.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    comentario.Requerimiento_Id = (int)(reader.IsDBNull(REQUE_ID) == false ? reader.GetValue(REQUE_ID) : 0);
                    comentario.ComentarioObs = (string)(reader.IsDBNull(COMENTARIO) == false ? reader.GetValue(COMENTARIO) : "");
                    comentario.UsuarioCreador_Id = (int)(reader.IsDBNull(USR_CREADOR_ID) == false ? reader.GetValue(USR_CREADOR_ID) : 0);
                    comentario.NombreCreador = (string)(reader.IsDBNull(NOMBRE) == false ? reader.GetValue(NOMBRE) : "");

                    listaRetorno.Add(comentario);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }

        public static void GuardaComentario(BacklineSoporte.Entity.Comentario comentario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_COMENTARIO_REQUERIMIENTO_INS");

            db.AddInParameter(dbCommand, "REQUE_ID", DbType.Int32, comentario.Requerimiento_Id);
            db.AddInParameter(dbCommand, "USR_CREADOR_ID", DbType.Int32, comentario.UsuarioCreador_Id);
            db.AddInParameter(dbCommand, "COMENTARIO", DbType.String, comentario.ComentarioObs.ToUpper());
            db.AddInParameter(dbCommand, "ELIMINADO", DbType.Byte, comentario.Eliminado == true ? 1 : 0);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
