using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Entites;

namespace TheShop.DAL.Entites
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ArticleId { get; set; }
        public Guid BuyerId { get; set; }
        public Supplier Supplier { get; set; }
        public Article Article { get; set; }
        public Buyer Buyer { get; set; }
    }
}
