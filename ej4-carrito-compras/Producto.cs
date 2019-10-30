using System;

namespace ej4_carrito_compras
{
    public class Producto
    {
      public string nombre { get; }
      public TipoProducto tipo { get; }
      public int cantidad {get; set; }
      public double valor {get; }

      public Producto(string nombre, TipoProducto tipo, double valor){
        this.nombre = nombre;
        this.tipo = tipo;
        this.valor = valor;
        cantidad = 1;
      }

    }
}