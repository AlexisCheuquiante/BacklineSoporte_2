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
    public class MotivoContactoDAL
    {

        public static List<BacklineSoporte.Entity.MotivoContacto> ObtenerMotivoContacto(Entity.Filtro Filtro)
        {
            List<BacklineSoporte.Entity.MotivoContacto> listaMotivoContacto = new List<BacklineSoporte.Entity.MotivoContacto>();
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_MOT_MOTIVO_CONTACTO_LEER");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int MOTIVO_CONTACTO = reader.GetOrdinal("MOTIVO_CONTACTO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.MotivoContacto OBJ = new BacklineSoporte.Entity.MotivoContacto();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Motivo_Contacto = (String)(!reader.IsDBNull(MOTIVO_CONTACTO) ? reader.GetValue(MOTIVO_CONTACTO) : string.Empty);
                    //EndFields

                    listaMotivoContacto.Add(OBJ);
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



            return listaMotivoContacto;

        }
    }
}
