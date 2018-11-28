using System;

namespace Animals.library
{
    public class Dog : IAnimal
    {
        public string Name 
        {
            get
            {
                return "Bob";
            }
            set
            {
                Console.WriteLine("inside property setter");
            }
        }
        private string _breed;
        public string Breed 
        { 
            get { return _breed; } 
            set 
            {
                if (value != null && value != "")
                {
                    _breed = value;
                }
            }
        }
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                 _age = value;
            }
        }
        public int Weight;

        public int GetWeight()
        {
            return Weight;
        }

        public void SetWeight(int weight)
        {
            Weight = weight;
        }

        public void Bark()
        {
            Console.WriteLine("Woof");
        }

        public void MakeSound()
        {
            Bark();
        }

        public void GoTo(string location)
        {
            string output = $"Walking to {location}.";
            Console.WriteLine(output);
        }
    }
}
