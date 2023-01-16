using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Bitacora
    {
        public int Id { get; set; }
        public int Usr_Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaMostrar
        {
            get
            {
                return Fecha.ToShortDateString();
            }
        }
        public string Detalle { get; set; }
        public string Modulo { get; set; }
    }
}
