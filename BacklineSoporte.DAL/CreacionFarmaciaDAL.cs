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
    public class CreacionFarmaciaDAL
    {
        public static Entity.FarmaciasCreadas GuardarFarmacia(BacklineSoporte.Entity.FarmaciasCreadas farmaciasCreadas)
        {
            try
            {

                Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMP_EMPRESAS_INS");

                db.AddInParameter(dbCommand, "ID", DbType.Int32, farmaciasCreadas.Id);
                db.AddInParameter(dbCommand, "RUT", DbType.String, farmaciasCreadas.Rut);
                db.AddInParameter(dbCommand, "NOMBRE_FARMACIA", DbType.String, farmaciasCreadas.NombreEmpresa);
                db.AddInParameter(dbCommand, "ALIAS", DbType.String, farmaciasCreadas.Alias);
                db.AddInParameter(dbCommand, "RAZON_SOCIAL", DbType.String, farmaciasCreadas.RazonSocial);
                db.AddInParameter(dbCommand, "DIRECCION", DbType.String, farmaciasCreadas.Direccion);
                db.AddInParameter(dbCommand, "TELEFONO", DbType.String, farmaciasCreadas.Telefono);
                db.AddInParameter(dbCommand, "CORREO", DbType.String, farmaciasCreadas.Correo);
                db.AddInParameter(dbCommand, "CAJA_EXTERNO", DbType.Byte, farmaciasCreadas.CajaExterno == true ? 1 : 0);
                db.AddInParameter(dbCommand, "ES_ETIQUETA_DISPENSACION", DbType.Byte, farmaciasCreadas.EsEtiquetaDispensacion == true ? 1 : 0);
                db.AddInParameter(dbCommand, "OMITIR_MEDICO", DbType.Byte, farmaciasCreadas.OmitirMedico == true ? 1 : 0);



                var output = db.ExecuteScalar(dbCommand).ToString();
                farmaciasCreadas.Id = int.Parse(output);

            }
            catch (Exception ex){

                Console.WriteLine(ex);            
            }

            return farmaciasCreadas;
        }

        public static List<Entity.FarmaciasCreadas> ObtenerFarmacias(Entity.Filtro Filtro)
        {
            List<Entity.FarmaciasCreadas> listaRetorno = new List<Entity.FarmaciasCreadas>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EMP_EMPRESAS_GET");
            
            db.AddInParameter(dbCommand, "ID", DbType.Int32, Filtro.Id != 0 ? Filtro.Id : (object)null);


            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int ID = reader.GetOrdinal("ID");
                int RUT = reader.GetOrdinal("RUT");
                int ALIAS = reader.GetOrdinal("ALIAS");
                int NOMBRE_FARMACIA = reader.GetOrdinal("NOMBRE_FARMACIA");
                int RAZON_SOCIAL = reader.GetOrdinal("RAZON_SOCIAL");
                int DIRECCION = reader.GetOrdinal("DIRECCION");
                int TELEFONO = reader.GetOrdinal("TELEFONO");
                int CORREO = reader.GetOrdinal("CORREO");
                int CAJA_EXTERNO = reader.GetOrdinal("CAJA_EXTERNO");
                int ES_ETIQUETA_DISPENSACION = reader.GetOrdinal("ES_ETIQUETA_DISPENSACION");
                int OMITIR_MEDICO = reader.GetOrdinal("OMITIR_MEDICO");
                int CONTADOR = reader.GetOrdinal("CONTADOR");

                


                while (reader.Read())
                {
                    Entity.FarmaciasCreadas farmacias = new Entity.FarmaciasCreadas();
                    farmacias.Id = (int)(reader.IsDBNull(ID) == false ? reader.GetValue(ID) : 0);
                    farmacias.Rut = (string)(reader.IsDBNull(RUT) == false ? reader.GetValue(RUT) : "");
                    farmacias.Alias = (string)(reader.IsDBNull(ALIAS) == false ? reader.GetValue(ALIAS) : "");
                    farmacias.NombreEmpresa = (string)(reader.IsDBNull(NOMBRE_FARMACIA) == false ? reader.GetValue(NOMBRE_FARMACIA) : "");
                    farmacias.RazonSocial = (string)(reader.IsDBNull(RAZON_SOCIAL) == false ? reader.GetValue(RAZON_SOCIAL) : "");
                    farmacias.Direccion = (string)(reader.IsDBNull(DIRECCION) == false ? reader.GetValue(DIRECCION) : "");
                    farmacias.Telefono = (string)(reader.IsDBNull(TELEFONO) == false ? reader.GetValue(TELEFONO) : "");
                    farmacias.Correo = (string)(reader.IsDBNull(CORREO) == false ? reader.GetValue(CORREO) : "");
                    farmacias.CajaExterno = (bool)(reader.IsDBNull(CAJA_EXTERNO) == false ? reader.GetValue(CAJA_EXTERNO) : false);
                    farmacias.EsEtiquetaDispensacion = (bool)(reader.IsDBNull(ES_ETIQUETA_DISPENSACION) == false ? reader.GetValue(ES_ETIQUETA_DISPENSACION) : false);
                    farmacias.OmitirMedico = (bool)(reader.IsDBNull(OMITIR_MEDICO) == false ? reader.GetValue(OMITIR_MEDICO) : false);
                    farmacias.Contador = (int)(reader.IsDBNull(CONTADOR) == false ? reader.GetValue(CONTADOR) : 0);





                    listaRetorno.Add(farmacias);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return listaRetorno;
        }
        public static void EliminaFarmacia(int id)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_EMP_EMPRESAS_DELETE");

            db.AddInParameter(dbCommand, "IDEMPRESA", DbType.Int32, id);

            db.ExecuteNonQuery(dbCommand);

        }
    }
}
