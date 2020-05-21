using Microsoft.EntityFrameworkCore;
using SiMaVeh.DataAccess.DataSeed;
using SiMaVeh.DataAccess.DependencyInjection;
using SiMaVeh.Domain.Models;
using SiMaVeh.Domain.Models.Relations;

namespace SiMaVeh.DataAccess.Model
{
    public class SiMaVehContext : DbContext
    {
        protected IDataSeeder DataSeeder { get; set; }

        public SiMaVehContext(DbContextOptions<SiMaVehContext> options) : base(options)
        {
            DataSeeder = DataSeederProvider.GetDataSeeder();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Las invocaciones al método ToTable de las clases derivadas se realiza en pos de
            //activar la modalidad (TPT - Table Per Type). 
            //Como esto al dia de hoy (04/05/2020) no es soportada por EF Core, pero lo será
            //en versiones posteriores, se deja el codigo comentado.

            //builder.Entity<Automovil>().ToTable("Automoviles");
            //builder.Entity<Pieza>().ToTable("Piezas");
            //builder.Entity<Fluido>().ToTable("Fluidos");
            //builder.Entity<Aceite>().ToTable("Aceites");
            //builder.Entity<Usuario>().ToTable("Usuarios");
            //builder.Entity<Kit>().ToTable("Kits");
            //builder.Entity<Repuesto>().ToTable("Repuestos");

            builder.Entity<Reparador>()
                .Ignore(r => r.EntidadesReparadoras);
                //.ToTable("Reparadores");

            builder.Entity<Recambio>().Ignore(r => r.Kits);
            builder.Entity<EntidadReparadora>().Ignore(er => er.Reparadores);

            builder.Entity<UbicacionPieza>()
                .Property(k => k.Id).ValueGeneratedNever();

            //Los Ignore son para que el LazyLoading ignore las propiedades calculadas y
            //no tire excepcion al notar que no tienen setter.

            #region Relaciones

            //Esto es necesario ya que EF Core al dia de hoy (14/01/2019)
            //no soporta relaciones Many-To-Many con colecciones directamente.
            //Hay que modelarlas con un objeto relacion.
            builder.Entity<ReparadorEntidadReparadora>()
                .HasKey(k => new { k.ReparadorId, k.EntidadReparadoraId });

            builder.Entity<KitRecambio>()
                .HasKey(k => new { k.KitId, k.RecambioId });

            #endregion

            #region Data Seeding

            DataSeeder.SeedData(builder);

            #endregion
        }

        /// <summary>
        /// Aceites
        /// </summary>
        public DbSet<Aceite> Aceites { get; set; }

        /// <summary>
        /// Automoviles
        /// </summary>
        public DbSet<Automovil> Automoviles { get; set; }

        /// <summary>
        /// Direcciones
        /// </summary>
        public DbSet<Direccion> Direcciones { get; set; }

        /// <summary>
        /// Entidades Reparadoras
        /// </summary>
        public DbSet<EntidadReparadora> EntidadesReparadoras { get; set; }

        /// <summary>
        /// Equipamientos Airbags
        /// </summary>
        public DbSet<EquipamientoAirbags> EquipamientosAirbags { get; set; }

        /// <summary>
        /// Fluidos
        /// </summary>
        public DbSet<Fluido> Fluidos { get; set; }

        /// <summary>
        /// Fuentes Energia
        /// </summary>
        public DbSet<FuenteEnergia> FuentesEnergia { get; set; }

        /// <summary>
        /// Grupos Modelo
        /// </summary>
        public DbSet<GrupoModelo> GruposModelo { get; set; }

        /// <summary>
        /// Kits
        /// </summary>
        public DbSet<Kit> Kits { get; set; }

        /// <summary>
        /// Localidades
        /// </summary>
        public DbSet<Localidad> Localidades { get; set; }

        /// <summary>
        /// Mantenimientos
        /// </summary>
        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        /// <summary>
        /// Marcas
        /// </summary>
        public DbSet<Marca> Marcas { get; set; }

        /// <summary>
        /// ModelosVehiculo
        /// </summary>
        public DbSet<ModeloVehiculo> ModelosVehiculo { get; set; }

        /// <summary>
        /// Monedas
        /// </summary>
        public DbSet<Moneda> Monedas { get; set; }

        /// <summary>
        /// Neumaticos
        /// </summary>
        public DbSet<Neumatico> Neumaticos { get; set; }

        /// <summary>
        /// Paises
        /// </summary>
        public DbSet<Pais> Paises { get; set; }

        /// <summary>
        /// Partidos
        /// </summary>
        public DbSet<Partido> Partidos { get; set; }

        /// <summary>
        /// Periodicidades Mantenimiento
        /// </summary>
        public DbSet<PeriodicidadMantenimiento> PeriodicidadesMantenimiento { get; set; }

        /// <summary>
        /// Personas
        /// </summary>
        public DbSet<Persona> Personas { get; set; }

        /// <summary>
        /// Piezas
        /// </summary>
        public DbSet<Pieza> Piezas { get; set; }

        /// <summary>
        /// Presiones Neumaticos
        /// </summary>
        public DbSet<PresionNeumatico> PresionesNeumaticos { get; set; }

        /// <summary>
        /// Provincias
        /// </summary>
        public DbSet<Provincia> Provincias { get; set; }

        /// <summary>
        /// Recambios
        /// </summary>
        public DbSet<Recambio> Recambios { get; set; }

        /// <summary>
        /// Reparadores
        /// </summary>
        public DbSet<Reparador> Reparadores { get; set; }

        /// <summary>
        /// Repuestos
        /// </summary>
        public DbSet<Repuesto> Repuestos { get; set; }

        /// <summary>
        /// Servicios Reparadores
        /// </summary>
        public DbSet<ServicioReparador> ServiciosReparadores { get; set; }

        /// <summary>
        /// Targets Mantenimiento
        /// </summary>
        public DbSet<TargetMantenimiento> TargetsMantenimiento { get; set; }

        /// <summary>
        /// Telefonos
        /// </summary>
        public DbSet<Telefono> Telefonos { get; set; }

        /// <summary>
        /// Tipos Cambio
        /// </summary>
        public DbSet<TipoCambio> TiposCambio { get; set; }

        /// <summary>
        /// Tipos Documento
        /// </summary>
        public DbSet<TipoDocumento> TiposDocumento { get; set; }

        /// <summary>
        /// Tipos Entidad Reparadora
        /// </summary>
        public DbSet<TipoEntidadReparadora> TiposEntidadReparadora { get; set; }

        /// <summary>
        /// Tipos Fuente Energia
        /// </summary>
        public DbSet<TipoFuenteEnergia> TiposFuenteEnergia { get; set; }

        /// <summary>
        /// Tipos Telefono
        /// </summary>
        public DbSet<TipoTelefono> TiposTelefono { get; set; }

        /// <summary>
        /// Ubicaciones Pieza
        /// </summary>
        public DbSet<UbicacionPieza> UbicacionesPieza { get; set; }

        /// <summary>
        /// Usuarios
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Vehiculos
        /// </summary>
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}
