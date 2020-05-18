using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DAL.Interfaces;

namespace TheShop.Entites
{
    public class Buyer : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public Buyer()
        {
            this.Id = Guid.NewGuid();
        }
        public Buyer(string username)
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
        }
    }
}
