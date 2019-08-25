namespace P08_MilitaryElite.Exceptions
{
    using System;

    public class InvalidCorpsException : Exception
    {
        public const string ExceptionMessage = "Invalid corps";

        public InvalidCorpsException() 
            : base(ExceptionMessage)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}
