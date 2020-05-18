using System;
using TheShop.Core.Interfaces;
using TheShop.Core.Interfaces.Repositories;
using TheShop.Core.Interfaces.Services;
using TheShop.Core.Models;
using TheShop.Core.Repositories;
using TheShop.Core.Services;
using TheShop.Core.Shared.Sessions;
using TheShop.DAL.Data;
using TheShop.DAL.Interfaces;
using TheShop.DAL.Services;
using TheShop.Entites;

namespace TheShop
{
	internal class Program
	{
        static InMemoryStorage storage;

        static IArticleRepository articleRepository;
        static IPricingRepository pricingRepository;
        static IOrderRepository orderRepository;
        static ILogger<ShopService> logger;
        static IArticleService articleService;
        static IShopService shopService;


        private static void Main(string[] args)
		{

            InstanciateDependancies();
            SetSession(); // TODO: from storage

            ShopArticleFilter filter = null;
            var firstArticle = articleService.GetFirst().Result;
            if (firstArticle != null)
            {
                articleFilter = new ShopArticleFilter(firstArticle.Id, 500);
                shopService.ShopArticle(articleFilter);
            }

            ShowAllArticles();

            Console.WriteLine("Enter Article ID to find in inventory:");
            Guid articleId;
            Guid.TryParse(Console.ReadLine(), out articleId);

            Console.WriteLine("Enter MAX PRICE:");
            int maxPrice;
            Int32.TryParse(Console.ReadLine(), out maxPrice);

            filter = new ShopArticleFilter(articleId, maxPrice);
            shopService.ShopArticle(filter);

            Console.ReadKey();
        }

        private static void InstanciateDependancies() 
        {
            #region Preparing for dependancy injection
            storage = InMemoryStorage.Instance;
            articleRepository = new ArticleRepository(storage);
            pricingRepository = new PricingRepository(storage);
            orderRepository = new OrderRepository(storage);
            logger = new Core.ConsoleLogger<ShopService>();
            #endregion
            articleService = new ArticleService(articleRepository, new Core.ConsoleLogger<ArticleService>());
            shopService = new ShopService(articleRepository, pricingRepository, orderRepository, logger);
        }
        private static void ShowAllArticles()
        {
            var articles = articleService.GetAll().Result;
            articles.ForEach(article =>
            {
                Console.WriteLine(article.ToString());
            });
        }

        private static void SetSession()
        {
            Session.Set(new Buyer() { Id = Guid.NewGuid(), Username = "danijela" });
        }
    }
}
