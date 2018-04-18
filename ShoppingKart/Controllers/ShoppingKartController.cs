using ShoppingKart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShoppingKart.Controllers
{
	public class ShoppingKartController : Controller
	{
		// GET: ShoppingKart
		public ActionResult Index()
		{
			PricingModel model = new PricingModel();
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult AddProduct(PricingModel model)
		{
			List<Product> result = new List<Product>();

			if (model != null)
			{
				if(model.Product.ProductName == "A" || model.Product.ProductName == "B" || model.Product.ProductName == "C")
				{
					result.Add(new Product(model.Product.ProductName, model.Product.ProductQuantity));
					if (model.ListOfProducts != null)
						result.AddRange(model.ListOfProducts);
					model.ListOfProducts = result;
				}				
			}
			else
			{
				throw new Exception("Model is null");
			}

			ModelState.Clear();
			return PartialView("ListOfProducts", model);

		}
		[HttpPost]
		public ActionResult ResetProducts(PricingModel model)
		{
			if(model != null)
			{
				model.ListOfProducts = new List<Product>();
				model.Total = 0;
				model.Product.ProductName = null;
				model.Product.ProductQuantity = 0;
			}
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult TotalProduct(PricingModel model)
		{
			double result = 0;
			if (model != null)
			{
				if (model.ListOfProducts != null && model.ListOfProducts.Count > 0)
				{
					foreach (Product product in model.ListOfProducts)
					{
						try
						{
							result = result + CalculateTotal(product.ProductName, product.ProductQuantity);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					model.Total = (int)Math.Round(result);
				}
				else
					throw new Exception("List of products is null");
			}
			else
				throw new Exception("Model is null");
			return PartialView("ListOfProducts", model);
		}

		public double CalculateTotal(string productname, int quantity)
		{
			double total = 0;
			switch (productname)
			{
				case "A":
					if (quantity > PricingModel.PLU.Offer)
					{
						total = (quantity / PricingModel.PLU.Offer) * PricingModel.PLU.AOffer * PricingModel.PLU.A + (quantity % PricingModel.PLU.Offer) * PricingModel.PLU.A;
					}
					else if (quantity == PricingModel.PLU.Offer)
					{
						total = PricingModel.PLU.AOffer * PricingModel.PLU.A;
					}
					else
					{
						total = quantity * PricingModel.PLU.A;
					}

					break;
				case "B":
					if (quantity > PricingModel.PLU.Offer)
					{
						total = (quantity / PricingModel.PLU.Offer) * PricingModel.PLU.PriceForThree + (quantity % PricingModel.PLU.Offer) * PricingModel.PLU.B;
					}
					else if (quantity == PricingModel.PLU.Offer)
					{
						total = PricingModel.PLU.PriceForThree;
					}
					else
					{
						total = quantity * PricingModel.PLU.B;
					}

					break;
				case "C":
					total = quantity * PricingModel.PLU.C;

					break;
				default: break;
			}
			return total;
		}
	}
}