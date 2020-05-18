using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces.Repositories;
using TheShop.Core.Models.Results;
using TheShop.Core.Repositories;
using TheShop.DAL.Data;
using TheShop.DAL.Services;
using TheShop.Entites;
using Xunit;

namespace TheShop.Core.Tests.Services
{
    
    public class ArticleServiceTest
    {
        private ArticleService _articleService;

        public ArticleServiceTest()
        {
            IArticleRepository articleRepository = new ArticleRepository(InMemoryStorage.Instance);
            this._articleService = new ArticleService(articleRepository, new ConsoleLogger<ArticleService>());
        }
        [Fact]
        public void GetFirstElementOfEmptyList_EmptyList()
        {
            InMemoryStorage.Instance.Articles = new List<Article>();
            try
            {
                var article = this._articleService.GetFirst();
                Assert.IsType<OperationResult<Article>>(article);
                Assert.True(article.Result == null);
                Assert.True(!article.Success);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.InnerException.ToString());
            }
        }

        [Fact]
        public void GetFirstElementIfNotEmptyList_OneItem()
        {
            InMemoryStorage.Instance.Articles = new List<Article>();
            InMemoryStorage.Instance.Articles.Add(new Article() { Name = "Test" });
            try
            {
                var article = this._articleService.GetFirst();
                Assert.IsType<OperationResult<Article>>(article);
                Assert.True(article.Result != null);
                Assert.True(article.Success);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public void GetByIdIfEmptyIdPassed_EmptyId()
        {
            InMemoryStorage.Instance.Articles = new List<Article>();
            InMemoryStorage.Instance.Articles.Add(new Article() { Id=Guid.NewGuid(), Name = "Test 1" });
            InMemoryStorage.Instance.Articles.Add(new Article() { Id = Guid.NewGuid(), Name = "Test 2" });
            try
            {
                var article = this._articleService.GetById(Guid.Empty);
                Assert.True(article.Result == null);
                Assert.True(!article.Success);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public void GetByIdIfArticleWithIdNotExists_NotExistingId()
        {
            InMemoryStorage.Instance.Articles = new List<Article>();
            InMemoryStorage.Instance.Articles.Add(new Article() { Id = Guid.NewGuid(), Name = "Test 1" });
            InMemoryStorage.Instance.Articles.Add(new Article() { Id = Guid.NewGuid(), Name = "Test 2" });

            try
            {
                var article = this._articleService.GetById(Guid.NewGuid());
                Assert.True(article.Result == null);
                Assert.True(!article.Success);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

    }
}
