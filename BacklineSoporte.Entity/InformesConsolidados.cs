using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class InformesConsolidados
    {
        public int Emp_Id { get; set; }
        public int Orden { get; set; }
        public int Id_Producto { get; set; }
        public string CodigoBarra { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal Stock { get; set; }
        public string Empresa { get; set; }
        public string Bodega { get; set; }
        public string TituloInforme { get; set; }
    }
}
