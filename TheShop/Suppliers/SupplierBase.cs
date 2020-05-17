using TheShop.Models;

namespace TheShop.Suppliers
{
	public class SupplierBase : ISupplier
	{
        public int Id { get; private set; }
        public string NameOfArticle { get; private set; }
        public int ArticlePrice { get; private set; }

        public SupplierBase(int id)
        {

        }

		public bool ArticleInInventory(int id)
		{
			return true;
		}
		
		public Article GetArticle(int id)
		{
			return new Article()
			{
				//ID = Id,
				//NameOfArticle = NameOfArticle,
				//ArticlePrice = ArticlePrice
			};
		}
	}
}