using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DAL.Entites;
using TheShop.DAL.Interfaces;
using TheShop.Entites;

namespace TheShop.DAL.Data
{
    public sealed class InMemoryStorage : IStorage
    {
        public static InMemoryStorage Instance { get { return InstanceSaver.instance; } }


        public List<Article> Articles { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Buyer> Buyers { get; set; }

        private List<Pricing> pricings;
        public List<Pricing> Pricings {
            get {
                return this.pricings;
            }
            set {
                this.pricings = value ?? throw new ArgumentNullException();
            }
        }
        public List<OrderItem> Orders { get; set; }
        
        private InMemoryStorage()
        {
            this.Initialize();
            this.LoadData();
        }

        private void Initialize()
        {
            this.Articles = new List<Article>();
            this.Suppliers = new List<Supplier>();
            this.Pricings = new List<Pricing>();
            this.Orders = new List<OrderItem>();
            this.Buyers = new List<Buyer>();
        }

        private void LoadData()
        {
            InMemorySeeder.Seed(this);
        }

        private class InstanceSaver
        {
            static InstanceSaver()
            {
            }

            internal static readonly InMemoryStorage instance = new InMemoryStorage();
        }
    }
}
