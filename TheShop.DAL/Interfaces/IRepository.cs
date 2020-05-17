using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Edit(TEntity entity);
        void Insert(TEntity entity);
        void Delete(Guid id);
    }
}
