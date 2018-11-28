using System;
namespace Animals.library
{
    public class Eagle : ABird
    {
        private string _name;
        public override string Name {
            get {return _name;} 
            set 
            {
                if (value != null && value != "")
                    _name = value;
            } 
        }

        public override void MakeSound()
        {
            Console.WriteLine("CaCaw!");
        }
    }
}