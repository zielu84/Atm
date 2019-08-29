using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.Models.Exceptions
{
    public class NoteUnavailableException : ArgumentException
    {
        public NoteUnavailableException()
        {
        }

        public NoteUnavailableException(string message)
        : base(message)
        {
        }

        public NoteUnavailableException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public NoteUnavailableException(string message, string paramName)
            : base(message, paramName)
        {
        }
    }
}
