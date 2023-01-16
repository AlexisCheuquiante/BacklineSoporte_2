using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Imagen
    {
        public int ID { get; set; }
        public int RequeId { get; set; }
        public byte[] IMAGEN { get; set; }
        public string RUTA_IMAGEN { get; set; }
        public bool Eliminado { get; set; }
        public string NOMBRE_IMAGEN { get; set; }
    }
}
