using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class ImagenDesarrollo
    {
        public int Id { get; set; }
        public string RUTA_IMAGEN { get; set; }
        public int Desarrollo_Id { get; set; }
        public byte[] IMAGEN { get; set; }
        public string NOMBRE_IMAGEN { get; set; }
    }
}
