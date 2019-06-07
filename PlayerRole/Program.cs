using System;
using System.Collections.Generic;

namespace PlayerRole
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Carnivore();
            animal.Name = "Lion";
            animal.habitatRoles.Add(new LandAnimal());
            Console.WriteLine(animal.Name);

            Console.ReadKey();

        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public List<HabitatRole> habitatRoles { get; set; }
        public Animal()
        {
            habitatRoles = new List<HabitatRole>();
        }
    }
    public class Carnivore : Animal//etçil
    {
        public Carnivore()
        {
            Console.WriteLine("Etçil");
        }
    }
    public class Herbivore : Animal//otçul
    {
        public Herbivore()
        {

            Console.WriteLine("Otçul");
        }
    }
    public class Omnivore : Animal//hetero
    {
        public Omnivore()
        {

            Console.WriteLine("Hetero");
        }
    }
    public class HabitatRole
    {

    }
    public class AquaticAnimal : HabitatRole//suda
    {
        public AquaticAnimal()
        {
            Console.WriteLine("Aquatic Animal.");
        }
    }
    public class LandAnimal : HabitatRole//karada
    {
        public LandAnimal()
        {
            Console.WriteLine("Land Animal.");
        }
    }
}
