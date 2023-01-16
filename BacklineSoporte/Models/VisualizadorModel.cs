using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BacklineSoporte.Models
{
    public class VisualizadorModel
    {
        public List<Entity.Imagen> ListaImagenes { get; set; }
        public int IdRequerimiento { get; set; }
    }
}