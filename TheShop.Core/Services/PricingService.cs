using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces;
using TheShop.Core.Interfaces.Services;
using TheShop.DAL.Entites;
using TheShop.Entites;
using TheShop.Interfaces;

namespace TheShop.Core.Services
{
    public class PricingService : IPricingService
    {
        private readonly IRepository<Pricing> _pricingRepository;
        private readonly ILogger<PricingService> _logger;

        public PricingService(
            IRepository<Pricing> articleRepository, 
            ILogger<PricingService> logger
        )
        {
            this._pricingRepository = articleRepository;
            this._logger = logger;
        }
        
    }
}
