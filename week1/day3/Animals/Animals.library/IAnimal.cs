namespace Animals.library
{
    public interface IAnimal
    {
        string Name { get; set;}

        void MakeSound();

        void GoTo(string location);
    }
}