using System;

namespace P08_MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string ExceptionMessage = "Invalid mission state!";
        public InvalidStateException() 
            : base(ExceptionMessage)
        {

        }

        public InvalidStateException(string message) 
            : base(message)
        {
            
        }
    }
}
