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
    public class RLEmpresaUsuarioDAL
    {
        public static void GuardarRLEmpresaUsuario(BacklineSoporte.Entity.RelacionEmpUsr relacionEmpUsr)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_EMP_USR_INS");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, relacionEmpUsr.Emp_Id);
            db.AddInParameter(dbCommand, "USR_ID", DbType.String, relacionEmpUsr.Usr_Id);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
