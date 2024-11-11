using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingDay6.Files;

internal class InvalidNameException : Exception
{
    public InvalidNameException(string message) : base(message) { }
}
