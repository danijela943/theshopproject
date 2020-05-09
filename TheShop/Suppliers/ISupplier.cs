﻿using TheShop.Models;

namespace TheShop.Suppliers
{
	public interface ISupplier
	{
		bool ArticleInInventory(int id);
		Article GetArticle(int id);
	}
}