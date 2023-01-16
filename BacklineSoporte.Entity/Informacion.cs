using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Informacion
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Titulo { get; set; }

        public string Detalle_Informacion { get; set; }

        public bool Visible { get; set; }
        public string FechaStr
        {
            get
            {
                return Fecha.ToShortDateString();
            }
        }
        public int UsrCreador { get; set; }
        public string CreadorInformacion { get; set; }

    }
}
