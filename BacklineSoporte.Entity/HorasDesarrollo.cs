using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class HorasDesarrollo
    {
        public int Id { get; set; }
        public int Desa_Id { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public string Desarrollo { get; set; }
        public string Fecha
        {
            get
            {
                return Fecha_Inicio.ToShortDateString();
            }
        }
        public string HoraInicio
        {
            get
            {
                var horas = Fecha_Inicio.Hour.ToString("00");
                var minutos = Fecha_Inicio.Minute.ToString("00");

                return horas + ":" + minutos;
            }
        }
        public DateTime Fecha_Termino { get; set; }
        public string HoraTermino
        {
            get
            {
                var horas = Fecha_Termino.Hour.ToString("00");
                var minutos = Fecha_Termino.Minute.ToString("00");

                return horas + ":" + minutos;
            }
        }
        public string Total_Trabajado
        {
            get
            {
                if (Fecha_Termino == DateTime.MinValue)
                {
                    return "00" + "h" + ":" + "00" + "min";
                }
                else
                {
                    var horasTrabajadas = (Fecha_Termino - Fecha_Inicio).Hours.ToString("00");
                    var minutosTrabajados = (Fecha_Termino - Fecha_Inicio).Minutes.ToString("00");

                    return horasTrabajadas + "h" + ":" + minutosTrabajados + "min";
                }
               
            }
        }
        public string totalstr
        {
            get
            {
                var hors = (Fecha_Termino - Fecha_Inicio).TotalHours.ToString();
                var minu = (Fecha_Termino - Fecha_Inicio).TotalMinutes.ToString();

                return hors + minu;
            }
        }
        public int Usr_Desarrollador_Id { get; set; }
        
        public string Observacion { get; set; }
        public string Desarrollador { get; set; }
        public bool Finalizado { get; set; }
        public string Estado
        {
            get
            {
                string estado = "";

                if (Finalizado == true)
                {
                    estado = "Periodo de trabajo finalizado";
                }
                if (Finalizado == false)
                {
                    estado = "Periodo de trabajo en ejecución";
                }

                return estado;
            }
        }
        public bool Eliminada { get; set; }
        
    }
}
