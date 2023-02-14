using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Tarea
    {
        public int Id { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime Fecha_Inicio_Tarea { get; set; }
        public int Modalidad_Id { get; set; }
        public string Modalidad { get; set; }
        public string FechaInicioHora
        {
            get
            {
                string yy = Fecha_Inicio_Tarea.Year.ToString("0000");
                string mm = Fecha_Inicio_Tarea.Month.ToString("00");
                string dd = Fecha_Inicio_Tarea.Day.ToString("00");
                string hh = Fecha_Inicio_Tarea.Hour.ToString("00");
                string mn = Fecha_Inicio_Tarea.Minute.ToString("00");
                

                return yy + "-" + mm + "-" + dd + "T" + hh + ":" + mn ;
            }
        }
        public string FechaInicioMostrar
        {
            get
            {
                var dd = Fecha_Inicio_Tarea.Day.ToString("00");
                var mm = Fecha_Inicio_Tarea.Month.ToString("00");
                var yy = Fecha_Inicio_Tarea.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }
        public DateTime Fecha_Termino_Tarea { get; set; }
        public string FechaTerminoHora
        {
            get
            {
                string yy = Fecha_Termino_Tarea.Year.ToString("0000");
                string mm = Fecha_Termino_Tarea.Month.ToString("00");
                string dd = Fecha_Termino_Tarea.Day.ToString("00");
                string hh = Fecha_Termino_Tarea.Hour.ToString("00");
                string mn = Fecha_Termino_Tarea.Minute.ToString("00");


                return yy + "-" + mm + "-" + dd + "T" + hh + ":" + mn;
            }
        }
        public string FechaTerminoMostrar
        {
            get
            {
                var dd = Fecha_Termino_Tarea.Day.ToString("00");
                var mm = Fecha_Termino_Tarea.Month.ToString("00");
                var yy = Fecha_Termino_Tarea.Year;
                return yy + "-" + mm + "-" + dd;
            }
        }



        public int Usr_Creador_Id { get; set; }
        public int Prioridad_Id { get; set; }
        public int Tipo_Tarea_Id { get; set; }
        public string Detalle { get; set; }
        public bool Realizada { get; set; }
        public string Prioridad { get; set; }
        public string Tipo_Tarea { get; set; }
        public string Nombre_Completo { get; set; }
        public List<RlTareaUsuario> ListaUsuariosAsignados { get; set; }

    }
}
