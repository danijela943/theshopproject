using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Models;
using TheShop.Core.Models.Results;
using TheShop.Entites;

namespace TheShop.Core.Interfaces.Services
{
    public interface IShopService
    {
        OperationResult<string> ShopArticle(ShopArticleFilter filter);
    }
}
