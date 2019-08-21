namespace P04_Telephony.Models
{
    using P04_Telephony.Contracts;
    using System.Linq;
    using P04_Telephony.ExceptionMessages;

    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone()
        {

        }

        public string Browse(string URL)
        {
            if(URL.Any(c => char.IsDigit(c)))
            {
                throw new InvalidURLException();
            }
            return $"Browsing: {URL}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c => char.IsDigit(c)))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"Calling... {phoneNumber}";
        }
    }
}
