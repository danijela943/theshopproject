using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Interfaces;

namespace TheShop.Models
{
    class Pricing : IEntity
    {
        public Guid Id { get; private set; }
        public int SupplierId { get; set; }
        public int ArticleId { get; set; }
        public Supplier Supplier { get; set; }
        public Article Article { get; set; }
        public double Price { get; set; }

        //public Buyer Buyer { get; set; }
        //public bool IsSold { get; set; }
        //public DateTime SoldDate { get; set; }

        public Pricing()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
