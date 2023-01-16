using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class Establecimiento
    {
        public int Id { get; set; }
        public int Fich_Id { get; set; }
        public string Razon_Social { get; set; }
        public string NombreEstablecimiento { get; set; }
        public bool BE_Afecta_IVA { get; set; }
        public string Afecta_IVA_Mostrar
        {
            get
            {
                if (BE_Afecta_IVA == false)
                {
                    return "No"; 
                }
                else
                {
                    return "Si";
                }
            }
        }
        public bool Eliminado { get; set; }
    }
}
