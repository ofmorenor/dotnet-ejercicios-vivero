using System;
using Microsoft.EntityFrameworkCore; // DbSet, 
using Facturas.Domain;


// Consultar: Que es un Db Context en .NET?
// instalar entityframework core desde NuGet package manager

// agregamos la referencia de la libreria de clases Factura.Domain
// usando el comando: dotnet add reference ../FacturasDomain/Facturas.Domain.csproj
// importamos la libreria de clases Faturas.Domain

// haciendo la migracion
// se debe indicar un startup project
// instalar el nuguet EntityFramework.Design en el proyecto UI
// agregamos tambien la referencia del dommain  a Facturas.UI con: dotnet add reference ../FacturasDomain/Facturas.Domain.csproj
// compilamos con: dotnet build
// dotnet ef --startup-project  ..\Facturas.UI\ migrations add InitialMigration
// se crea automaticamente la carpeta Migrations

// corriendo la migracion
// dotnet ef --startup-project  ..\Facturas.UI\ database update

namespace Facturas.Data
{
    public class FacturaContext : DbContext
    {
        public DbSet<Factura> Facturas {get; set;}
        public DbSet<DetalleFactura> DetallesFactura {get; set;}
        public DbSet<Producto> Productos {get; set;}

        // ojo asi estaba hecho antes, pero: aqui no deberia estar la cadena de conexion!!!
        // se puede usar para probar

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            // var connectionString ="Server=tcp:semillero.database.windows.net,1433;Initial Catalog=facturasOscarMorenoDb;Persist Security Info=False;User ID=semillero;Password=S3m1ll3r02019*;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // var connectionString ="Server=tcp:semillero.database.windows.net,1433;Initial Catalog=facturasOscarMorenoDb;Persist Security Info=False;User ID=semillero;Password=S3m1ll3r02019*;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // optionsBuilder.UseSqlServer(connectionString);
            // base.OnConfiguring(optionsBuilder);
        // }

        // mejor usamos un constructor y le pasamos las opciones como parámetro.
        // y no nos olvidemos de llamar el constructor de la clase padre DbContext
        // usando base(opciones)
        public FacturaContext(DbContextOptions<FacturaContext> opciones):base(opciones){
        }
    }
}
