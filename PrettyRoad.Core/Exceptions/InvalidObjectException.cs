using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyRoad.Core.Exceptions
{
    public class InvalidObjectException : Exception
    {
        public InvalidObjectException(string exceptionText) : base(exceptionText)
        {

        }
    }
}
