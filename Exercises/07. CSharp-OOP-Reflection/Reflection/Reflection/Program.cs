using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            var firstPersonType = typeof(Program)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Person");

            var firstInstance = Activator.CreateInstance(firstPersonType, BindingFlags.NonPublic | BindingFlags.Instance,null,new object[] {"Gosho",15 },null );

            var constructor = firstPersonType.GetConstructors()[0];
            
            var secondInstance = constructor.Invoke(new object[] { "Pesho" });

            var fields = firstPersonType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.GetCustomAttributes(false).Length == 0);

            var field = firstPersonType.GetField("age", BindingFlags.Instance | BindingFlags.NonPublic);
            
            var method = firstPersonType.GetMethod("Sleep", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(firstInstance, new object[] { });
            
            var allMethods = firstPersonType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var property = firstPersonType.GetProperty("Age");
            
            Console.WriteLine();
        }
    }
}
