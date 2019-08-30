namespace P04_PizzaCalories.Exceptions
{
    public class ExceptionMessages
    {
        public static string InvalidDoughTypeException ="Invalid type of dough.";

        public static string InvalidDoughWeightException = "Dough weight should be in the range [{0}..{1}].";

        public static string InvalidToppingNameException = "Cannot place {0} on top of your pizza.";

        public static string InvalidToppingWeightException = "{0} weight should be in the range [{1}..{2}].";

        public static string InvalidNameLenghtException = "Pizza name should be between {0} and {1} symbols.";

        public static string InvalidNumberOfToppingsException = "Number of toppings should be in range [{0}..{1}].";
    }
}
