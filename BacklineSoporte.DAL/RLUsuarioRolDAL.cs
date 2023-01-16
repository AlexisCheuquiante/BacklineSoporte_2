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
    public class RLUsuarioRolDAL
    {
        public static void GuardarRelacionUsuarioRol(BacklineSoporte.Entity.RLUsuarioRol rlUsuarioRol)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USRL_ROLE_INS");

            db.AddInParameter(dbCommand, "USR_ID", DbType.Int32, rlUsuarioRol.Usr_Id);
            db.AddInParameter(dbCommand, "ROLE_ID", DbType.String, rlUsuarioRol.Rol_Id);


            db.ExecuteNonQuery(dbCommand);
        }
    }
}
