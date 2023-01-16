using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Empresa
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public bool Eliminado { get; set; }
        public string TextoAviso { get; set; }
        public int IntervaloTiempo { get; set; }
        public bool MostrarAviso { get; set; }
    }
}
