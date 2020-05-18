using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DAL.Interfaces;

namespace TheShop.Entites
{
    public class Supplier : IEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public IEnumerable<Article> Articles { get; set; }

        public Supplier()
        {
            this.Id = Guid.NewGuid();
        }
        public Supplier(List<Article> articles)
        {
            this.Id = Guid.NewGuid();
            this.Articles = articles;
        }
    }
}
