using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BacklineSoporte.Models
{
    public class InformacionModel
    {
        public List<Entity.Informacion> ListaInformacion { get; set; }
        public string Titulo { get; set; }
    }
}