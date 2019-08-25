namespace P06_BirthdayCelebration.Models
{
    using P06_BirthdayCelebration.Contracts;
    using System;

    public class Citizen : IIdentifiable, IBirthdate
    {
        public Citizen(string name,int age, string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate =  DateTime.ParseExact(birthdate,"dd/mm/yyyy",null);
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public DateTime Birthdate { get; private set; }

    }
}
