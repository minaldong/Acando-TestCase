using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingKart;
using ShoppingKart.Controllers;

namespace ShoppingKart.Tests.Controllers
{
	[TestClass]
	public class ShoppingKartControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			ShoppingKartController controller = new ShoppingKartController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		

		[TestMethod]
		public void CalculateTotal()
		{
			// Arrange
			ShoppingKartController controller = new ShoppingKartController();

			//For A
			string productname = "A";
			int quantity = 10;
			double total = 0;
			int result = 0, expect = 419;

			//Act
			total = controller.CalculateTotal(productname, quantity);
			result = (int)Math.Round(total);

			// Assert
			Assert.AreEqual(expect,result);

			//for B
			 productname = "B";
			 quantity = 10;
			 total = 0;
			result = 0;
			expect = 3396;

			//Act
			total = controller.CalculateTotal(productname, quantity);
			result = (int)Math.Round(total);

			// Assert
			Assert.AreEqual(expect, result);

			//for C
			productname = "C";
			quantity = 1;
			total = 0;
			result = 0;
			expect = 20;

			//Act
			total = controller.CalculateTotal(productname, quantity);
			result = (int)Math.Round(total);

			// Assert
			Assert.AreEqual(expect, result);


			//Total of products
			total = 0;
			result = 0;
			expect = 3835;
			Dictionary<string, int> List = new Dictionary<string, int>();
			List.Add("A", 10);
			List.Add("B", 10);
			List.Add("C", 1);

			foreach(var item in List)
			{
				total = total + controller.CalculateTotal(item.Key, item.Value);
			}
			result = (int)Math.Round(total);
			// Assert
			Assert.AreEqual(expect, result);
		}
	}
}
