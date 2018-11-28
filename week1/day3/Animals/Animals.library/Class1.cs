using System;

namespace Animals.library
{
    public class Dog
    {
        public string Name;
        public string Breed { get; set;}
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
    }
}
