using System;

namespace SumOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split();

            int sum = 0;
            string element = string.Empty;

            for (int i = 0; i < nums.Length; i++)
            {
                try
                {
                    element = nums[i];
                    int num = int.Parse(nums[i]);

                    sum += num;
                    Console.WriteLine($"Element '{num}' processed - current sum: {sum}");
                }
                // catch the possible exceptions
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                    continue;
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
