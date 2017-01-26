using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyHairLibrary;

namespace GraphicalUI {
	class ProductManagerController {
		ProductTypeRepository RepoPT = ProductTypeRepository.Instance;
		IKeyGenerator KeyGen = KeyGeneratorFactory.Get(KeyGenerators.Date);

		public List<string> GetProducts(string search = "") {
			List<string> Result = new List<string>();
			List<ProductType> Products = RepoPT.GetAllProducts();

			foreach (ProductType Product in Products) {
				if (search == "" || Product.Description.Contains(search)) {
					StringBuilder SB = new StringBuilder();
					SB.Append(Product.ID);
					SB.Append(" - ");
					SB.Append(Product.Description);

					Result.Add(SB.ToString());
				}
			}

			return Result;
		}

		public void SubscribeToProductList(IObserver obj) {
			RepoPT.Subscribe(obj);
		}

		public void SaveProduct(string desc, string amount, string price) {
			int ID = KeyGen.NextKey;
			double Price = Double.Parse(price);
			int Amount = int.Parse(amount);

			ProductType PT = new ProductType(ID, desc, Price, Amount);
			RepoPT.Add(PT);
		}

		public void Init() {
			RepoPT.Add(new ProductType(1, "Gel", 30.0, 20));
			RepoPT.Add(new ProductType(2, "Extra large gel", 50.0, 10));
		}
	}
}
