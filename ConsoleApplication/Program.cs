using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHairLibrary;
using ConsoleApplication;

namespace CLI
{
    delegate void MenuDelegate();
    class Program
    {
        private MenuDelegate menu;
        private bool isRunning;
        private ProductTypeRepository pr = new ProductTypeRepository();
        private Menu m; 

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Init();
            p.Run();

        }

        private void Init()
        {
            pr.Add(new ProductType(1, "Gel", 30.0, 20));
            pr.Add(new ProductType(2, "Extra large gel", 50.0, 10));
        }

        private void Run()
        {
            MenuDelegate UpdateOptions = new MenuDelegate(PrintUpdateOptions);
            UpdateOptions.ToString();
            m = new Menu(pr);
            isRunning = true;

            while (isRunning)
            {
                m.HeadLine("Pretty Hair");
                ;
                MenuSelectOption();
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. View all product types");
            Console.WriteLine("2. Update product.");
            Console.WriteLine("3. Close");
        }

        public static void ViewProductTypes()
        {
            Console.Clear();
            Console.WriteLine("Show all products");
        }

        public static void PrintUpdateOptions()
        {
            Console.WriteLine("Update Option for:");
            Console.WriteLine("1. Change description");
            Console.WriteLine("2. Change price");
            Console.WriteLine("3. Change amount");
        }

        public void PrintUpdateAmountText()
        {
            HeadLine("Update amount by inputting a new value");
            Console.WriteLine("(*Note the value it cannot be below 0");
        }

        public void HeadLine(string sr)
        {
            Console.WriteLine("*------------------" + sr + "------------------*");
        }
        private void MenuSelectOption()
        {

            int option;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 3:
                    isRunning = false;
                    break;
                case 1:
                    m.ViewProductTypes();
                    break;
                case 2:
                    UpdateProductTypes();
                    break;
                default:
                    Console.WriteLine("Wrong input try again.");
                    break;
            }
        }

        private ProductType SelectProduct()
        {
            ProductType p;
            Console.WriteLine(pr.ViewAllProducts());
            int option;
            Console.WriteLine("Select a product by typing in the ID: ");
            int.TryParse(Console.ReadLine(), out option);
            p = pr.GetProduct(option);
            if (option == 0 || p != null)
            {
                Console.WriteLine("Either incorrect input or the ID was not found");
                p = SelectProduct();
            }
            return p;
        }
        
        private void UpdateProduct()
        {
            bool canFindProduct = false;
            while (!canFindProduct) { 
                ProductType p = SelectProduct();
            }
            int id = p.ID;
            string description = p.Description;
            double price = p.Price;
            int amount = p.Amount;

            Console.WriteLine("Set new description. Current description =\n " + description);
            string newdescription = Console.ReadLine();
            if (newdescription != "")
            {
                description = newdescription;
            }
            else
            {
                Console.WriteLine("Description can't be empty");
            }
            Console.WriteLine("Set new price. Current price =\n " + price);
            double newprice = double.Parse(Console.ReadLine());
            if (newprice >= 0.0)
            {
                price = newprice;
            }
            else
            {
                Console.WriteLine("Price can't be below 0, old price is used instead!");
            }
            Console.WriteLine("Set the amount of the products in stock. Current stock =\n " + amount);
            int newamount = int.Parse(Console.ReadLine());
            if (newamount >= 0)
            {
                amount = newamount;
            }
            else
            {
                Console.WriteLine("Amount can't be below 0, old amount is used instead!");
            }
            Console.WriteLine();
            pr.UpdateProduct(id, description, price, amount);
            Console.Clear();
        }

        private void UpdateProductTypes()
        {
            ProductType p = null;
            while (p == null)
            {
                 p = SelectProduct();
            }
            m.PrintUpdateOptions();
            SelectUpdateProductTypeOption();
        }

        private void SelectUpdateProductTypeOption()
        {
            int option = 0;
            bool correctSelection = false;
            while (!correctSelection) {
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Wrong input.");
                }
                else {
                    correctSelection = true;
                }
            }
            switch (option) {
                case 1:
                    UpdateProductTypeDescription();
                    break;
                case 2:
                    UpdateProductTypePrice();
                    break;
                case 3:
                    UpdateProductTypeAmount();
                    break;
            }
        }

        private void UpdateProductTypeAmount()
        {
            int amount = -1;
            m.PrintUpdateAmountText();
            while (amount < 0) { 
                amount = ConsoleReadLineTryParseInteger();
            }
        }

        private int ConsoleReadLineTryParseInteger()
        {
            int input;
            while(!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Wrong input.");
            }
            return input;
        }

        private double ConsoleReadLineTryParseDouble()
        {
            double input;
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Wrong input.");
            }
            return input;
        }


        private void UpdateProductTypePrice()
        {
            double price = -1;
            m.PrintUpdateAmountText();
            while (price < 0)
            {
                price = ConsoleReadLineTryParseDouble();
                if (price < 0) Console.WriteLine("Price cannot be below on");
            }
        }

        private void UpdateProductTypeDescription()
        {
            string description = "";
            m.PrintUpdateProductTypeText();
            while (price != "")
            {
                price = ConsoleReadLineTryParseDouble();
                if (price != 0) Console.WriteLine("Description can't be empty");
            }
        }

        private void UpdateProductOptions()
        {
            
            
        }
    }
}

