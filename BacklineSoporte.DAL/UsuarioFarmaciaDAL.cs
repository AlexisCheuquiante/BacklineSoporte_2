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
    public class UsuarioFarmaciaDAL
    {
        public static Entity.UsuarioFarmacia GuardarUsuarioFarmacia(BacklineSoporte.Entity.UsuarioFarmacia usuarioFarmacia)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIO_INS");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, usuarioFarmacia.Emp_Id);
            db.AddInParameter(dbCommand, "NOMBRE", DbType.String, usuarioFarmacia.Nombre);
            db.AddInParameter(dbCommand, "USERNAME", DbType.String, usuarioFarmacia.UserName);

            usuarioFarmacia.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return usuarioFarmacia;
        }
        public static Entity.UsuarioFarmacia GuardarUsuarioMantenedor(BacklineSoporte.Entity.UsuarioFarmacia usuarioFarmacia)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIO_MANTENEDOR_INS");
            db.AddInParameter(dbCommand, "ID", DbType.Int32, usuarioFarmacia.Id);
            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, usuarioFarmacia.Emp_Id != 0 ? usuarioFarmacia.Emp_Id : (object)null);
            db.AddInParameter(dbCommand, "NOMBRE", DbType.String, usuarioFarmacia.Nombre);
            db.AddInParameter(dbCommand, "USERNAME", DbType.String, usuarioFarmacia.UserName);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, usuarioFarmacia.password);

            usuarioFarmacia.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return usuarioFarmacia;
        }
        public static void EliminarUsuario(int idUsuario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIO_MANTENEDOR_DELETE");


            db.AddInParameter(dbCommand, "IDUSUARIO", DbType.Int32, idUsuario);



            db.ExecuteNonQuery(dbCommand);
        }


        public static List<BacklineSoporte.Entity.UsuarioFarmacia> ObtenerUsuarioFarmacia(Entity.Filtro filtro)
        {
            List<Entity.UsuarioFarmacia> listaUsuariosFarmacia = new List<Entity.UsuarioFarmacia>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIO_GET");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, filtro.EmpId != 0 ? filtro.EmpId : (object)null);
            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);



            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int NOMBRE = reader.GetOrdinal("NOMBRE");
                int USERNAME = reader.GetOrdinal("USERNAME");
                int PASSWORD = reader.GetOrdinal("PASSWORD");
               


                while (reader.Read())
                {
                    BacklineSoporte.Entity.UsuarioFarmacia OBJ = new BacklineSoporte.Entity.UsuarioFarmacia();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Nombre = (String)(!reader.IsDBNull(NOMBRE) ? reader.GetValue(NOMBRE) : string.Empty);
                    OBJ.UserName = (String)(!reader.IsDBNull(USERNAME) ? reader.GetValue(USERNAME) : string.Empty);
                    OBJ.password = (String)(!reader.IsDBNull(PASSWORD) ? reader.GetValue(PASSWORD) : string.Empty);
                   

                    //EndFields

                    listaUsuariosFarmacia.Add(OBJ);
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

            return listaUsuariosFarmacia;

        }
    }
}
