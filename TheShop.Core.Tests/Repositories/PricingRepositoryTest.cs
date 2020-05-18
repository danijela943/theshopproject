using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Repositories;
using TheShop.Core.Shared.Exceptions;
using TheShop.DAL.Data;
using TheShop.Entites;
using Xunit;

namespace TheShop.Core.Tests.Repositories
{
    public class PricingRepositoryTest
    {
        private PricingRepository _pricingRepository;

        public PricingRepositoryTest()
        {
            this._pricingRepository = new PricingRepository(InMemoryStorage.Instance);
        }

        [Fact]
        public void GetPricingsForNotSoldArticle_OneNotSold()
        {
            InMemoryStorage.Instance.Pricings = new List<Entites.Pricing>();
            Article article1 = new Article()
            {
                Name = "Article 1",
            };
            Supplier supplier3 = new Supplier()
            {
                Name = "Supplier 3",
            };
            InMemoryStorage.Instance.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article1,
                Supplier = supplier3,
                ArticleId = article1.Id,
                SupplierId = supplier3.Id,
                Price = 10,
                IsSold = false
            });
            IEnumerable<Pricing> pricings = this._pricingRepository.GetPricingsForNotSoldArticle(article1.Id);
            Assert.True(pricings.Count() == 1, "One article is not sold!");
        }

        [Fact]
        public void GetPricingsForNotSoldArticle_MultipleNotSold()
        {
            InMemoryStorage.Instance.Pricings = new List<Pricing>();
            Article article1 = new Article()
            {
                Name = "Article 1",
            };
            Supplier supplier3 = new Supplier()
            {
                Name = "Supplier 3",
            };
            Supplier supplier4 = new Supplier()
            {
                Name = "Supplier 4",
            };
            InMemoryStorage.Instance.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article1,
                Supplier = supplier3,
                ArticleId = article1.Id,
                SupplierId = supplier3.Id,
                Price = 10,
                IsSold = false
            });
            InMemoryStorage.Instance.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article1,
                Supplier = supplier3,
                ArticleId = article1.Id,
                SupplierId = supplier3.Id,
                Price = 10,
                IsSold = true
            });
            InMemoryStorage.Instance.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article1,
                Supplier = supplier4,
                ArticleId = article1.Id,
                SupplierId = supplier4.Id,
                Price = 10,
                IsSold = false
            });
            IEnumerable<Pricing> pricings = this._pricingRepository.GetPricingsForNotSoldArticle(article1.Id);
            Assert.True(pricings.Count() == 2, "Two pricing is available");
        }

        [Fact]
        public void GetPricingsForNotSoldArticle_AllSold()
        {
            InMemoryStorage.Instance.Pricings = new List<Entites.Pricing>();
            Article article1 = new Article()
            {
                Name = "Article 1",
            };
            Supplier supplier3 = new Supplier()
            {
                Name = "Supplier 3",
            };
            InMemoryStorage.Instance.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article1,
                Supplier = supplier3,
                ArticleId = article1.Id,
                SupplierId = supplier3.Id,
                Price = 10,
                IsSold = true
            });
            IEnumerable<Pricing> pricings = this._pricingRepository.GetPricingsForNotSoldArticle(article1.Id);
            Assert.True(pricings.Count() == 0, "One article is not sold!");
        }


        [Fact]
        public void GetPricingsWhichPriceIsLessOrEqualThan_OneEqual()
        {
            InMemoryStorage.Instance.Pricings = new List<Pricing>();
            List<Pricing> pricings = new List<Pricing>();
            pricings.Add(new Pricing() { Price = 1000 });
            pricings.Add(new Pricing() { Price = 500 });
            Pricing availablePricings = this._pricingRepository.GetPricingWhichPriceIsLessOrEqualThan(1000, pricings);
            Assert.True(availablePricings != null);
        }

        [Fact]
        public void GetPricingsWhichPriceIsLessOrEqualThan_OneLess()
        {
            InMemoryStorage.Instance.Pricings = new List<Pricing>();
            List<Pricing> pricings = new List<Pricing>();
            pricings.Add(new Pricing() { Price = 1500 });
            pricings.Add(new Pricing() { Price = 500 });
            Pricing availablePricing = this._pricingRepository.GetPricingWhichPriceIsLessOrEqualThan(1000, pricings);
            Assert.True(availablePricing != null);
            Assert.True(availablePricing.Price == 500);
        }

        [Fact]
        public void GetPricingsWhichPriceIsLessOrEqualThan_MoreLess()
        {
            InMemoryStorage.Instance.Pricings = new List<Pricing>();
            List<Pricing> pricings = new List<Pricing>();
            pricings.Add(new Pricing() { Price = 100 });
            pricings.Add(new Pricing() { Price = 1500 });
            pricings.Add(new Pricing() { Price = 500 });
            Pricing availablePricing = this._pricingRepository.GetPricingWhichPriceIsLessOrEqualThan(1000, pricings);
            Assert.True(availablePricing != null);
            Assert.True(availablePricing.Price == 100);
        }

        [Fact]
        public void UpdateAsSold_NotExistingPricing()
        {
            InMemoryStorage.Instance.Pricings = new List<Pricing>();
            try
            {
                this._pricingRepository.UpdateAsSold(Guid.NewGuid());
                Assert.True(false, "Can't update not existing Pricing.");
            }
            catch(NotFoundException ex)
            {
                Assert.True(true);
            }
            
        }

        [Fact]
        public void UpdateAsSold_ExistingPricing()
        {
            InMemoryStorage.Instance.Pricings = new List<Pricing>();
            Pricing pricing = new Pricing();
            InMemoryStorage.Instance.Pricings.Add(pricing);
            try
            {
                this._pricingRepository.UpdateAsSold(pricing.Id);
                Assert.True(pricing.IsSold);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

        }

    }
}
