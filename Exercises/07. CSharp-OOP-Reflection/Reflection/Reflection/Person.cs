using System;

namespace Reflection
{
    public class Person : Human
    {
        private string name;
        protected int age;
        public int workingHours;

        private Person()
        {

        }

        protected Person(int age)
        {
            this.age = age;
        }

        internal Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Person(string name)
        {
            this.name = name;
        }

        public string Name { get; set; }

        internal int Age { get; set; }

        private void Eat()
        {
            Console.WriteLine("Eating...");
        }

        protected void Sleep()
        {
            Console.WriteLine("Sleeping...");
        }

        //public void Work()
        //{
        //    Console.WriteLine("Working...");
        //}

        protected override void Work()
        {
            Console.WriteLine("Working...");
        }
    }
}
