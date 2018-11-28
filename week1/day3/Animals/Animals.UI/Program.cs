using System;

using Animals.library;

namespace Animals.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();

            dog.SetWeight(6);
            Console.WriteLine(dog.GetWeight());

            dog.Name = "fido";
            Console.WriteLine(dog.Name);

            dog.Breed = "Golden Retriever";

            dog.GoTo("the Park");

            IAnimal animal = new Dog();
            animal = new Eagle();
            Eagle e = (Eagle) animal;
            e.Name = "Steve";

            Console.WriteLine("Hello World!");

            DisplayData(new Dog());

            DisplayData(e);
        }
        public static void DisplayData(IAnimal animal)
        {
            Console.WriteLine(animal.Name);
        }
    }
}
