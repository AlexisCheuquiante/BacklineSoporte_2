using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Rol_Id { get; set; }
        public string Rol_Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string UsuarioStr { get; set; }
        public string Password { get; set; }
        public bool Eliminado { get; set; }
        public string EliminadoMostrar
        {
            get
            {
                if (Eliminado == true)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }
        public string NombreSolicitante { get; set; }
        public bool Activo { get; set; }
        public string ActivoMostrar
        {
            get
            {
                if (Activo == true)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }
    }
}
