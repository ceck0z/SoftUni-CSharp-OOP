namespace Animals
{
    using System;
    using System.Text;
    using Animals.AnimalsType;
    using Animals.AnimalsType.Cats;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog("Goshi", 1, "Male");

            StringBuilder sb = new StringBuilder();

            sb.Append(dog.Name + Environment.NewLine);
            sb.Append(dog.Age + Environment.NewLine);
            sb.Append(dog.Gender + Environment.NewLine);

            Console.WriteLine(sb.ToString());

            Console.WriteLine(dog.MakeNoise());

            Cat cat = new Cat("Mariancho", 3, "Female");

            Console.WriteLine(cat.MakeNoise());

            Frog frog = new Frog("Kermit", 2, "Male");

            Console.WriteLine(frog.MakeNoise());

            Kitten kitten = new Kitten("Pepka", 1);

            Console.WriteLine(kitten.MakeNoise());

            Tomcat tomcat = new Tomcat("Chepi", 4);

            Console.WriteLine(tomcat.MakeNoise());

        }
    }
}
