using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            try
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException("The number is negative!");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(n));
                }
            }
            catch (ArgumentOutOfRangeException aore)
            {
                // Console.WriteLine(aore.Message);
                // returns - Specified argument was out of the range of valid values. (Parameter 'The number is negative!')
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
            
        }
    }
}
