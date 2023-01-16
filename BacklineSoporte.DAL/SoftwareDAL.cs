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
    public class SoftwareDAL
    {
        public static List<BacklineSoporte.Entity.Software> ObtenerTipoSoftware()
        {
            List<Entity.Software> listaTiposSoftware = new List<Entity.Software>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TISO_TIPO_SOFTWARE_GET");

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int SOFTWARE = reader.GetOrdinal("SOFTWARE");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Software OBJ = new BacklineSoporte.Entity.Software();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.TipoSoftware = (String)(!reader.IsDBNull(SOFTWARE) ? reader.GetValue(SOFTWARE) : string.Empty);
                    //EndFields

                    listaTiposSoftware.Add(OBJ);
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

            return listaTiposSoftware;

        }
    }
}
