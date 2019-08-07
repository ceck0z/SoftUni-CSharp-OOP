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
            string command = Console.ReadLine();
            
            while (command != "Beast!")
            {
                string[] animalInformation = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command == "Cat")
                {
                    var catName = animalInformation[0];
                    int catAge = int.Parse(animalInformation[1]);
                    var catGender = animalInformation[2];

                    Cat cat = new Cat(catName, catAge, catGender);

                    Console.WriteLine(cat.MakeNoise());
                }
                else if(command == "Dog")
                {
                    var dogName = animalInformation[0];
                    var dogAge = int.Parse(animalInformation[1]);
                    var dogGender = animalInformation[2];

                    Dog dog = new Dog(dogName, dogAge, dogGender);
                    
                    Console.WriteLine(dog.MakeNoise());
                }
                else if(command == "Frog")
                {
                    var frogName = animalInformation[0];
                    var frogAge = int.Parse(animalInformation[1]);
                    var frogGender = animalInformation[2];

                    Frog frog = new Frog(frogName, frogAge, frogGender);

                    Console.WriteLine(frog.MakeNoise());
                }
                command = Console.ReadLine();

            }    

        }
    }
}
