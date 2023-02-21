using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class RL_EMP_BODE
    {
        public int Id { get; set; }
        public int Fdet_Id { get; set; }
        public int Ajuste_Bodega_Id { get; set; }
        public int RL_Ajuste_Prod { get; set; }
        public int Emp_Id { get; set; }
        public int Bode_Id { get; set; }
        public int Fact_Id { get; set; }
        public int Prod_Id { get; set; }
        public string Descripcion_Prod { get; set; }
        public int Lote_Id { get; set; }
        public string Lote { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public string FechaMostrar
        {
            get
            {
                string yy = Fecha_Vencimiento.Year.ToString("0000");
                string mm = Fecha_Vencimiento.Month.ToString("00");
                string dd = Fecha_Vencimiento.Day.ToString("00");

                return yy + "-" + mm + "-" + dd;
            }
        }
        public decimal Stock { get; set; }
        public double Valor { get; set; }
        public decimal Subtotal { get; set; }
        public int Total { get; set; }
        public decimal Cantidad_Descontar { get; set; }
        public bool Eliminado { get; set; }
        public int Usr_Id { get; set; }
        public DateTime Fecha_Movimiento { get; set; }
        public string Observacion { get; set; }
        public int Cont_Id { get; set; }
    }
}
