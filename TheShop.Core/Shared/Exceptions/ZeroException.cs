using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Core.Shared.Exceptions
{
    public class ZeroException : Exception
    {

        public ZeroException(string message) : base($"Argument cannot be 0: ${message}.")
        {

        }
    }
}
