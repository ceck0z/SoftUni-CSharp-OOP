
namespace P04_Telephony.ExceptionMessages
{
    using System;   

    public class InvalidURLException : Exception
    {
        private const string Exc_Message = "Invalid URL!";

        public InvalidURLException() 
            : base(Exc_Message)
        {

            }

        public InvalidURLException(string message) 
            : base(message)
        {

        }
    }
}
