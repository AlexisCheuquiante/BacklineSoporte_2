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
    public class RL_EMP_BODE_DAL
    {
        public static List<Entity.RL_EMP_BODE> ObtenerRlEmpBode(Entity.Filtro filtro)
        {
            List<Entity.RL_EMP_BODE> lista = new List<Entity.RL_EMP_BODE>();
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_EMP_BODE_LEER");

            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, filtro.EmpId != 0 ? filtro.EmpId : (object)null);
            db.AddInParameter(dbCommand, "BODE_ID", DbType.Int32, filtro.Bode_Id != 0 ? filtro.Bode_Id : (object)null);
            db.AddInParameter(dbCommand, "PROD_ID", DbType.Int32, filtro.Prod_Id != 0 ? filtro.Prod_Id : (object)null);

            IDataReader reader = (IDataReader)db.ExecuteReader(dbCommand);

            try
            {
                int ID = reader.GetOrdinal("ID");
                int PROD_ID = reader.GetOrdinal("PROD_ID");
                int LOTE_ID = reader.GetOrdinal("LOTE_ID");
                int LOTE = reader.GetOrdinal("LOTE");
                int STOCK = reader.GetOrdinal("STOCK");
                int VALOR = reader.GetOrdinal("VALOR");
                int FECHA_VENCIMIENTO = reader.GetOrdinal("FECHA_VENCIMIENTO");


                while (reader.Read())
                {
                    Entity.RL_EMP_BODE OBJ = new Entity.RL_EMP_BODE();
                    //BeginFields
                    OBJ.Id = (int)(!reader.IsDBNull(ID) ? reader.GetValue(ID) : 0);
                    OBJ.Prod_Id = (int)(!reader.IsDBNull(PROD_ID) ? reader.GetValue(PROD_ID) : 0);
                    OBJ.Lote_Id = (int)(!reader.IsDBNull(LOTE_ID) ? reader.GetValue(LOTE_ID) : 0);
                    OBJ.Lote = (String)(!reader.IsDBNull(LOTE) ? reader.GetValue(LOTE) : string.Empty);
                    OBJ.Stock = (decimal)(!reader.IsDBNull(STOCK) ? reader.GetValue(STOCK) : 0);
                    OBJ.Valor = (double)(!reader.IsDBNull(VALOR) ? reader.GetValue(VALOR) : 0);
                    OBJ.Fecha_Vencimiento = (DateTime)(!reader.IsDBNull(FECHA_VENCIMIENTO) ? reader.GetValue(FECHA_VENCIMIENTO) : DateTime.MinValue);
                    //EndFields

                    lista.Add(OBJ);
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

            return lista;

        }
        public static Entity.RL_EMP_BODE InsertarFdet(Entity.RL_EMP_BODE fdte_Detalle)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_FDET_FACTURAS_DETALLE_COMPLETA");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, fdte_Detalle.Fdet_Id != 0 ? fdte_Detalle.Fdet_Id : (object)null);
            db.AddInParameter(dbCommand, "FACT_ID", DbType.Int32, fdte_Detalle.Fact_Id != 0 ? fdte_Detalle.Fact_Id : (object)null);
            db.AddInParameter(dbCommand, "PROD_ID", DbType.Int32, fdte_Detalle.Prod_Id != 0 ? fdte_Detalle.Prod_Id : (object)null);
            db.AddInParameter(dbCommand, "CANTIDAD", DbType.Decimal, fdte_Detalle.Cantidad_Descontar != 0 ? fdte_Detalle.Cantidad_Descontar : (object)null);
            db.AddInParameter(dbCommand, "CANTIDAD_RESTANTE", DbType.Decimal, fdte_Detalle.Cantidad_Descontar != 0 ? fdte_Detalle.Cantidad_Descontar : (object)null);
            db.AddInParameter(dbCommand, "VALOR", DbType.Decimal, fdte_Detalle.Valor != 0 ? fdte_Detalle.Valor : (object)null);
            db.AddInParameter(dbCommand, "VALOR_DECIMAL", DbType.Decimal, fdte_Detalle.Valor != 0 ? fdte_Detalle.Valor : (object)null);
            db.AddInParameter(dbCommand, "SUBTOTAL", DbType.Decimal, fdte_Detalle.Subtotal != 0 ? fdte_Detalle.Subtotal : (object)null);
            db.AddInParameter(dbCommand, "TOTAL", DbType.Int32, fdte_Detalle.Total != 0 ? fdte_Detalle.Total : (object)null);
            db.AddInParameter(dbCommand, "ELIMINADO", DbType.Byte, fdte_Detalle.Eliminado == true ? 1 : 0);
            db.AddInParameter(dbCommand, "BODE_ID", DbType.Int32, fdte_Detalle.Bode_Id != 0 ? fdte_Detalle.Bode_Id : (object)null);
            db.AddInParameter(dbCommand, "LOTE", DbType.String, fdte_Detalle.Lote != null ? fdte_Detalle.Lote.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "LOTE_FECHA_VENCIMIENTO", DbType.DateTime, fdte_Detalle.Fecha_Vencimiento != DateTime.MinValue ? fdte_Detalle.Fecha_Vencimiento : (object)null);
            db.AddInParameter(dbCommand, "LOTE_ID", DbType.Int32, fdte_Detalle.Lote_Id != 0 ? fdte_Detalle.Lote_Id : (object)null);

            fdte_Detalle.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return fdte_Detalle;
        }
        public static Entity.RL_EMP_BODE InsertarAjusteBodega(Entity.RL_EMP_BODE AjusteBodega)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_AJUSTE_AJUSTE_BODEGA_COMPLETAR");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, AjusteBodega.Ajuste_Bodega_Id != 0 ? AjusteBodega.Ajuste_Bodega_Id : (object)null);
            db.AddInParameter(dbCommand, "EMP_ID", DbType.Int32, AjusteBodega.Emp_Id != 0 ? AjusteBodega.Emp_Id : (object)null);
            db.AddInParameter(dbCommand, "BODE_ID", DbType.Int32, AjusteBodega.Bode_Id != 0 ? AjusteBodega.Bode_Id : (object)null);
            db.AddInParameter(dbCommand, "USR_ID", DbType.Int32, AjusteBodega.Usr_Id != 0 ? AjusteBodega.Usr_Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_MOVIMIENTO", DbType.DateTime, AjusteBodega.Fecha_Movimiento != DateTime.MinValue ? AjusteBodega.Fecha_Movimiento : (object)null);
            db.AddInParameter(dbCommand, "OBSERVACION", DbType.String, AjusteBodega.Observacion != null ? AjusteBodega.Observacion.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "CONT_ID", DbType.Int32, AjusteBodega.Cont_Id != 0 ? AjusteBodega.Cont_Id : (object)null);
            db.AddInParameter(dbCommand, "FACT_ID", DbType.Int32, AjusteBodega.Fact_Id != 0 ? AjusteBodega.Fact_Id : (object)null);
            db.AddInParameter(dbCommand, "FECHA_DB", DbType.DateTime, AjusteBodega.Fecha_Movimiento != DateTime.MinValue ? AjusteBodega.Fecha_Movimiento : (object)null);

            AjusteBodega.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return AjusteBodega;
        }
        public static Entity.RL_EMP_BODE InsertarRLAjusteProd(Entity.RL_EMP_BODE RlAjusteProd)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_AJUSTE_PROD_COMPLETAR");

            db.AddInParameter(dbCommand, "ID", DbType.Int32, RlAjusteProd.RL_Ajuste_Prod != 0 ? RlAjusteProd.RL_Ajuste_Prod : (object)null);
            db.AddInParameter(dbCommand, "AJUSTE_ID", DbType.Int32, RlAjusteProd.Ajuste_Bodega_Id != 0 ? RlAjusteProd.Ajuste_Bodega_Id : (object)null);
            db.AddInParameter(dbCommand, "PROD_ID", DbType.Int32, RlAjusteProd.Prod_Id != 0 ? RlAjusteProd.Prod_Id : (object)null);
            db.AddInParameter(dbCommand, "CANTIDAD", DbType.Int32, RlAjusteProd.Cantidad_Descontar != 0 ? RlAjusteProd.Cantidad_Descontar : (object)null);
            db.AddInParameter(dbCommand, "ID_RL_EMP_BODE", DbType.Int32, RlAjusteProd.Lote_Id != 0 ? RlAjusteProd.Lote_Id : (object)null);
            db.AddInParameter(dbCommand, "LOTE_ID", DbType.Int32, RlAjusteProd.Lote_Id != 0 ? RlAjusteProd.Lote_Id : (object)null);
            db.AddInParameter(dbCommand, "LOTE", DbType.String, RlAjusteProd.Lote != null ? RlAjusteProd.Lote.ToUpper() : (object)null);
            db.AddInParameter(dbCommand, "FECHA_VENCIMIENTO", DbType.DateTime, RlAjusteProd.Fecha_Vencimiento != DateTime.MinValue ? RlAjusteProd.Fecha_Vencimiento : (object)null);
            db.AddInParameter(dbCommand, "VALOR", DbType.Decimal, RlAjusteProd.Valor != 0 ? RlAjusteProd.Valor : (object)null);

            RlAjusteProd.Id = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return RlAjusteProd;
        }
        public static Entity.RL_EMP_BODE DescontarStock(Entity.RL_EMP_BODE descontarStock)
        {
            Database db = DatabaseFactory.CreateDatabase("baseDatosBacklineFarmacias");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_RL_EMP_BODE_COMPLETAR");

            db.AddInParameter(dbCommand, "LOTE_ID", DbType.Int32, descontarStock.Lote_Id != 0 ? descontarStock.Lote_Id : (object)null);
            db.AddInParameter(dbCommand, "CANTIDAD_RESTA", DbType.Decimal, descontarStock.Cantidad_Descontar != 0 ? descontarStock.Cantidad_Descontar : (object)null);

            db.ExecuteScalar(dbCommand);

            return descontarStock;
        }
    }
}
