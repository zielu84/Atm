using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Models.Exceptions
{
    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException()
        {
        }

        public InvalidArgumentException(string message)
        : base(message)
        {
        }

        public InvalidArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvalidArgumentException(string message, string paramName)
            : base(message, paramName)
        {
        }
    }
}
