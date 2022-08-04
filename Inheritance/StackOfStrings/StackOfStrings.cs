using System.Collections.Generic;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (base.Count == 0)
            {
                return true;
            }

            return false;
        }

        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (string element in elements)
            {
                base.Push(element);
            }

            return this;
        }
    }
}
