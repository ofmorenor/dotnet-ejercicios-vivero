using System;
using System.Collections.Generic;

namespace ej4_carrito_compras
{
    class Program
    {
        static void Main(string[] args)
        {
            // Usamos la clase Carrito como un molde para crear un
            // objeto de tipo Carrito, también podemos decir 
            // que INSTANCIAMOS un objeto de tipo Carrito
            Carrito carritoCompras = new Carrito();

            // creamos la lista de productos inicial con los datos de prueba creados
            // en la CLASE ESTÁTICA llamada DatosDePrueba (Recuerden que estática significa que
            // no necesitamos instanciar, osea NO HACEMOS new DatosDePrueba())
            // ... Como no necesitamos instanciar simplemente invocamos el método.
            var productosDisponibles = DatosDePrueba.traerProductos();

            // recorremos la lista de productosDisponibles y los voy agregando al carrito con el método
            // agregarProducto()...
            // nótese que si el producto es de aseo agrego 2 unidades usando el método sobrecargado sino agrego solo 1
            // si te preguntas por qué hago esto, la respuesta es simplemente porque así lo quiero hacer :) .
            // (ver método agregarProducto() en la clase Carrito)
            foreach(Producto p in productosDisponibles){
                if (p.tipo == TipoProducto.aseo){
                    carritoCompras.agregarProducto(p, 2);
                }
                else{
                    carritoCompras.agregarProducto(p);
                }
            }

            // imprime información basica del carrito. Este es un método que 
            // creamos en la clase carrito
            carritoCompras.imprimirInformacion(); 


            // probando los otros métodos del carrito:

            // cuantos productos de aseo tengo? deben ser 2
            var productosDeAseo = carritoCompras.contarProductosPorTipo(TipoProducto.aseo);
            Console.WriteLine($"productos de aseo: {productosDeAseo}");
            
            // producto menor valor? debe ser panela (1500)
            Console.WriteLine($"producto de menor valor: {carritoCompras.traerProductoDeMenorValor().nombre}");

            // producto mayor valor? debe ser detergente(5000)
            Console.WriteLine($"producto de mayor valor: {carritoCompras.traerProductoDeMayorValor().nombre}");
        }

    }
}
