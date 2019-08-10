namespace P01.ClassBoxData
{
    using P01.ClassBoxData.Models;
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.CalculateVolume():f2}");

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }

    }
}
