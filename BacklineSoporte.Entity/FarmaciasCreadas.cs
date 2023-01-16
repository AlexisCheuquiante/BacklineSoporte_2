using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklineSoporte.Entity
{
    public class FarmaciasCreadas
    {
        public int Id { get; set; }
        public int Contador { get; set; }
        public string Rut { get; set; }
        public string NombreEmpresa { get; set; }
        public string Alias { get; set; }
        public string RazonSocial { get; set; } 
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Online { get; set; }
        public bool Orbyta { get; set; }
        public bool Real { get; set; }
        public string Farmacia { get; set; }
        public bool Eliminado { get; set; }
        public bool VerCalendario { get; set; }
        public bool VerGraficos { get; set; }
        public bool VerPresupuesto { get; set; }
        public bool VerLight { get; set; }
        public bool Asistente { get; set; }
        public bool VerContabilidad { get; set; }
        public bool VerCompras { get; set; }
        public bool VerVentas { get; set; }
        public bool VerStockInventario { get; set; }
        public bool VerSoloProductosConLista { get; set; }
        public bool ValidarStock { get; set; }
        public bool PuntoImpresion { get; set; }
        public bool VerCaja { get; set; }
        public bool CajaExterno { get; set; }
        public bool EsRedondeo { get; set; }
        public bool NoCalcularAutomaticamentePrecio { get; set; }
        public bool EsEtiquetaDispensacion { get; set; }
        public bool CopiarDetallePortapapeles { get; set; }
        public bool ManejoPorLote { get; set; }
        public bool OmitirMedico { get; set; }
        public bool Trazabilidad { get; set; }
        public bool EsRedondeoEnFactura { get; set; }
        public bool DetectarLotePerdido { get; set; }
        public bool EsAfecta { get; set; }

    }
}
