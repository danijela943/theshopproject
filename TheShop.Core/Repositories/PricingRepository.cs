using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces;
using TheShop.Core.Interfaces.Repositories;
using TheShop.Core.Shared.Exceptions;
using TheShop.DAL.Data;
using TheShop.DAL.Entites;
using TheShop.Entites;

namespace TheShop.Core.Repositories
{
    public class PricingRepository : IPricingRepository
    {
        private InMemoryStorage _storage;
        public PricingRepository(InMemoryStorage storage)
        {
            this._storage = storage;
        }

        public IEnumerable<Pricing> GetPricingsForNotSoldArticle(Guid articleId)
        {
            return this._storage.Pricings.FindAll(x => x.ArticleId == articleId && !x.IsSold);
        }

        public Pricing GetPricingWhichPriceIsLessOrEqualThan(double maxPrice, List<Pricing> pricings)
        {
            pricings = pricings.Where(x => x.Price < maxPrice).ToList();
            if(pricings.Count > 0)
            {
                double minPrice = pricings.Min(x => x.Price);
                return pricings.Find(x => x.Price == minPrice);
            }
            return null;
        }

        public void UpdateAsSold(Guid id)
        {
            var order = this.GetById(id);
            order.IsSold = true;
            order.SoldDate = DateTime.Now;
        }

        public void Delete(Guid id)
        {
            var entity = this.GetById(id);
            if (entity == null)
            {
                throw new NotFoundException("Pricing not found.");
            }
            this._storage.Pricings.Remove(entity);
        }

        public void Edit(Guid id, Pricing entity)
        {
            var pricing = this.GetById(id);
            if (entity == null)
            {
                throw new NotFoundException("Pricing not found.");
            }
            pricing.ArticleId = entity.ArticleId;
            pricing.SupplierId = entity.SupplierId;
            pricing.Price = entity.Price;
        }

        public IEnumerable<Pricing> GetAll()
        {
            return this._storage.Pricings;
        }

        public Pricing GetById(Guid id)
        {
            var pricing = this._storage.Pricings.FirstOrDefault(x => x.Id == id);

            if (pricing == null)
            {
                throw new NotFoundException("Pricing not found.");
            }
            return pricing;
        }

        public void Insert(Pricing entity)
        {
            this._storage.Pricings.Add(entity);
        }

        public Pricing GetFirst()
        {
            throw new NotImplementedException();
        }
    }
}
