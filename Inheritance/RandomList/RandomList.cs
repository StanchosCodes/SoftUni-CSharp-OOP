using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random randomElement = new Random();

        public string RandomString()
        {
            int randomElementIndex = randomElement.Next(0, base.Count);
            string elementToRemove = base[randomElementIndex];
            base.RemoveAt(randomElementIndex);

            return elementToRemove;
        }
    }
}
