using System;

namespace SoftuniLogger.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage = "The log time was not correct";
        public InvalidDateTimeFormatException()
            : base(DefaultMessage)
        {

        }
    }
}
