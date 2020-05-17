using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Interfaces;
using TheShop.Suppliers;

namespace TheShop.Models
{
    public class Supplier : IEntity
    {
        public Guid Id { get; private set; }
        public IEnumerable<Article> Articles { get; private set; }

        public Supplier(List<Article> articles)
        {
            this.Id = Guid.NewGuid();
            this.Articles = articles;
        }
    }
}
