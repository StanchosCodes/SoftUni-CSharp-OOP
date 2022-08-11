using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            const int start = 1;
            const int end = 100;

            List<int> numbers = ReadNumbers(start, end);
            Console.WriteLine(string.Join(", ", numbers));
        }

        public static List<int> ReadNumbers(int start, int end)
        {
            List<int> numbers = new List<int>();

            string argument = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int n = int.Parse(argument);

                    if (n <= start || n >= end)
                    {
                        throw new ArgumentOutOfRangeException("The number is not in the range!");
                    }
                    else
                    {
                        start = n;
                        numbers.Add(n);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                    i--;
                }
                catch (Exception) // catches any exception - thats how we will catch the exception if the argument is a string
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                }
                if (numbers.Count == 10)
                {
                    break;
                }
                argument = Console.ReadLine();
            }

            return numbers;
        }
    }
}
