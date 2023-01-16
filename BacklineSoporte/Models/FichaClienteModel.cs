using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BacklineSoporte.Models
{
    public class FichaClienteModel
    {
        public List<Entity.FichaCliente> ListaFichaCliente { get; set; }
        public int Id { get; set; }
    }
}