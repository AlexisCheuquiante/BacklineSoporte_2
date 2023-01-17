using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Requerimiento
    {
        public int Id { get; set; }
        public int UsrCreador { get; set; }
        public string NombreCreador { get; set; }
        public DateTime FechaIngreso { get; set; }

        public string FechaMostrarIngreso
        {
            get
            {
                var dd = FechaIngreso.Day.ToString("00");
                var mm = FechaIngreso.Month.ToString("00");
                var yy = FechaIngreso.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }
        public string FechaMostrar
        {
            get
            {
                return FechaIngreso.ToShortDateString();
            }
        }
        public int TisoId { get; set; }
        public string SoftwareStr { get; set; }
        public int EmpId { get; set; }
        public string NombreEmpresa { get; set; }
        public int SolicitanteId { get; set; }
        public string NombreSolicitante { get; set; }
        public string Correo { get; set; }
        public bool RepeticionRequerimiento { get; set; }
        public bool Visible { get; set; }
        public int ModId { get; set; }
        public string Modulo { get; set; }
        public string Funcionalidad { get; set; }
        public int Clasificacion { get; set; }
        public int PriodId { get; set; }
        public string Prioridad { get; set; }
        public int ResponsableId { get; set; }
        public string NombreResponsable { get; set; }
        public DateTime FechaSolucion { get; set; }
        public string FechaMostrarSolucion
        {
            get
            {
                var dd = FechaSolucion.Day.ToString("00");
                var mm = FechaSolucion.Month.ToString("00");
                var yy = FechaSolucion.Year;
                return yy + "-" + mm + "-" + dd;            
            }
        }

        public string Detalle { get; set; }
        public bool Eliminado { get; set; }
        public int Apruebo { get; set; }
        public int Desapruebo { get; set; }

        public int Estado { get; set; }

        public string Estado_Reque { get; set; }
    }
}
