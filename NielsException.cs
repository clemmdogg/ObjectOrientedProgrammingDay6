using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingDay6;

internal class NielsException : Exception
{
    public NielsException(string message) : base(message) { }
}
