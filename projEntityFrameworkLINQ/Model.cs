using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace projEntityFrameworkLINQ
{
    internal class Model
    {
        public class AnimalContext : DbContext
        {
            public DbSet<Animal> Animals { get; set; }
            public DbSet<Species> Species { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {
                builder.UseSqlServer("Your connection string");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Seed initial des espèces protégées avec le nombre d'animaux recensés
                modelBuilder.Entity<Species>().HasData(
                    new Species { SpeciesId = 1, Name = "Cougars blancs", RemainingCount = 3 },
                    new Species { SpeciesId = 2, Name = "Tigres blancs", RemainingCount = 100 },
                    new Species { SpeciesId = 3, Name = "Tortues albinos", RemainingCount = 15 }
                );
            }
        }

        public class Animal
        {
            public String Name { get; set; }

            public Species Species { get; set; }
        }

        public class Species
        {
            public int SpeciesId { get; set; }
            public String Name { get; set; }
            public int RemainingCount { get; set; }
        }

    }
}
