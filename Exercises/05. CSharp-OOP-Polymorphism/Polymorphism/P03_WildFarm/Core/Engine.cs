namespace P03_WildFarm.Core
{
    using P03_WildFarm.Models;
    using P03_WildFarm.Models.Animals.Entities;
    using P03_WildFarm.Models.Animals.Factory;
    using P03_WildFarm.Models.Foods.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Animal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<Animal>();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {

            string command = Console.ReadLine();

            while (command != "End")
            {
                string foodInput = Console.ReadLine();

                Animal animal = GetAnimal(command);
                IFood food = GetFood(foodInput);

                Console.WriteLine(animal.AskFood());

                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
                                
            }

            PrintOutPut();
        }

        private void PrintOutPut()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IFood GetFood(string foodInput)
        {
            string[] foodArgs = foodInput
                .Split(" ")
                .ToArray();

            string foodType = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            IFood food = this.foodFactory.ProduceFood(foodType, quantity);

            return food;
        }

        private Animal GetAnimal(string command)
        {
            string[] animalArgs = command.
                Split(" ").
                ToArray();

            string type = animalArgs[0];

            string name = animalArgs[1];

            //double weight = double.Parse(animalArgs[2]);

            Animal animal;

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalArgs[4]);

                animal = new Hen(name, weight, wingSize);
            }
            else 
            {
                string livingRegion = animalArgs[3];

                if (type =="Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalArgs[4];

                    if( type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if(type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid animal type!");
                    }

                }
            }

            this.animals.Add(animal);

            return animal;
        }
    }
}
