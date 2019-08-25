namespace P08_MilitaryElite.Exceptions
{
    using System;

    public class InvalidMissionCompletionException : Exception
    {
        private const string ExceptionMessage = "You cannot finish already completed mission!";

        public InvalidMissionCompletionException()
            : base(ExceptionMessage)
        {

        }

        public InvalidMissionCompletionException(string message) 
            : base(message)
        {

        }
    }
}
