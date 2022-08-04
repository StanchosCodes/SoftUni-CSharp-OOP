using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings newStackOfStrings = new StackOfStrings();
            List<string> newList = new List<string>() { "Pesho", "Gosho", "Pencho", "Stancho" };

            Console.WriteLine(newStackOfStrings.IsEmpty());

            newStackOfStrings.AddRange(newList);

            Console.WriteLine(newStackOfStrings.IsEmpty());
        }
    }
}
