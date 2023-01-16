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
    public class DocumentoConsultaDAL
    {
        public static List<BacklineSoporte.Entity.DocumentoConsulta> ObtenerDocumentosConsulta(Entity.Filtro filtro)
        {
            List<Entity.DocumentoConsulta> listaDocumentosConsulta = new List<Entity.DocumentoConsulta>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FACT_FACTURAS_SOPORTE_LEER");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, filtro.EmpId != 0 ? filtro.EmpId : (object)null);
            db.AddInParameter(dbCommand, "TIPO_FACTURA", DbType.Int16, filtro.TipoDocumentoConsulta != 0 ? filtro.TipoDocumentoConsulta : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int FECHA = reader.GetOrdinal("FECHA");
                int NUMERO = reader.GetOrdinal("NUMERO");
                int NUMERO_SII = reader.GetOrdinal("NUMERO_SII");
                int TIPO_FACTURA = reader.GetOrdinal("TIPO_FACTURA");
                
                while (reader.Read())
                {
                    BacklineSoporte.Entity.DocumentoConsulta OBJ = new BacklineSoporte.Entity.DocumentoConsulta();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Fecha = (DateTime)(reader.IsDBNull(FECHA) == false ? reader.GetValue(FECHA) : null);
                    OBJ.Numero = (int)(!reader.IsDBNull(NUMERO) ? reader.GetValue(NUMERO) : 0);
                    OBJ.NumeroSii = (int)(!reader.IsDBNull(NUMERO_SII) ? reader.GetValue(NUMERO_SII) : 0);
                    OBJ.TipoDocumento = (Int16)(!reader.IsDBNull(TIPO_FACTURA) ? reader.GetValue(TIPO_FACTURA) : 0);
                    //EndFields

                    listaDocumentosConsulta.Add(OBJ);
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

            return listaDocumentosConsulta;

        }
    }
}
