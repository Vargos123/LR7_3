namespace LR7_N3
{	class Article
	{
		public string StoreName
		{
			get;
		}
		public string ItemName
		{
			get;
		}
		public int Price
		{
			get;
		}

		public Article(string item, string store, int price)
		{
			ItemName = item.Trim();
			StoreName = store.Trim();
			Price = price;
		}
	}
}
