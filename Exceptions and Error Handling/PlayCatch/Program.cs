using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine().Split();

                    string type = cmdArgs[0];
                    int firstParam = int.Parse(cmdArgs[1]);

                    if (type == "Replace")
                    {
                        int secParam = int.Parse(cmdArgs[2]);

                        numbers[firstParam] = secParam;
                    }
                    else if (type == "Show")
                    {
                        Console.WriteLine(numbers[firstParam]);
                    }
                    else if (type == "Print")
                    {
                        int secParam = int.Parse(cmdArgs[2]);

                        if (secParam >= numbers.Count)
                        {
                            throw new ArgumentOutOfRangeException();
                        }

                        for (int i = firstParam; i <= secParam; i++)
                        {
                            if (i != secParam)
                            {
                                Console.Write($"{numbers[i]}, ");
                            }
                            else
                            {
                                Console.WriteLine(numbers[i]);
                            }
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
