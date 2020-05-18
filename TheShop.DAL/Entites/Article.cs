using System;
using System.Collections.Generic;
using TheShop.DAL.Interfaces;

namespace TheShop.Entites
{
	public class Article : IEntity
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }

        public Article()
        {
            this.Id = Guid.NewGuid();
        }

        public Article(string name, int price)
        {
            this.Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{this.Id}:\t{this.Name}";
        }
        // Create -> ORDERED ITEMS, ORDERS!!
    }
}