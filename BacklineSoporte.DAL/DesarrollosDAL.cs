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
    public class DesarrollosDAL
    {
        public static void InsertarDesarrollo(Entity.Desarrollo desarrollo)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_DESA_DESARROLLO_INS");
            db.AddInParameter(dbCommand, "ID", DbType.Int32, desarrollo.Id );
            db.AddInParameter(dbCommand, "MODULO", DbType.String, desarrollo.Modulo);
            db.AddInParameter(dbCommand, "REQUERIMIENTO", DbType.String, desarrollo.Requerimiento);
            db.AddInParameter(dbCommand, "DETALLE_REQUERIMIENTO", DbType.String, desarrollo.Detalle_Requerimiento);
            db.AddInParameter(dbCommand, "FECHA_INICIO", DbType.DateTime, desarrollo.Fecha_Inicio);
            db.AddInParameter(dbCommand, "FECHA_TERMINO", DbType.DateTime, desarrollo.Fecha_Termino);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
