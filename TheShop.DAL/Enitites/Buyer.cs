using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Interfaces;

namespace TheShop.Models
{
    public class Buyer : IEntity
    {
        public Guid Id { get; private set; }
        public string Username { get; set; }

        public Buyer(string username)
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
        }
    }
}
