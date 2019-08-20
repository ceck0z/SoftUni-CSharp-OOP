namespace P03_Ferrari
{
    using P03_Ferrari.Models;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var driverName = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driverName);

            Console.WriteLine($"{ferrari.CarModel}/{ferrari.UseBrakes()}/{ferrari.PushTheGasPedal()}/{ferrari.Driver}");
        }
    }
}
