using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_1
{
    class ValueException : ArgumentException
    {
        public double Value { get; }

        public ValueException(string message, double val)
            : base(message)
        {
            Value = val;
        }
    }
}
