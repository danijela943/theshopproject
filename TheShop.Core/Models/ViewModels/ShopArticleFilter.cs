using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Shared.Exceptions;

namespace TheShop.Core.Models
{
    public class ShopArticleFilter
    {
        public Guid ArticleId { get; private set; }
        public int MaxPrice { get; private set; }

        public ShopArticleFilter(Guid articleId, int maxPrice)
        {
            if (articleId == null)
            {
                throw new ArgumentNullException();
            }
            
            if (maxPrice == 0)
            {
                throw new ZeroException("Max price cant be 0.");
            }

            this.ArticleId = articleId;
            this.MaxPrice = maxPrice;
        }
    }
}
