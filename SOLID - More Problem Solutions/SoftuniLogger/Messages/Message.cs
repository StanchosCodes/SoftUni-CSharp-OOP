namespace SoftuniLogger.Messages
{
    using Enums;
    using System;
    using Interfaces;
    using Exceptions;
    using Validators;
    using Validators.Interfaces;

    public class Message : IMessage
    {
        private const string EmptyArgumentMessage = "Argument should not be empty or white space!";

        private string logTime;
        private string messageText;
        private readonly IValidator dateTimeValidator;

        public Message()
        {
            this.dateTimeValidator = new DateTimeValidator();
        }

        public Message(string logTime, string messageText, ReportLevel level)
            : this()
        {
            this.LogTime = logTime;
            this.MessageText = messageText;
            this.Level = level;
        }
        public string MessageText
        {
            get
            {
                return this.messageText;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(MessageText), EmptyArgumentMessage);
                }

                this.messageText = value;
            }
        }

        public string LogTime
        {
            get
            {
                return this.logTime;
            }
            private set
            {
                if (this.dateTimeValidator.IsValid(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(LogTime), EmptyArgumentMessage);
                }

                this.logTime = value;
            }
        }

        public ReportLevel Level { get; }
    }
}
