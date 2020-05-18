using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Core.Interfaces
{
    public interface ILogger<T>
    {
        void Info(string message);

        void Error(string message);

        void Debug(string message);
    }
}
