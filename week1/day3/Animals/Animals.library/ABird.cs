using System;
namespace Animals.library
{
    public abstract class ABird : IAnimal
    {
        public abstract string Name { get; set; }

        public void GoTo(string location)
        {
            Console.WriteLine($"Flying to {location}.");   
        }

        public abstract void MakeSound();
    }
}