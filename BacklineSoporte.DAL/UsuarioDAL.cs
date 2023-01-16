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
    public class UsuarioDAL
    {
        public static List<BacklineSoporte.Entity.Usuario> ObtenerUsuario(Entity.Filtro filtro)
        {
            List<Entity.Usuario> listaUsuarios = new List<Entity.Usuario>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIOS_GET");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);
            db.AddInParameter(dbCommand, "USUARIO", DbType.String, filtro.UsuarioStr != "" ? filtro.UsuarioStr : (object)null);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, filtro.Password != "" ? filtro.Password : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int NOMBRE_COMPLETO = reader.GetOrdinal("NOMBRE_COMPLETO");
                int USUARIO = reader.GetOrdinal("USUARIO");
                int PASSWORD = reader.GetOrdinal("PASSWORD");
                int ROL_ID = reader.GetOrdinal("ROL_ID");
                int ROL_USUARIO = reader.GetOrdinal("ROL_USUARIO");
                

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Usuario OBJ = new BacklineSoporte.Entity.Usuario();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.NombreCompleto = (String)(!reader.IsDBNull(NOMBRE_COMPLETO) ? reader.GetValue(NOMBRE_COMPLETO) : string.Empty);
                    OBJ.UsuarioStr = (String)(!reader.IsDBNull(USUARIO) ? reader.GetValue(USUARIO) : string.Empty);
                    OBJ.Password = (String)(!reader.IsDBNull(PASSWORD) ? reader.GetValue(PASSWORD) : string.Empty);
                    OBJ.Rol_Id = (int)(!reader.IsDBNull(ROL_ID) ? reader.GetValue(ROL_ID) : 0);
                    OBJ.Rol_Usuario = (String)(!reader.IsDBNull(ROL_USUARIO) ? reader.GetValue(ROL_USUARIO) : string.Empty);
                    //EndFields

                    listaUsuarios.Add(OBJ);
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

            return listaUsuarios;

        }

        public static void GuardaUsuario(BacklineSoporte.Entity.Usuario usuario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIOS_INS");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, usuario.Id);
            db.AddInParameter(dbCommand, "NOMBRE_COMPLETO", DbType.String, usuario.NombreCompleto);
            db.AddInParameter(dbCommand, "USUARIO", DbType.String, usuario.UsuarioStr);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, usuario.Password);
            db.AddInParameter(dbCommand, "ROL_ID", DbType.Int32, usuario.Rol_Id);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void EliminarUsuario(int idUsuario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIOS_DELETE");


            db.AddInParameter(dbCommand, "IDUSUARIO", DbType.Int32, idUsuario);



            db.ExecuteNonQuery(dbCommand);
        }

        public static List<BacklineSoporte.Entity.Usuario> ObtenerSolicitante(Entity.Filtro filtro)
        {
            List<Entity.Usuario> listaSolicitantes = new List<Entity.Usuario>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USR_USUARIO_LEER_BACKLINE_SOPORTE");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, filtro.EmpId != 0 ? filtro.EmpId : (object)null);
            db.AddInParameter(dbCommand, "ELIMINADO", DbType.Boolean, filtro.Eliminado == false ? filtro.Eliminado : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int NOMBRE = reader.GetOrdinal("NOMBRE");
                int ACTIVADO = reader.GetOrdinal("ACTIVADO");
                int ELIMINADO = reader.GetOrdinal("ELIMINADO");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Usuario OBJ = new BacklineSoporte.Entity.Usuario();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.NombreSolicitante = (String)(!reader.IsDBNull(NOMBRE) ? reader.GetValue(NOMBRE) : string.Empty);
                    OBJ.Activo = (bool)(reader.IsDBNull(ACTIVADO) == false ? reader.GetValue(ACTIVADO) : null);
                    OBJ.Eliminado = (bool)(reader.IsDBNull(ELIMINADO) == false ? reader.GetValue(ELIMINADO) : null);
                    //EndFields

                    listaSolicitantes.Add(OBJ);
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

            return listaSolicitantes;

        }
        public static List<BacklineSoporte.Entity.Usuario> ObtenerUsuarioCliente(Entity.Filtro filtro)
        {
            List<Entity.Usuario> listaUsuarios = new List<Entity.Usuario>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_USRCLI_USUARIOS_CLIENTES_GET");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, filtro.Id != 0 ? filtro.Id : (object)null);
            db.AddInParameter(dbCommand, "USUARIO", DbType.String, filtro.UsuarioStr != "" ? filtro.UsuarioStr : (object)null);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, filtro.Password != "" ? filtro.Password : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int NOMBRE = reader.GetOrdinal("NOMBRE");
                int USUARIO = reader.GetOrdinal("USUARIO");
                int PASSWORD = reader.GetOrdinal("PASSWORD");

                while (reader.Read())
                {
                    BacklineSoporte.Entity.Usuario OBJ = new BacklineSoporte.Entity.Usuario();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.NombreCompleto = (String)(!reader.IsDBNull(NOMBRE) ? reader.GetValue(NOMBRE) : string.Empty);
                    OBJ.UsuarioStr = (String)(!reader.IsDBNull(USUARIO) ? reader.GetValue(USUARIO) : string.Empty);
                    OBJ.Password = (String)(!reader.IsDBNull(PASSWORD) ? reader.GetValue(PASSWORD) : string.Empty);
                    //EndFields

                    listaUsuarios.Add(OBJ);
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

            return listaUsuarios;

        }
        public static void CambiarClave(Entity.Usuario usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineSoporte");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_CAMBIO_CLAVE");

            db.AddInParameter(dbCommand, "ID", DbType.String, usuario.Id);
            db.AddInParameter(dbCommand, "CLAVE", DbType.String, usuario.Password);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
