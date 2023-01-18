using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Desarrollo
    {
        public int Id { get; set; }
        public string Modulo { get; set; }
        public string Requerimiento { get; set; }
        public string Detalle_Requerimiento { get; set; }
        public int Estado_Id { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Termino { get; set; }


    }
}
