using System;
using System.Collections.Generic;

namespace Facturas.Domain
{
    public class Factura 
    {
        public int Id {get; set;}
        public string Descripcion {get; set;}
        public decimal Total {get; set;}
        public decimal SubTotal {get; set;}
        public decimal Impuestos {get; set;}
        public DateTime FechaCreacion {get; set;}
        // Recordar Using System.Collections.Generic
        public List<DetalleFactura> Detalles {get; set;}
    }
}
