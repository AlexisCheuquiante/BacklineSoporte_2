using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Archivo
    {
        public int Id { get; set; }
        public int FichId { get; set; }
        public int TiarId { get; set; }
        public string TipoArchivo { get; set; }
        public string Ruta { get; set; }
        public string Observacion { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
    }
}
