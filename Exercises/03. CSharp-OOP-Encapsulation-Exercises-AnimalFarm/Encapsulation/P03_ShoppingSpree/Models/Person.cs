namespace P03_ShoppingSpree.Models
{
    using P03_ShoppingSpree.Exceptions;
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;

        private decimal money;

        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name,decimal money): this()
        {
            this.Name = name;
            this.Money = money;
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

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoney);
                }

                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            decimal moneyLeft = this.Money - product.Cost;

            if(moneyLeft < 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotAffordProductException, this.Name, product.Name));
            }

            this.Money = moneyLeft;

            this.bag.Add(product);
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", bag)}";
        }
    }
}
