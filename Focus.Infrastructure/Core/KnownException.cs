using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Core
{
    public class KnownException : Exception
    {
        public KnownException(string message) : base(string.IsNullOrEmpty(message) ? "Unknown Exception" : message)
        {

        }
    }
}
