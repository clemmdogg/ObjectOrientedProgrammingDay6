using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingDay6.Files;

internal class InvalidEmailException : Exception
{
    public InvalidEmailException(string message) : base(message) { }
}
