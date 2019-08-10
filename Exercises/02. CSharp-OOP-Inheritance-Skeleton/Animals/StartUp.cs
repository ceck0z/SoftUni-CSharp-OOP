namespace Animals
{
    using System;
    using Animals.AnimalsType;
    using Animals.AnimalsType.Cats;

    public class StartUp
    {
        public static void Main(string[] args)
        {
           

            while (true)
            {
                string animalType = Console.ReadLine();

                if(animalType == "Beast!")
                {
                    break;
                }

                var animalInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var animalName = animalInfo[0];
                int animalAge;

                bool ageParse = int.TryParse(animalInfo[1],out animalAge);
                animalAge = ageParse != true ? -1 : animalAge;
                var animalGender = animalInfo[2];

                Animal animal = null;

                switch (animalType)
                {
                    case "Cat":
                        animal = new Cat(animalName, animalAge, animalGender);
                        break;
                    case "Dog":
                        animal = new Dog(animalName, animalAge, animalGender);
                        break;
                    case "Frog":
                        animal = new Frog(animalName, animalAge, animalGender);
                        break;
                    case "Kitten":
                        animal = new Kitten(animalName,animalAge);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(animalName, animalAge);
                        break;

                }

                if(animal != null)
                {
                    Console.WriteLine(animal.MakeNoise());
                }
               
                
            }    

        }
    }
}
