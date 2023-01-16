using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BacklineSoporte.Models
{
    public class ComentarioModel
    {
        public List<Entity.Comentario> ListaComentarios { get; set; }
        public int Id_Requerimiento { get; set; }
        public List<Entity.Imagen> ListaImagenes { get; set; }
        public int IdComentario { get; set; }
    }
}