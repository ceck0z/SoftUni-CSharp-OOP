﻿ namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            //TODO put your reflection code here
            Type typeHarvestingFields = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == nameof(HarvestingFields));

            FieldInfo[] fieldInfos = typeHarvestingFields
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            string accessModifierAsString = Console.ReadLine();

            while (accessModifierAsString != "HARVEST")
            {

                FieldInfo[] fieldInfoToPrint = null; 

                switch (accessModifierAsString)
                {
                    case "private":
                        fieldInfoToPrint = fieldInfos.Where(x => x.IsPrivate).ToArray();
                        break;

                    case "protected":
                        fieldInfoToPrint = fieldInfos.Where(x => x.IsFamily).ToArray();
                        break;

                    case "public":
                        fieldInfoToPrint = fieldInfos.Where(x => x.IsPublic).ToArray();
                        break;

                    default:
                        fieldInfoToPrint = fieldInfos;
                        break;
                }

                

                foreach (var fieldInfo in fieldInfoToPrint)
                {
                    string accessModifier = fieldInfo.Attributes.ToString().ToLower() == "family" ? "protected" : fieldInfo.Attributes.ToString().ToLower();

                    Console.WriteLine($"{accessModifier} {fieldInfo.FieldType.ToString()} {fieldInfo.Name}");
                }

                accessModifierAsString = Console.ReadLine();
            }

            Console.WriteLine();
        }

    }
}
