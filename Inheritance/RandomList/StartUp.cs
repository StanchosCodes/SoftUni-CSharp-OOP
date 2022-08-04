using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList testList = new RandomList() { "test1", "test2", "test3", "test4" };

            Console.WriteLine($"{testList.RandomString()}");
        }
    }
}
