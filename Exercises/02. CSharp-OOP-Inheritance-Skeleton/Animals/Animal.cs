using System;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int? age;
        private string gender;

        public Animal(string name, int? age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input");
                }

                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value == null)
                {
                    Console.WriteLine("Invalid input");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input");
                }

                this.gender = value;
            }
        }
        
        public virtual string MakeNoise()
        {
            return "Making some noise";
        }

        public override string ToString()
        {
            var result = 
                $"{this.GetType().Name}" + Environment.NewLine + 
                $"{this.name} {this.age} {this.gender}" + Environment.NewLine +
                $"{MakeNoise()}";

            return result;
        }
    }
}
