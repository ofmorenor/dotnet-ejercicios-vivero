using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// importamos Facturas data y facturas domain
// recordar que tienen que estar referenciadas (dotnet add reference)
using Facturas.Data;
using Facturas.Domain;

namespace Facturas.Api.Controllers
{
    [ApiController]
    // configuramos el patron para que sea controller/action
    [Route("[controller]/[action]")]
    public class ProductoController : ControllerBase
    {
        // declaramos el dbContext. Este será inicializado en 
        // el constructor
        private FacturaContext _db;
        private readonly ILogger<ProductoController> _logger;


        // agregamos el argumento db en el constructor para
        // poderle pasar el dbContext como dependencia e inicializar
        // _db
        // Esta dependencia será proporcionada por el inyector de 
        // dependencias "ConfigureServices" del archivo Startup.cs
        public ProductoController(
            ILogger<ProductoController> logger,
            FacturaContext db
        )
        {
            _logger = logger;
            _db = db;

        }

        // creamos el metodo para devolver todos los productos
        // en el navegador poner: https://localhost:5001/Producto/ObtenerLista
        [HttpGet]
        public IEnumerable<Producto> ObtenerLista(){
            return _db.Productos.ToList();
        }

        // podemos usar 2 tipos de anotación:
        //[HttpGet] // si usamos este, es con querystring: ObtenerProducto?id=2
        [HttpGet("{id}")] // si usamos este, es de la forma amigable: ObtenerProducto/2

        // creamos el metodo para devolver un solo producto con el id
        // en el navegador poner: https://localhost:5001/Producto/ObtenerPorId1/1
        public Producto ObtenerPorId(int id){
            var producto = _db.Productos.Find(id);
            return producto;
        }

    }
}
