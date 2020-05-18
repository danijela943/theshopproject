using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces.Repositories;
using TheShop.Core.Models;
using TheShop.Core.Repositories;
using TheShop.Core.Services;
using TheShop.Core.Shared.Sessions;
using TheShop.DAL.Data;
using TheShop.Entites;
using Xunit;

namespace TheShop.Core.Tests.Services
{
    public class ShopServiceTest
    {
        private ShopService _shopService;

        public ShopServiceTest()
        {
            IArticleRepository articleRepository = new ArticleRepository(InMemoryStorage.Instance);
            IPricingRepository pricingRepository = new PricingRepository(InMemoryStorage.Instance);
            IOrderRepository orderRepository = new OrderRepository(InMemoryStorage.Instance);
            this._shopService = new ShopService(articleRepository, pricingRepository, orderRepository, new ConsoleLogger<ShopService>());
            Session.Set(new Buyer("Danijela"));
        }

        [Fact]
        public void ShopArticle()
        {
            InMemoryStorage.Instance.Pricings = new List<Pricing>();
            InMemoryStorage.Instance.Articles = new List<Article>();
            InMemoryStorage.Instance.Suppliers = new List<Supplier>();

            Article article1 = new Article()
            {
                Name = "Article 1",
                
            };
            Supplier supplier3 = new Supplier()
            {
                Name = "Supplier 3",
            };

            var expenctedGuid = Guid.NewGuid();
            InMemoryStorage.Instance.Pricings.Add(new Pricing()
            {
                Id = expenctedGuid,
                Article = article1,
                Supplier = supplier3,
                ArticleId = article1.Id,
                SupplierId = supplier3.Id,
                Price = 10,
                IsSold = false
            });

            article1.Suppliers = InMemoryStorage.Instance.Pricings.Where(x => x.ArticleId == article1.Id).Select(x => x.Supplier);
            supplier3.Articles = InMemoryStorage.Instance.Pricings.Where(x => x.SupplierId == supplier3.Id).Select(x => x.Article);

            InMemoryStorage.Instance.Articles.Add(article1);
            InMemoryStorage.Instance.Suppliers.Add(supplier3);

            var filter = new ShopArticleFilter(article1.Id, 500);
            var result = this._shopService.ShopArticle(filter);
            Assert.True(result.Success);
            Assert.True(result.Result != null);
            Assert.True(InMemoryStorage.Instance.Pricings.FirstOrDefault(x => x.Id == expenctedGuid).IsSold);
        }
    }
}
