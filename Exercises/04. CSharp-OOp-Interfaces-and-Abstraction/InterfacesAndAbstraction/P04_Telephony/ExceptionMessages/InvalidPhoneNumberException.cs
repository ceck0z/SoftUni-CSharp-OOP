namespace P04_Telephony.ExceptionMessages
{
    using System;

    public class InvalidPhoneNumberException : Exception
    {
        private const string Exc_Message = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(Exc_Message)
        {

        }

        public InvalidPhoneNumberException(string message)
        {
            
        }
    }
}
