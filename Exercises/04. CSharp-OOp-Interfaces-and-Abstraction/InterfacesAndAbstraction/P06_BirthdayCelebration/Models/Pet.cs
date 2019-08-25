namespace P06_BirthdayCelebration.Models
{
    using P06_BirthdayCelebration.Contracts;
    using System;

    public class Pet : IBirthdate
    {
        public Pet(string name,string birthdate)
        {
            this.Name = name;

            this.Birthdate = DateTime.ParseExact(birthdate,"dd/mm/yyyy",null);
        }

        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
