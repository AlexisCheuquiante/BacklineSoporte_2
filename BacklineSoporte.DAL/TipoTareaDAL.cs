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
    public class TipoTareaDAL
    {
        public static List<BacklineSoporte.Entity.TipoTarea> ObtenerTipoTarea()
        {
            List<Entity.TipoTarea> listaTipoTarea = new List<Entity.TipoTarea>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TIPO_TAREA_GET");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int TIPO = reader.GetOrdinal("TIPO_TAREA");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.TipoTarea OBJ = new BacklineSoporte.Entity.TipoTarea();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Tipo = (String)(!reader.IsDBNull(TIPO) ? reader.GetValue(TIPO) : string.Empty);
                    //EndFields

                    listaTipoTarea.Add(OBJ);
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

            return listaTipoTarea;

        }
    }
}
