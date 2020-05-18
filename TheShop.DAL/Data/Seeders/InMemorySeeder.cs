using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DAL.Interfaces;
using TheShop.Entites;

namespace TheShop.DAL.Data
{
    public static class InMemorySeeder
    {
        public static void Seed(InMemoryStorage storage)
        {
            storage.Buyers.Add(new Buyer() { Username = "Danijela" });
            storage.Buyers.Add(new Buyer() { Username = "Test" });

            #region Initialization of articles
            Article article1 = new Article()
            {
                Name = "Article 1",
            };
            Article article2 = new Article()
            {
                Name = "Article 2",
            };
            Article article3 = new Article()
            {
                Name = "Article 3",
            };
            Article article4 = new Article()
            {
                Name = "Article 4",
            };
            Article article5 = new Article()
            {
                Name = "Article 5",
            };
            #endregion

            #region Initialization of suppliers
            Supplier supplier1 = new Supplier()
            {
                Name = "Supplier 1",
            };
            Supplier supplier2 = new Supplier()
            {
                Name = "Supplier 2",
            };
            Supplier supplier3 = new Supplier()
            {
                Name = "Supplier 3",
            }; 
            #endregion

            #region Fill Pricing
            storage.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article1,
                Supplier = supplier2,
                ArticleId = article1.Id,
                SupplierId = supplier2.Id,
                Price = 134
            });
            storage.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article1,
                Supplier = supplier3,
                ArticleId = article1.Id,
                SupplierId = supplier3.Id,
                Price = 3445.56
            });
            storage.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article2,
                Supplier = supplier1,
                ArticleId = article2.Id,
                SupplierId = supplier1.Id,
                Price = 485
            });
            storage.Pricings.Add(new Pricing()
            {
                Id = Guid.NewGuid(),
                Article = article2,
                Supplier = supplier3,
                ArticleId = article2.Id,
                SupplierId = supplier3.Id,
                Price = 78
            });
            #endregion

            #region Relate Articles with Suppliers
            article1.Suppliers = storage.Pricings.Where(x => x.ArticleId == article1.Id).Select(x => x.Supplier);
            article2.Suppliers = storage.Pricings.Where(x => x.ArticleId == article2.Id).Select(x => x.Supplier);
            article3.Suppliers = storage.Pricings.Where(x => x.ArticleId == article3.Id).Select(x => x.Supplier);
            article4.Suppliers = storage.Pricings.Where(x => x.ArticleId == article4.Id).Select(x => x.Supplier);
            article5.Suppliers = storage.Pricings.Where(x => x.ArticleId == article5.Id).Select(x => x.Supplier);
            #endregion

            #region Relate Suppliers with Articles
            supplier1.Articles = storage.Pricings.Where(x => x.SupplierId == supplier2.Id).Select(x => x.Article);
            supplier2.Articles = storage.Pricings.Where(x => x.SupplierId == supplier2.Id).Select(x => x.Article);
            supplier2.Articles = storage.Pricings.Where(x => x.SupplierId == supplier2.Id).Select(x => x.Article);
            #endregion

            #region Fill Articles
            storage.Articles.Add(article1);
            storage.Articles.Add(article2);
            storage.Articles.Add(article3);
            storage.Articles.Add(article4);
            storage.Articles.Add(article5);
            #endregion

            #region Fill Suppliers
            storage.Suppliers.Add(supplier1);
            storage.Suppliers.Add(supplier2);
            storage.Suppliers.Add(supplier3); 
            #endregion
        }
    }
}
