using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DAL.Entites;
using TheShop.Interfaces;

namespace TheShop.Core.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<OrderItem>
    {
    }
}
