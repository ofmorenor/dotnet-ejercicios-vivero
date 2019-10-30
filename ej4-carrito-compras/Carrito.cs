using System;
using System.Collections.Generic;

namespace ej4_carrito_compras
{
    class Carrito
    {

      public Carrito(){
        productos = new List<Producto>();
        fechaCreacion = DateTime.Now;
        fechaModificacion = DateTime.Now;
      }

      private DateTime fechaCreacion;
      private DateTime fechaModificacion;
      private List<Producto> productos;

      public void agregarProducto(Producto producto){
        productos.Add(producto);
        fechaModificacion = DateTime.Now;
      }
      // sobrecarga del método cuando no indique la cantidad
      public void agregarProducto(Producto producto, int cantidad){
        producto.cantidad = cantidad;
        agregarProducto(producto);
      }

      public int contarProductosPorTipo(TipoProducto tipo){
        var contador = 0;
        productos.ForEach(p => contador = p.tipo == tipo ? (contador + 1) : contador);
        return contador;
      }

      // asume que hay por lo menos un producto en la lista
      // si no hay producto en la lista, debe retornar producto nulo
      public Producto traerProductoDeMenorValor(){
          var productoMenorValor = productos[0];
          productos.ForEach(p => productoMenorValor = p.valor < productoMenorValor.valor ? p : productoMenorValor);
          return productoMenorValor;
      }

      // asume que hay por lo menos un producto en la lista
      // si no hay producto en la lista, debe retornar producto nulo
      public Producto traerProductoDeMayorValor(){
          var productoMayorValor = productos[0];
          productos.ForEach(p => productoMayorValor = p.valor > productoMayorValor.valor ? p : productoMayorValor);
          return productoMayorValor;
      }

      public double calcularTotal(){
        double total = 0;
        foreach(Producto p in productos ){
          total += p.valor * p.cantidad;
        }
        return total;
      }

      public void imprimirInformacion(){
        Console.WriteLine("======= CARRITO DE COMPRAS =======");
        Console.WriteLine($"creado: {fechaCreacion}");
        Console.WriteLine($"ultima modificacion: {fechaModificacion}");
        imprimirListaProductos();
        Console.WriteLine($"Total: {calcularTotal():n2}" );
        Console.WriteLine("================================== \n");
      }

      public void imprimirListaProductos(){
        foreach(Producto p in productos){
          Console.WriteLine($"producto: {p.nombre} - cantidad: {p.cantidad} - valor unitario: {p.valor} - valor total: {p.valor * p.cantidad }");
        }
      }

    }
}