using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces.Repositories;
using TheShop.DAL.Data;
using TheShop.DAL.Entites;

namespace TheShop.Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private InMemoryStorage _storage;
        public OrderRepository(InMemoryStorage storage)
        {
            this._storage = storage;
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Guid id, OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public OrderItem GetFirst()
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderItem entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }
            if (entity.SupplierId == null || this._storage.Suppliers.Find(x => x.Id == entity.SupplierId) == null)
            {
                throw new ArgumentException("Supplier ID is not falid!");
            }
            this._storage.Orders.Add(entity);
        }
    }
}
