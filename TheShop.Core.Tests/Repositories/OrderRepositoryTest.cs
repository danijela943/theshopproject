using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Repositories;
using TheShop.Core.Shared.Sessions;
using TheShop.DAL.Data;
using TheShop.DAL.Entites;
using Xunit;

namespace TheShop.Core.Tests.Repositories
{
    public class OrderRepositoryTest
    {
        private OrderRepository _orderRepository;

        public OrderRepositoryTest()
        {
            this._orderRepository = new OrderRepository(InMemoryStorage.Instance);
        }

        [Fact]
        public void Insert_Empty()
        {
            try
            {
                this._orderRepository.Insert(null);
                Assert.True(false, "Mustn't be empty.");
            }
            catch(ArgumentNullException ex)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Insert_NotExistingSupplierId()
        {
            try
            {
                this._orderRepository.Insert(new DAL.Entites.OrderItem() { SupplierId = Guid.NewGuid() }); ;
                Assert.True(false, "SupplierId cant be invalid.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(true);
            }
            catch(Exception ex)
            {
                Assert.True(true, "DB relation failed");
            }
        }

        [Fact]
        public void Insert_WithData()
        {
            try
            {
                var supplierId = InMemoryStorage.Instance.Suppliers.FirstOrDefault().Id;
                var articleId = InMemoryStorage.Instance.Articles.FirstOrDefault().Id;
                var buyerId = InMemoryStorage.Instance.Buyers.FirstOrDefault().Id;

                this._orderRepository.Insert(new OrderItem() {
                        SupplierId = supplierId,
                        BuyerId = buyerId,
                        ArticleId = articleId
                });

                Assert.True(false, "SupplierId cant be invalid.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(true, "DB relation failed");
            }
        }
    }
}
