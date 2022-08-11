namespace Telephony
{
    public class MobilePhone : ICallable, IBrowseable
    {
        public string Call(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }
    }
}
