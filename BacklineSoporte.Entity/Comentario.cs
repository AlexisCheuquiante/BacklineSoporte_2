using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Comentario
    {
        public int Id { get; set; }
        public string ComentarioObs { get; set; }
        public int Requerimiento_Id { get; set; }
        public bool Eliminado { get; set; }
        public int UsuarioCreador_Id { get; set; }
        public string NombreCreador { get; set; }
    }
}
