using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Filtro
    {
        public int Id { get; set; }
        public bool Visible { get; set; }
        public int Tipo_Archivo_Id { get; set; }
        public string UsuarioStr { get; set; }
        public string Password { get; set; }
        public int EmpId { get; set; }
        public int ComId { get; set; }
        public int RequeId { get; set; }
        public int Reg_Id { get; set; }
        public int Entidad_Id { get; set; }
        public int Ficha_Cliente_Id { get; set; }
        public bool Eliminado { get; set; }
        public int TipoDocumentoConsulta { get; set; }
        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }
        public int Tipo_Software { get; set; }
        public int Responsable { get; set; } 
        public int Estado { get; set; }
        public int Tar_Id { get; set; }
        public bool TraeUsuario { get; set; }

        public int Usuario_Id { get; set; }
    }
}
