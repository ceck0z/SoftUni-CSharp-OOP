using P05_BorderControl.Contracts;
using P05_BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_BorderControl.Core
{
    class Engine
    {
        public void Run()
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(" ")
                    .ToArray();

                if (commandArgs.Length == 2)
                {
                    string robotModel = commandArgs[0];

                    string robotId = commandArgs[1];

                    Robot robot = new Robot(robotModel, robotId);

                    identifiables.Add(robot);

                }
                else if (commandArgs.Length == 3)
                {
                    string citizenName = commandArgs[0];

                    int citizenAge = int.Parse(commandArgs[1]);

                    string citizenId = commandArgs[2];

                    Citizen citizen = new Citizen(citizenName, citizenAge, citizenId);

                    identifiables.Add(citizen);
                }

                command = Console.ReadLine();
            }

            string fakeIds = Console.ReadLine();

            identifiables.Where(i => i.Id.EndsWith(fakeIds))
                .Select(i => i.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
