using System.Text;

namespace Person
{
    public class Person
    {
        public Person(string name,int age)
        {
            this.name = name;

            this.age = age;
        }

        public string name;

        public int age;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Name: {0}, Age: {1}",
                this.name,
                this.age));

            return sb.ToString();
        }
    }
}
