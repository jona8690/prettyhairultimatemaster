using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{

    public class ProductTypeRepository : IObservable
    {
        Dictionary<int, ProductType> _productTypes = new Dictionary<int, ProductType>();

		private List<IObserver> Observers = new List<IObserver>();
	
		// Singleton
		private static ProductTypeRepository instance;
		public static ProductTypeRepository Instance {
			get {
				if (instance == null) {
					instance = new ProductTypeRepository();
				}

				return instance;
			}
		}

		private ProductTypeRepository() {

		}

        public void Delete(int key)
        {
            _productTypes.Remove(key);
           
        }

        public void Add(ProductType product)
        {
            _productTypes.Add(product.ID, product);
			foreach (IObserver Obs in Observers) {
				Obs.Change();
			}
		}

        public ProductType GetProduct(int key)
        {
            ProductType p = null;
            if (_productTypes.ContainsKey(key))
            {
                Console.WriteLine("true");
                p = _productTypes[key];
            }
            Console.WriteLine(key);
            return p;
        }

        public void AdjustPrice(int key, double newPrice)
        {
            _productTypes[key].Price = newPrice;
        }

        public void AdjustAmount(int key, int newAmount)
        {
            _productTypes[key].Amount = newAmount;
        }

        public void AdjustDescription(int key, string newDescription)
        {
            _productTypes[key].Description = newDescription;
        }


        public string ViewAllProducts()
        {
            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<int,ProductType> p in _productTypes){
                sb.Append(p.Value);
                sb.Append("\n");
            }
            
            return sb.ToString();
        }

		public List<ProductType> GetAllProducts() {
			return _productTypes.Values.ToList();
		}

        public void UpdateProduct(int id, string description, double price, int amount)
        {
            ProductType p = this.GetProduct(id);
            p.Description = description;
            p.Price = price;
            p.Amount = amount;
        }

		public void Subscribe(IObserver subscriber) {
			Observers.Add(subscriber);
		}
	}
}
