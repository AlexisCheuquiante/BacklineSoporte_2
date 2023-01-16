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
    public class PrioridadDAL
    {
        public static List<BacklineSoporte.Entity.Prioridad> ObtenerTipoPrioridad()
        {
            List<Entity.Prioridad> listaTipoPrioridades = new List<Entity.Prioridad>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_PRIO_PRIORIDAD_GET");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int TIPO_PRIORIDAD = reader.GetOrdinal("TIPO_PRIORIDAD");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Prioridad OBJ = new BacklineSoporte.Entity.Prioridad();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.PrioridadStr = (String)(!reader.IsDBNull(TIPO_PRIORIDAD) ? reader.GetValue(TIPO_PRIORIDAD) : string.Empty);
                    //EndFields

                    listaTipoPrioridades.Add(OBJ);
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

            return listaTipoPrioridades;

        }
    }
}
