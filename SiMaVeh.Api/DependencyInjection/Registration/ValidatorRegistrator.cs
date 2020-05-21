using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SiMaVeh.Domain.Models;
using SiMaVeh.Domain.Validators;

namespace SiMaVeh.Api.DependencyInjection.Registration
{
    public class ValidatorRegistrator
    {
        public static void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<Aceite>, ValidadorAceite>();
            services.AddTransient<IValidator<Automovil>, ValidadorAutomovil>();
            services.AddTransient<IValidator<Direccion>, ValidadorDireccion>();
            services.AddTransient<IValidator<EntidadReparadora>, ValidadorEntidadReparadora>();
            services.AddTransient<IValidator<EquipamientoAirbags>, ValidadorEquipamientoAirbags>();
            services.AddTransient<IValidator<Fluido>, ValidadorFluido>();
            services.AddTransient<IValidator<FuenteEnergia>, ValidadorFuenteEnergia>();
            services.AddTransient<IValidator<GrupoModelo>, ValidadorGrupoModelo>();
            services.AddTransient<IValidator<Kit>, ValidadorKit>();
            services.AddTransient<IValidator<Localidad>, ValidadorLocalidad>();
            services.AddTransient<IValidator<Mantenimiento>, ValidadorMantenimiento>();
            services.AddTransient<IValidator<Marca>, ValidadorMarca>();
            services.AddTransient<IValidator<ModeloVehiculo>, ValidadorModeloVehiculo>();
            services.AddTransient<IValidator<Moneda>, ValidadorMoneda>();
            services.AddTransient<IValidator<Neumatico>, ValidadorNeumatico>();
            services.AddTransient<IValidator<Pais>, ValidadorPais>();
            services.AddTransient<IValidator<Partido>, ValidadorPartido>();
            services.AddTransient<IValidator<PeriodicidadMantenimiento>, ValidadorPeriodicidadMantenimiento>();
            services.AddTransient<IValidator<Persona>, ValidadorPersona>();
            services.AddTransient<IValidator<Pieza>, ValidadorPieza>();
            services.AddTransient<IValidator<PresionNeumatico>, ValidadorPresionNeumatico>();
            services.AddTransient<IValidator<Provincia>, ValidadorProvincia>();
            services.AddTransient<IValidator<Recambio>, ValidadorRecambio>();
            services.AddTransient<IValidator<Reparador>, ValidadorReparador>();
            services.AddTransient<IValidator<Repuesto>, ValidadorRepuesto>();
            services.AddTransient<IValidator<ServicioReparador>, ValidadorServicioReparador>();
            services.AddTransient<IValidator<TargetMantenimiento>, ValidadorTargetMantenimiento>();
            services.AddTransient<IValidator<Telefono>, ValidadorTelefono>();
            services.AddTransient<IValidator<TipoCambio>, ValidadorTipoCambio>();
            services.AddTransient<IValidator<TipoDocumento>, ValidadorTipoDocumento>();
            services.AddTransient<IValidator<TipoEntidadReparadora>, ValidadorTipoEntidadReparadora>();
            services.AddTransient<IValidator<TipoFuenteEnergia>, ValidadorTipoFuenteEnergia>();
            services.AddTransient<IValidator<TipoTelefono>, ValidadorTipoTelefono>();
            services.AddTransient<IValidator<UbicacionPieza>, ValidadorUbicacionPieza>();
            services.AddTransient<IValidator<Usuario>, ValidadorUsuario>();
            services.AddTransient<IValidator<Vehiculo>, ValidadorVehiculo>();
        }
    }
}