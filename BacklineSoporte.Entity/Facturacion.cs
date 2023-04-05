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
    }
}
