using System;
using System.Linq;
using Facturas.Data;
using Facturas.Domain;

namespace Facturas.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // instanciando el contexto usando using
            // dispone el objeto automaticamente despues de que lo usa
            using(var db = new FacturaContext()){

                // traer todos los productos
                var productos = db.Productos.ToList(); 
                Console.WriteLine("Productos");
                foreach (Producto producto in productos){
                    Console.WriteLine(producto.Nombre);
                }

                // modificando un producto
                var productoParaModificar = db.Productos.Find(3);
                productoParaModificar.Nombre = "Modificado";
                productoParaModificar.Descripcion = "Descripcion Modificada";

                // modificando varios productos con lambda exp 
                // todo

                // guardando todos los cambios hechos
                db.SaveChanges();
            }
        }
    }
}
