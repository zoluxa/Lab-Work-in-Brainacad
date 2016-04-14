using System;

namespace CSharp_Net_module1_4_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) Create an array of Animal objects and object of Animals    
            // print animals with foreach operator for object of Animals 
            Animal[] infAnimal = new Animal[5];
            infAnimal[0] = new Animal("Lion", 800);
            infAnimal[1] = new Animal("Zebra", 600);
            infAnimal[2] = new Animal("Slon", 1600);
            infAnimal[3] = new Animal("Begemot", 1500);
            infAnimal[4] = new Animal("Gorilla", 300);

            Animals AnotherAnimal = new Animals(infAnimal);

            Console.WriteLine("The unordered set of Animals:");

            foreach (Animal item in AnotherAnimal.strAnimal)
                Console.WriteLine("{0} {1}", item.Genus, item.Weight);

            Array.Sort(infAnimal);
            Console.WriteLine();
            Console.WriteLine("The ordered set of Animals:");
            foreach (Animal c in AnotherAnimal)
                Console.WriteLine("{0} {1}", c.Genus, c.Weight);
            Console.WriteLine();

            Array.Sort(AnotherAnimal.strAnimal, Animal.SortWeightAscending);

            Console.WriteLine("Ordering by Genus:");
            foreach (Animal c in infAnimal)
                Console.WriteLine("{0} {1}", c.Genus, c.Weight);

            Array.Sort(AnotherAnimal.strAnimal, Animal.SortGenusDescending);

            Console.WriteLine("Ordering by Weight:");
            foreach (Animal c in infAnimal)
                Console.WriteLine("{0} {1}", c.Genus, c.Weight);
            // 11) Invoke 3 types of sorting 
            // and print results with foreach operator for array of Animal objects  


            Console.ReadLine();
        }
    }
}
