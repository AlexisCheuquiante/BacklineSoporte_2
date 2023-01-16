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
    public class EstadoRequeDAL
    {
        public static List<BacklineSoporte.Entity.EstadoRequerimiento> ObtenerEstadoReque()
        {
            List<Entity.EstadoRequerimiento> listaEstado = new List<Entity.EstadoRequerimiento>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EST_ESTADO_REQUE_LEER");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int ESTADO = reader.GetOrdinal("ESTADO_REQUE");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.EstadoRequerimiento OBJ = new BacklineSoporte.Entity.EstadoRequerimiento();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.EstadoReque = (String)(!reader.IsDBNull(ESTADO) ? reader.GetValue(ESTADO) : string.Empty);
                    //EndFields

                    listaEstado.Add(OBJ);
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

            return listaEstado;

        }
    }
}
