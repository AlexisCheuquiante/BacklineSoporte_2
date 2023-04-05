using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BacklineSoporte.Models
{
    public class FacturacionModel
    {
        public List<Entity.Facturacion> listaFacturacion { get; set; }

        public int Ficha_Cliente_Id { get; set; }
    }
}