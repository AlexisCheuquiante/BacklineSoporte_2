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
    public class PrioridadTareaDAL
    {
        public static List<BacklineSoporte.Entity.PrioridadTarea> ObtenerPrioridadTarea()
        {
            List<Entity.PrioridadTarea> listaPrioridadTarea = new List<Entity.PrioridadTarea>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_PRIO_PRIORIDAD_TAREA_GET");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int PRIORIDAD = reader.GetOrdinal("PRIORIDAD");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.PrioridadTarea OBJ = new BacklineSoporte.Entity.PrioridadTarea();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Prioridad = (String)(!reader.IsDBNull(PRIORIDAD) ? reader.GetValue(PRIORIDAD) : string.Empty);
                    //EndFields

                    listaPrioridadTarea.Add(OBJ);
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

            return listaPrioridadTarea;

        }
    }
}
