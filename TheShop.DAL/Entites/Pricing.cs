using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DAL.Interfaces;

namespace TheShop.Entites
{
    public class Pricing : IEntity
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ArticleId { get; set; }
        public Supplier Supplier { get; set; }
        public Article Article { get; set; }
        public double Price { get; set; }

        // public int Quantity { get; set; } ...

        public bool IsSold { get; set; }
        public DateTime SoldDate { get; set; }

        public Pricing()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
