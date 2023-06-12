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
    public class FacturacionDAL
    {
        public static BacklineSoporte.Entity.Facturacion GuardaFactura(BacklineSoporte.Entity.Facturacion facturacion)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FAC_FACTURACION_INS");


            db.AddInParameter(dbCommand, "ID", DbType.Int32, facturacion.Id);
            db.AddInParameter(dbCommand, "NUMERO_FACTURA", DbType.Int32, facturacion.Numero_Factura != 0 ? facturacion.Numero_Factura : (object)null);
            db.AddInParameter(dbCommand, "FECHA_FACTURA", DbType.DateTime, facturacion.Fecha_Factura != DateTime.MinValue ? facturacion.Fecha_Factura : (object)null);
            db.AddInParameter(dbCommand, "FICHA_CLIENTE_ID", DbType.Int32, facturacion.Ficha_Cliente_Id != 0 ? facturacion.Ficha_Cliente_Id : (object)null);
            db.AddInParameter(dbCommand, "PROD_FACT_ID", DbType.Int32, facturacion.Prod_Facturado_Id != 0 ? facturacion.Prod_Facturado_Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_VENCIMIENTO_PAGO", DbType.DateTime, facturacion.Fecha_Vencimiento_Factura != DateTime.MinValue ? facturacion.Fecha_Vencimiento_Factura : (object)null);
            db.AddInParameter(dbCommand, "EST_FACT_ID", DbType.Int32, facturacion.Estado_Id != 0 ? facturacion.Estado_Id : (object)null);
            db.AddInParameter(dbCommand, "NUMERO_TRANSACCION", DbType.Int32, facturacion.Numero_Transaccion != 0 ? facturacion.Numero_Transaccion : (object)null);
            db.AddInParameter(dbCommand, "OBSERVACION", DbType.String, facturacion.Observacion != "" ? facturacion.Observacion : (object)null);
            db.AddInParameter(dbCommand, "USR_CREADOR_ID", DbType.Int32, facturacion.Usr_Creador_Id != 0 ? facturacion.Usr_Creador_Id : (object)null);
            db.AddInParameter(dbCommand, "USR_MODIFICADOR_ID", DbType.Int32, facturacion.Usr_Modificador_Id != 0 ? facturacion.Usr_Modificador_Id : (object)null);
            db.AddInParameter(dbCommand, "NULA", DbType.Byte, facturacion.Nula == true ? 1 : 0);
            db.AddInParameter(dbCommand, "ELIMINADA", DbType.Byte, facturacion.Eliminada == true ? 1 : 0);

            facturacion.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return facturacion;
        }
    }
}
