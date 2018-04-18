using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingKart.Models
{
	public class PricingModel
	{
		public struct PLU
		{
			public const double A = 59.90;
			public const int B = 399;
			public const double C = 19.54;
			public const int PriceForThree = 999;
			public const int Offer = 3;
			public const int AOffer = 2;
		}
		public Product Product { get; set; }
		public int Total { get; set; }
		public List<Product> ListOfProducts { get; set; }

		public PricingModel()
		{
			Product = new Product();
		}
	}
	public class Product
	{
		public string ProductName { get; set; }
		public int ProductQuantity { get; set; }

		public Product()
		{

		}
		public Product(string productname, int quantity)
		{
			ProductName = productname;
			ProductQuantity = quantity;
		}
	}


}