using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces;
using TheShop.Core.Models.Results;
using TheShop.DAL.Interfaces;
using TheShop.Entites;
using TheShop.Interfaces;

namespace TheShop.DAL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(
            IRepository<Article> articleRepository, 
            ILogger<ArticleService> logger
        )
        {
            this._articleRepository = articleRepository;
            this._logger = logger;
        }

        public OperationResult<List<Article>> GetAll()
        {
            var articles = this._articleRepository.GetAll().ToList();
            return OperationResult<List<Article>>.OK(articles);
        }

        public OperationResult<Article> GetById(Guid id)
        {
            try
            {
                var article = this._articleRepository.GetById(id);
                return OperationResult<Article>.OK(article);
            }
            catch(Exception ex)
            {
                return OperationResult<Article>.Error(Core.Enums.ErrorType.ServerError, $"GetById() article fail: {ex.Message}");
            }
        }

        public OperationResult<Article> GetFirst()
        {
            try
            {
                var article = this._articleRepository.GetFirst();
                if(article == null)
                {
                    return OperationResult<Article>.Error(Core.Enums.ErrorType.NotFound, $"First article not found");
                }
                return OperationResult<Article>.OK(article);
            }
            catch(Exception ex)
            {
                this._logger.Error($"GetFirst() article fail: {ex.Message}");
                return OperationResult<Article>.Error(Core.Enums.ErrorType.ServerError, $"GetFirst() article fail: {ex.Message}");

            }
        }

        
    }
}
