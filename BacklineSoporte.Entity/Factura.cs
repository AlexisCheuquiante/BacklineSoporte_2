using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Factura
    {
        public int Id { get; set; }
        public int Cont_Id { get; set; }
        public int Usr_Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Paciente { get; set; }
        public string RutPaciente { get; set; }
        public int NumeroVenta { get; set; }
    }
}
