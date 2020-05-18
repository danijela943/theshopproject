using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Entites;
using TheShop.Interfaces;

namespace TheShop.Core.Interfaces.Repositories
{
    public interface IPricingRepository : IRepository<Pricing>
    {
        IEnumerable<Pricing> GetPricingsForNotSoldArticle(Guid articleId);
        Pricing GetPricingWhichPriceIsLessOrEqualThan(double maxPrice, List<Pricing> pricings);
        void UpdateAsSold(Guid id);
    }
}
