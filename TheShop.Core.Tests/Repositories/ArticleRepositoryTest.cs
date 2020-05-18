using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces.Repositories;
using TheShop.Core.Repositories;
using TheShop.Core.Shared.Exceptions;
using TheShop.DAL.Data;
using TheShop.Entites;
using Xunit;

namespace TheShop.Core.Tests.Repositories
{
    public class ArticleRepositoryTest
    {
        private ArticleRepository _articleRepository;

        public ArticleRepositoryTest()
        {
            this._articleRepository = new ArticleRepository(InMemoryStorage.Instance);
        }

        [Fact]
        public void GetByIdIfEmptyIdPassedArgumentNullException()
        {
            InMemoryStorage.Instance.Articles = new List<Entites.Article>();
            InMemoryStorage.Instance.Articles.Add(new Article() { Id = Guid.NewGuid(), Name = "Test 1" });
            InMemoryStorage.Instance.Articles.Add(new Article() { Id = Guid.NewGuid(), Name = "Test 2" });
            try
            {
                var article = this._articleRepository.GetById(Guid.Empty);
                Assert.True(article == null, "ArgumentNullException is not thrown!");
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(true, "ArgumentNullException is thrown!");
            }
        }

        [Fact]
        public void GetByIdIfArticleWithIdNotExistsNotFoundException()
        {
            InMemoryStorage.Instance.Articles = new List<Entites.Article>();
            InMemoryStorage.Instance.Articles.Add(new Article() { Id = Guid.NewGuid(), Name = "Test 1" });
            InMemoryStorage.Instance.Articles.Add(new Article() { Id = Guid.NewGuid(), Name = "Test 2" });

            try
            {
                var article = this._articleRepository.GetById(Guid.NewGuid());
                Assert.True(article == null, "NotFoundException is not thrown!");
            }
            catch (NotFoundException ex)
            {
                Assert.True(true, "NotFoundException is thrown!");
            }
        }
    }
}
