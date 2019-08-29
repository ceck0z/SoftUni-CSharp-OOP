using P07_FoodShortage.Contracts;

namespace P07_FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        private string group;

        public Rebel(string name,int age,string group)
        {
            this.Name = name;

            this.Age = age;

            this.group = group;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Age
        {
            get;
            private set;
        }

        public int Food
        {
            get;
            private set;
        }

        public void BuyFood()
        {
            this.Food +=  5;
        }
    }
}
