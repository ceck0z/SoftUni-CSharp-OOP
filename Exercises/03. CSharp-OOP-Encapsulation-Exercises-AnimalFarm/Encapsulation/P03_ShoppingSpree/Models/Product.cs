namespace P03_ShoppingSpree.Models
{
    using P03_ShoppingSpree.Exceptions;
    using System;

    public class Product
    {
        private string name;

        private decimal cost;

        public Product(string name,decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value <0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoney);
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
