namespace Animals.AnimalsType.Cats
{
    public class Kitten : Cat
    {
        private const string gender = "Female";

        public Kitten(string name, int age) 
            : base(name, age, gender)
        {
        }

        public override string MakeNoise()
        {
            return "Meow";
        }
    }
}
