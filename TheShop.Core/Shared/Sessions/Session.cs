using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Entites;

namespace TheShop.Core.Shared.Sessions
{
    public static class Session
    {
        public static Buyer LoggedBuyer { get; private set; }

        public static void Set(Buyer buyer)
        {
            LoggedBuyer = buyer;
        }

        public static void Destroy()
        {
            LoggedBuyer = null;
        }
    }
}
