using System;

namespace Facturas.Domain
{
    public class DetalleFactura 
    {
        public int Id {get; set;}
        public decimal Total {get; set;}
        public decimal SubTotal {get; set;}
        public decimal Impuestos {get; set;}
        public int FacturaId {get; set;}
        public int ProductoId {get; set;}
        public int Producto {get; set;}
    }
}
