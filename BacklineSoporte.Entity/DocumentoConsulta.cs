using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class DocumentoConsulta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaMostrar
        {
            get
            {
                return Fecha.ToShortDateString();
            }
        }
        public int Numero { get; set; }
        public int NumeroSii { get; set; }
        public int TipoDocumento { get; set; }
        public string TipoDocumentoStr
        {
            get
            {
                if (TipoDocumento == 25)
                {
                    return "Boleta electrónica";
                }
                if (TipoDocumento == 23)
                {
                    return "Nota crédito";
                }
                else
                {
                    return "Factura";
                }
            }
        }
    }
}
