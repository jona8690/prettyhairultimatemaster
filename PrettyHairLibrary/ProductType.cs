using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    public class ProductType
    {
        private double price;
        private int amount;
        public ProductType(int i, string d, double p, int a)
        {
            ID = i;
            Description = d;
            Price = p;
            Amount = a;
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public double Price { get { return price; } set { if (value < 0) { throw new Exception("Please input a price that is greater than or equal to 0."); } else { price = value; } } }
        public int Amount { get { return amount; } set { if (value < 0) { throw new Exception("Please input an amount that is greater than or equal to 0."); } else { amount = value; } } }
        public override string ToString()
        {
            string output = "*---- Product ID: " + ID + "----*" +
                            "\n Product description: " + Description +
                            "\n Product price: " + Price +
                            "\n Product amount: " + Amount;
            return output;
        }
    }
}
