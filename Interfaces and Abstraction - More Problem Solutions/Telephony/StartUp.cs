using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            MobilePhone mobile = new MobilePhone();
            StationaryPhone stationary = new StationaryPhone();

            foreach (string phoneNumber in phoneNumbers)
            {
               if (IsValidNumber(phoneNumber))
                {
                    if (IsMobile(phoneNumber))
                    {
                        Console.WriteLine(mobile.Call(phoneNumber));
                    }
                    else
                    {
                        Console.WriteLine(stationary.Call(phoneNumber));
                    }    
                }
               else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (string url in urls)
            {
                if (IsUrlValid(url))
                {
                    Console.WriteLine(mobile.Browse(url));
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
        private static bool IsValidNumber(string phoneNumber)
        {
            foreach (char digit in phoneNumber)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsMobile(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                return true;
            }

            return false;
        }

        private static bool IsUrlValid(string url)
        {
            foreach (char symbol in url)
            {
                if (char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
