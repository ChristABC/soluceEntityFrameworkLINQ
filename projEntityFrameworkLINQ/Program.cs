using System;
using static projEntityFrameworkLINQ.Model;
using System.Collections.Generic;

namespace LinqMethod
{

    public class MainProgram
    {
        public static int RemainingCount { get; private set; }

        public static void Main(string[] args)
        {

            using (var context = new AnimalContext())
            {
                var whiteCougarsCount = context.Animals.Count(animal => animal.Species.Name == "Cougars blancs");
                var whiteTigersCount = context.Animals.Count(animal => animal.Species.Name == "Tigres blancs");
                var albinoTurtlesCount = context.Animals.Count(animal => animal.Species.Name == "Tortues albinos");

                Console.WriteLine("Nombre d'animaux recensés :");
                Console.WriteLine($"Cougars blancs : {whiteCougarsCount}");
                Console.WriteLine($"Tigres blancs : {whiteTigersCount}");
                Console.WriteLine($"Tortues albinos : {albinoTurtlesCount}");
            }
        }
    }
}
