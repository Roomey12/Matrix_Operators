using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_1
{
    class MatrixException : ArgumentException
    {
        public MatrixException(string str, Exception inner) : base(str, inner) { }
        public MatrixException(string message) : base(message) { }
    }
}
