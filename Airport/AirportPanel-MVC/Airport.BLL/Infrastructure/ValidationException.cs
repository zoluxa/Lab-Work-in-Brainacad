using System;

namespace Airport.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; }
        public ValidationException(string message, string property) : base(message)
        {
            this.Property = property;
        }
    }
}
