using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain;
using MilesCarRental.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Infraestructure.Persistence
{
    /// <summary>
    /// Contexto de la bas de datos de la app
    /// </summary>
    public class MilesCarRentalContext : DbContext
    {
        /// <summary>
        /// Constructor del contexto
        /// </summary>
        /// <param name="options"></param>
        public MilesCarRentalContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Eventos de insercion y actualizacion de datos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaAdd = DateTime.Now;
                        entry.Entity.UsuarioAdd = "Systema";
                        break;
                    case EntityState.Modified:
                        entry.Entity.FechaUp = DateTime.Now;
                        entry.Entity.UsuarioUp = "Systema";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Metodo de insercion de datos de ejemplo en base de datos
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Registros creados por defecto en la base de datos

            //Informacion tipos de documento
            List<TipoDocumento> tipoDocumentos = new List<TipoDocumento>();
            tipoDocumentos.Add(new TipoDocumento
            {
                Id = 1,
                DescripcionTipoDocumento = "Cedula de Ciudadania",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            tipoDocumentos.Add(new TipoDocumento
            {
                Id = 2,
                DescripcionTipoDocumento = "Trajeta de Identidad",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            }); 
            tipoDocumentos.Add(new TipoDocumento
            {
                Id = 3,
                DescripcionTipoDocumento = "Cedula de Extranjeria",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });

            //Informacion Estado Alquiler
            List<EstadoAlquiler> estadoAlquilers = new List<EstadoAlquiler>();
            estadoAlquilers.Add(new EstadoAlquiler
            {
                Id = 1,
                DescripcionEstadoAlquiler= "Alquilado",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            estadoAlquilers.Add(new EstadoAlquiler
            {
                Id = 2,
                DescripcionEstadoAlquiler = "No Alquilado",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            estadoAlquilers.Add(new EstadoAlquiler
            {
                Id = 1,
                DescripcionEstadoAlquiler = "No Disponible",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });

            //Informacion Localidad Alquiler
            List<Localidad> localidads = new List<Localidad>();
            localidads.Add(new Localidad
            {
                Id = 1,
                DescripcionLocalidad = "Usaquen",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            localidads.Add(new Localidad
            {
                Id = 2,
                DescripcionLocalidad = "Kennedy",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            }); 
            localidads.Add(new Localidad
            {
                Id = 3,
                DescripcionLocalidad = "Suba",
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            //Informacion Cliente
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente
            {
                Id = 1,
                NombreCliente = "Hector",
                ApellidoCliente = "Cruz",
                DocumentoCliente = "1049655748",
                IdTipoDocumentoCliente = 1,
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            }) ;
            clientes.Add(new Cliente
            {
                Id = 1,
                NombreCliente = "Beranardo",
                ApellidoCliente = "Aranngo",
                DocumentoCliente = "1049655788",
                IdTipoDocumentoCliente = 2,
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            }); 
            clientes.Add(new Cliente
            {
                Id = 1,
                NombreCliente = "Catalina",
                ApellidoCliente = "Arango",
                DocumentoCliente = "1049355748",
                IdTipoDocumentoCliente = 3,
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            //Informacion Carro
            List<Carro> carros = new List<Carro>();
            carros.Add(new Carro
            {
                Id = 1,
                IdCliente = 1,
                Chasis = "123456789",
                Cilindraje = "1000",
                IdEstadoAlquiler = 1,
                IdLocalidadDevolucion = 1,
                IdLocalidadRecogida = 1,
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            carros.Add(new Carro
            {
                Id = 2,
                IdCliente = 2,
                Chasis = "321654987",
                Cilindraje = "2000",
                IdEstadoAlquiler = 2,
                IdLocalidadDevolucion = 2,
                IdLocalidadRecogida = 2,
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            carros.Add(new Carro
            {
                Id = 2,
                IdCliente = 1,
                Chasis = "963852741",
                Cilindraje = "3000",
                IdEstadoAlquiler = 3,
                IdLocalidadDevolucion = 3,
                IdLocalidadRecogida = 3,
                FechaAdd = DateTime.Now,
                UsuarioAdd = "Sistema",
            });
            #endregion
        }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoAlquiler> EstadoAlquilers { get; set; }
        public DbSet<Localidad> Localidades { get; set; }

    }
}
