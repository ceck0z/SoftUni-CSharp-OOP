
using P04_Telephony.ExceptionMessages;
using P04_Telephony.Models;
using System;
using System.Linq;

namespace P04_Telephony.Core
{
    public class Engine
    {
        private Smartphone smartphone;

        public Engine()
        {
            this.smartphone = new Smartphone();
        }

        public Engine(Smartphone smartphone)
        {
            this.smartphone = smartphone;
        }

        public void Run()
        {
            string[] numbers = Console.ReadLine()
                .Split(" ")
                .ToArray();
            string[] urls = Console.ReadLine().Split(" ").ToArray();

            CallNumbers(numbers);

            BrowseInternet(urls);
        }

        private void BrowseInternet(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidURLException iue)
                {
                    Console.WriteLine(iue.Message);
                }
            }
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    Console.WriteLine(ipne.Message);
                }
            }
        }
    }
}
