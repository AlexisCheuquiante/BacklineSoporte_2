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
    public class TipoDocumentoConsultaDAL
    {
        public static List<BacklineSoporte.Entity.TipoDocumentoConsulta> ObtenerTipoDocumetoConsulta()
        {
            List<Entity.TipoDocumentoConsulta> listaTiposDocumentos = new List<Entity.TipoDocumentoConsulta>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_TIDO_TIPO_DOCUMENTO_CONSULTA_LEER");



            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int DESCRIPCION = reader.GetOrdinal("DESCRIPCION");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.TipoDocumentoConsulta OBJ = new BacklineSoporte.Entity.TipoDocumentoConsulta();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Descripcion = (String)(!reader.IsDBNull(DESCRIPCION) ? reader.GetValue(DESCRIPCION) : string.Empty);
                    //EndFields

                    listaTiposDocumentos.Add(OBJ);
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

            return listaTiposDocumentos;

        }
    }
}
