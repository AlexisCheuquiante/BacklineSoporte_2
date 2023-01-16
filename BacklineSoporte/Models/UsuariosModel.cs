using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BacklineSoporte.Models
{
    public class UsuariosModel
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public List<Entity.Usuario> ListaUsuarios { get; set; }
    }
}