using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Models.Results;
using TheShop.Entites;

namespace TheShop.DAL.Interfaces
{
    public interface IArticleService
    {
        OperationResult<Article> GetById(Guid id);
        OperationResult<Article> GetFirst();
        OperationResult<List<Article>> GetAll();
    }
}
