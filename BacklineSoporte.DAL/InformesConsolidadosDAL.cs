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
    public class InformesConsolidadosDAL
    {
        public static List<Entity.InformesConsolidados> ObtenerConsolidadoEmpresa(Entity.Filtro filtro)
        {
            List<Entity.InformesConsolidados> lista = new List<Entity.InformesConsolidados>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_CONSOLIDADO_EMPRESA_LEER");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, filtro.EmpId != 0 ? filtro.EmpId : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int PROD_ID = reader.GetOrdinal("PROD_ID");
                int CODIGO_BARRA = reader.GetOrdinal("CODIGO_BARRA");
                int DESCRIPCION = reader.GetOrdinal("DESCRIPCION");
                int STOCK = reader.GetOrdinal("STOCK");
                int EMPRESA = reader.GetOrdinal("EMPRESA");
                

                int contador = 0;
                while (reader.Read())
                {
                    Entity.InformesConsolidados obj = new Entity.InformesConsolidados();
                    obj.Id_Producto = (int)(reader.IsDBNull(PROD_ID) == false ? reader.GetValue(PROD_ID) : 0);
                    obj.CodigoBarra = (string)(reader.IsDBNull(CODIGO_BARRA) == false ? reader.GetValue(CODIGO_BARRA) : "");
                    obj.DescripcionProducto = (string)(reader.IsDBNull(DESCRIPCION) == false ? reader.GetValue(DESCRIPCION) : "");
                    obj.Stock = (decimal)(!reader.IsDBNull(STOCK) ? reader.GetValue(STOCK) : 0);
                    obj.Empresa = (string)(reader.IsDBNull(EMPRESA) == false ? reader.GetValue(EMPRESA) : "");
                    obj.TituloInforme = "Informe consolidado por empresa";
                    obj.Bodega = "Stock consolidado por empresa";
                    contador ++;
                    obj.Orden = contador;
                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return lista;
        }
        public static List<Entity.InformesConsolidados> ObtenerConsolidadoBodega(Entity.Filtro filtro)
        {
            List<Entity.InformesConsolidados> lista = new List<Entity.InformesConsolidados>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_CONSOLIDADO_BODEGA_LEER");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, filtro.EmpId != 0 ? filtro.EmpId : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);
            try
            {
                int PROD_ID = reader.GetOrdinal("PROD_ID");
                int CODIGO_BARRA = reader.GetOrdinal("CODIGO_BARRA");
                int DESCRIPCION = reader.GetOrdinal("DESCRIPCION");
                int STOCK = reader.GetOrdinal("STOCK");
                int BODEGA = reader.GetOrdinal("BODEGA");
                int EMPRESA = reader.GetOrdinal("EMPRESA");

                int contador = 0;
                while (reader.Read())
                {
                    Entity.InformesConsolidados obj = new Entity.InformesConsolidados();
                    obj.Id_Producto = (int)(reader.IsDBNull(PROD_ID) == false ? reader.GetValue(PROD_ID) : 0);
                    obj.CodigoBarra = (string)(reader.IsDBNull(CODIGO_BARRA) == false ? reader.GetValue(CODIGO_BARRA) : "");
                    obj.DescripcionProducto = (string)(reader.IsDBNull(DESCRIPCION) == false ? reader.GetValue(DESCRIPCION) : "");
                    obj.Stock = (decimal)(!reader.IsDBNull(STOCK) ? reader.GetValue(STOCK) : 0);
                    obj.Bodega = (string)(reader.IsDBNull(BODEGA) == false ? reader.GetValue(BODEGA) : "");
                    obj.Empresa = (string)(reader.IsDBNull(EMPRESA) == false ? reader.GetValue(EMPRESA) : "");
                    obj.TituloInforme = "Informe consolidado por bodega";

                    contador++;
                    obj.Orden = contador;
                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                //DAL.errror.insertar(ex.de)
            }
            return lista;
        }
    }
}
