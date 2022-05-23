using System;

namespace _07.CustomException
{
    public class InvalidPersonNameException : Exception
    {
        private static readonly string ErrorMessage
            = "The name can not contains any special characters or numeric values.";

        public InvalidPersonNameException()
            : base(ErrorMessage)
        {
        }
    }
}