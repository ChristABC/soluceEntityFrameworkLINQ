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
    public class WildlifeContext : DbContext
    {
        public DbSet<Species> Species { get; set; }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=wildlife.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optionally, configure model relationships and constraints here
        }
    }

    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
    }

    public static class DataInitializer
    {
        public static void Initialize(WildlifeContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Species.Any())
            {
                var cougars = new Species { Name = "Cougar Blanc" };
                var tigers = new Species { Name = "Tigre Blanc" };
                var turtles = new Species { Name = "Tortue Albinos" };

                context.Species.AddRange(cougars, tigers, turtles);

                context.Animals.AddRange(
                    new Animal { Name = "Cougar Blanc 1", Species = cougars },
                    new Animal { Name = "Cougar Blanc 2", Species = cougars },
                    new Animal { Name = "Cougar Blanc 3", Species = cougars }
                );

                context.Animals.AddRange(
                    Enumerable.Range(1, 100).Select(i => new Animal { Name = $"Tigre Blanc {i}", Species = tigers }).ToList()
                );

                context.Animals.AddRange(
                    Enumerable.Range(1, 15).Select(i => new Animal { Name = $"Tortue Albinos {i}", Species = turtles }).ToList()
                );

                context.SaveChanges();
            }
        }
    }
}