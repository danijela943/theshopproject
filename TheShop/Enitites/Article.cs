using System;
using System.Collections.Generic;
using TheShop.Interfaces;

namespace TheShop.Models
{
	public class Article : IEntity
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
        public IEnumerable<Supplier> Suppliers { get; private set; }

        public Article()
        {
             
        }

        public Article(string name, int price)
        {
            this.Id = Guid.NewGuid();
        }
	}
}