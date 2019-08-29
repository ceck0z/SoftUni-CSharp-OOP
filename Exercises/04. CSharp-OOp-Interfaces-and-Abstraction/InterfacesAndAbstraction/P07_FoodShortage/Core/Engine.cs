namespace P07_FoodShortage.Core
{
    using P07_FoodShortage.Contracts;
    using P07_FoodShortage.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();
                          
            int rowsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < rowsCount; i++)
            {
                string command = Console.ReadLine();

                string[] commandArgs = command
                    .Split(" ")
                    .ToArray();

                if (commandArgs.Length == 3)
                {

                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string group = commandArgs[2];

                    Rebel rebel = new Rebel(name, age, group);

                    buyers.Add(rebel);
                }
                else if (commandArgs.Length > 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];
                    string birthdate = commandArgs[3];


                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(citizen);
                }
            }

            string cmnd = Console.ReadLine();

            while (cmnd != "End")
            {
                var buyer = buyers.SingleOrDefault(b => b.Name == cmnd);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                cmnd = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));

        }
    }
}
