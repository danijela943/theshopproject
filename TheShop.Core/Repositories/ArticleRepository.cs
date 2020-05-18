using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Interfaces;
using TheShop.Core.Interfaces.Repositories;
using TheShop.Core.Shared.Exceptions;
using TheShop.DAL.Data;
using TheShop.Entites;
using TheShop.Interfaces;

namespace TheShop.Core.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private InMemoryStorage _storage;
        public ArticleRepository(InMemoryStorage storage)
        {
            this._storage = storage;   
        }
        public void Delete(Guid id)
        {
            var article = this.GetById(id);
            if(article != null)
            {
                this._storage.Articles.Remove(article);
            } else
            {
                throw new EntryPointNotFoundException();
            }
            
        }

        public void Edit(Guid id, Article entity)
        {
            var article = this.GetById(entity.Id);
            if (article != null)
            {
                article.Name = entity.Name;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }
        }

        public IEnumerable<Article> GetAll()
        {
            return this._storage.Articles;
        }

        public Article GetById(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var article = this._storage.Articles.Find(x => x.Id == id);
            if (article == null)
            {
                throw new NotFoundException("Article not found.");
            }
            return article;
        }

        public Article GetFirst()
        {
            var article = this._storage.Articles.ToList().ElementAtOrDefault(0);
            if (article == null)
            {
                throw new NotFoundException("Article not found.");
            }
            return article;
        }

        public void Insert(Article entity)
        {
            this._storage.Articles.Add(entity);
        }
    }
}
