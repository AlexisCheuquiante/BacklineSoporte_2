using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Desarrollo
    {
        public int Id { get; set; }
        public string Modulo { get; set; }
        public string Requerimiento { get; set; }
        public string Detalle_Requerimiento { get; set; }
        public string NombreCompleto { get; set; }
        public int Estado_Id { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public int Usuario_Responsable_Id { get; set;}
        public int DiferenciaFecha { get; set; }
        public string FechaInicioMostrar
        {
            get
            {
                var dd = Fecha_Inicio.Day.ToString("00");
                var mm = Fecha_Inicio.Month.ToString("00");
                var yy = Fecha_Inicio.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }
        public DateTime Fecha_Termino { get; set; }
        public string FechaTerminoMostrar
        {
            get
            {
                var dd = Fecha_Termino.Day.ToString("00");
                var mm = Fecha_Termino.Month.ToString("00");
                var yy = Fecha_Termino.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }

    }
}
