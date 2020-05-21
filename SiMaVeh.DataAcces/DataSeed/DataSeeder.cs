using Microsoft.EntityFrameworkCore;
using SiMaVeh.Domain.DataSeed.Interfaces;
using SiMaVeh.Domain.Models;

namespace SiMaVeh.DataAccess.DataSeed
{
    public class DataSeeder : IDataSeeder
    {
        private readonly ISeeder<Pais, long> paisSeeder;
        private readonly ISeeder<Provincia, long> provinciaSeeder;
        private readonly ISeeder<Partido, long> partidoSeeder;

        public DataSeeder(ISeeder<Pais, long> paisSeeder,
            ISeeder<Provincia, long> provinciaSeeder,
            ISeeder<Partido, long> partidoSeeder)
        {
            this.paisSeeder = paisSeeder;
            this.provinciaSeeder = provinciaSeeder;
            this.partidoSeeder = partidoSeeder;
        }

        public void SeedData(ModelBuilder builder)
        {
            //Para poder aplicar efectivamente los Seeds, hay que generar migrations.
            builder.Entity<Pais>().HasData(paisSeeder.GetSeeds());
            builder.Entity<Provincia>().HasData(provinciaSeeder.GetSeeds());
            builder.Entity<Partido>().HasData(partidoSeeder.GetSeeds());
        }
    }
}
