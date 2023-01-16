using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Software
    {
        public int Id { get; set; }
        public string TipoSoftware { get; set; }
        public bool Eliminado { get; set; }
    }
}
