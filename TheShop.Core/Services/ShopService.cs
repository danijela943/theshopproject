using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces;
using TheShop.Core.Interfaces.Repositories;
using TheShop.Core.Interfaces.Services;
using TheShop.Core.Models;
using TheShop.Core.Models.Results;
using TheShop.Core.Shared.Sessions;
using TheShop.DAL.Data;
using TheShop.DAL.Entites;
using TheShop.DAL.Interfaces;
using TheShop.Entites;

namespace TheShop.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IPricingRepository _pricingRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<ShopService> _logger;

        public ShopService(
            IArticleRepository articleRepository, 
            IPricingRepository pricingRepository, 
            IOrderRepository orderRepository, 
            ILogger<ShopService> logger
        )
        {
            this._logger = logger;
            this._articleRepository = articleRepository;
            this._pricingRepository = pricingRepository;
            this._orderRepository = orderRepository;
        }

        public OperationResult<string> ShopArticle(ShopArticleFilter filter)
        {
            var articleId = filter.ArticleId;
            try
            {
                Pricing bestOffer = this.GetBestPricingOffer(filter.ArticleId, filter.MaxPrice);

                if (bestOffer != null)
                {
                    this._logger.Debug($"Trying to sell article with ID = {articleId}.");

                    OrderItem order = new OrderItem()
                    {
                        ArticleId = bestOffer.ArticleId,
                        BuyerId = Session.LoggedBuyer.Id,
                        SupplierId = bestOffer.SupplierId
                    };

                    this._orderRepository.Insert(order);
                    this._pricingRepository.UpdateAsSold(bestOffer.Id);

                    var message = $"Article with ID = ${articleId} is sold.";
                    this._logger.Info(message);
                    return OperationResult<string>.OK(message);
                }
                else
                {
                    var message = $"Don't have best offer for article with ID: {articleId}, " +
                                        $"MAX_PRICE: ${filter.MaxPrice}.";
                    this._logger.Info(message);
                    return OperationResult<string>.Error(Enums.ErrorType.NotFound, message);
                }
            }
            catch (Exception ex)
            {
                var message = $"Error on inserting order: { ex.Message } ";
                this._logger.Error(message);
                return OperationResult<string>.Error(Enums.ErrorType.ServerError, message);
            }
        }

        private Pricing GetBestPricingOffer(Guid articleId, int maxPrice)
        {
            List<Pricing> availablePricings = this._pricingRepository.GetPricingsForNotSoldArticle(articleId).ToList();
            if (availablePricings.Count > 0)
            {
                Pricing bestOffer = this._pricingRepository.GetPricingWhichPriceIsLessOrEqualThan(maxPrice, availablePricings);
                return bestOffer;
            }
            return null;
        }
    }
}
