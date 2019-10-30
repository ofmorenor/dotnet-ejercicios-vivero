using System;
using System.Collections.Generic;


namespace ej4_carrito_compras
{

  public static class DatosDePrueba
  {
    private static readonly List<Producto> productos = new List<Producto>() {
      new Producto("leche", TipoProducto.alimento, 2000),
      new Producto("panela", TipoProducto.alimento, 1500),
      new Producto("leche", TipoProducto.alimento, 2200),
      new Producto("jabón rey", TipoProducto.aseo, 3000),
      new Producto("detergente", TipoProducto.aseo, 5000)
    };

    public static List<Producto> traerProductos(){
      return productos;
    } 


  }

}