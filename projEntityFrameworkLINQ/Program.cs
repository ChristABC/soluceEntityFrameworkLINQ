using System;
using static projEntityFrameworkLINQ.WildlifeContext;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projEntityFrameworkLINQ;

namespace LinqMethod
{

    class MainProgram
    {
        static void Main(string[] args)
        {
            using (var context = new WildlifeContext())
            {
                DataInitializer.Initialize(context);

                var speciesList = context.Species
                    .Include(s => s.Animals)
                    .ToList();

                foreach (var species in speciesList)
                {
                    Console.WriteLine($"{species.Name} - {species.Animals.Count} animaux recensés");
                }
            }
        }
    }
}


