using P01_Vehicles.Models;
using System;
using System.Linq;

namespace P01_Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] command = Console.ReadLine()
                .Split(" ")
                .ToArray();

            Vehicle car = new Car(double.Parse(command[1]), double.Parse(command[2]));

            command = Console.ReadLine()
                .Split(" ")
                .ToArray();

            Vehicle truck = new Truck(double.Parse(command[1]), double.Parse(command[2]));

            int commandsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNumber; i++)
            {
                command = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string action = command[0];
                string vehicleType = command[1];
                double quantity = double.Parse(command[2]);

                if (vehicleType == "Car")
                {
                   if(action == "Drive")
                   {
                        Console.WriteLine(car.Drive(quantity));    
                   }
                   else if (action == "Refuel")
                   {
                        car.Refuel(quantity);
                   }
                }
                else if (vehicleType == "Truck")
                {
                    if (action == "Drive")
                    {
                        Console.WriteLine(truck.Drive(quantity));
                    }
                    else if (action =="Refuel")
                    {
                        truck.Refuel(quantity);
                    }
                }               
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
    }
}
