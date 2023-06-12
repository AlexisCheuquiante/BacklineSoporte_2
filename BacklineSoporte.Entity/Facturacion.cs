using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Facturacion
    {
        public int Id { get; set; }
        public DateTime Fecha_Factura { get; set; }
        public int Numero_Factura { get; set; }
        public int Ficha_Cliente_Id { get; set; }
        public int Prod_Facturado_Id { get; set; }
        public DateTime Fecha_Vencimiento_Factura { get; set; }
        public int Estado_Id { get; set; }
        public int Numero_Transaccion { get; set; }
        public string Observacion { get; set; }
        public int Usr_Creador_Id { get; set; }
        public int Usr_Modificador_Id { get; set; }
        public bool Nula { get; set; }
        public bool Eliminada { get; set; }
    }
}
