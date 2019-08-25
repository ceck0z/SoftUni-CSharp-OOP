namespace P06_BirthdayCelebration.Core
{
    using P06_BirthdayCelebration.Contracts;
    using P06_BirthdayCelebration.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            List<IBirthdate> birthdates = new List<IBirthdate>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(" ")
                    .ToArray();

                string type = commandArgs[0];

                if (type == "Citizen")
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    string id = commandArgs[3];
                    string birthdate = commandArgs[4];

                    Citizen citizen = new Citizen(name,age,id,birthdate);

                    birthdates.Add(citizen);
                }
                else if (type == "Robot")
                {
                    string model = commandArgs[1];
                    string id = commandArgs[2];

                    Robot robot = new Robot(model, id);
                }
                else if (type == "Pet")
                {
                    string name = commandArgs[1];
                    string birthdate = commandArgs[2];

                    Pet pet = new Pet(name,birthdate);

                    birthdates.Add(pet);
                }

                command = Console.ReadLine();
            }

            int birthYear = int.Parse(Console.ReadLine());

            birthdates
                .Where(b => b.Birthdate.Year == birthYear)
                .Select(b => b.Birthdate)
                .ToList()
                .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));
        }
    }
}
