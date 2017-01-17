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
        private bool isRunning;
        private ProductTypeRepository pr = new ProductTypeRepository();
        private OrderRepository or = new OrderRepository();
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
            m = new Menu(pr);
            isRunning = true;

			KeyGeneratorFactory KGF = new KeyGeneratorFactory();
			IKeyGenerator KeyGenerator = KGF.Get(KeyGenerators.Date);

            while (isRunning)
            {
                m.HeadLine("Pretty Hair");
                m.PrintMenu();
                MenuSelectOption();
            }
        }

        public static void ViewProductTypes()
        {
            Console.Clear();
            Console.WriteLine("Show all products");
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
                    Console.Clear();
                    m.ViewProductTypes();
                    break;
                case 2:
                    Console.Clear();
                    UpdateProductTypes();
                    break;
                default:
                    Console.WriteLine("Wrong input try again.");
                    break;
            }
        }

        private ProductType SelectProduct()
        {
            bool loopRunning = true;
            ProductType p = null;
            while (loopRunning) { 
                Console.WriteLine(pr.ViewAllProducts());
                int option;
                Console.WriteLine("Select a product by typing in the ID or enter 0 to go back: ");
                int.TryParse(Console.ReadLine(), out option);
                p = pr.GetProduct(option);
                if (p == null)
                {
                    Console.WriteLine("Either incorrect input or the ID was not found");
                }
                else {
                    loopRunning = false;
                }
                if (option == 0) loopRunning = false;
            }
            return p;
        }
        

        private void UpdateProductTypes()
        {
            ProductType p;

            p = SelectProduct();

            if (p != null)
            {
                SelectUpdateProductTypeOption(p.ID);
            }
        }

        private void SelectUpdateProductTypeOption(int id)
        {   
            string option;
            bool loopRunning = true;
            Console.Clear();
            while (loopRunning) {
                m.PrintUpdateOptions();
                option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    loopRunning = false;    
                    break;
                case "1":
                        Console.Clear();
                        UpdateProductTypeDescription(id);
                break;
                case "2":
                        Console.Clear();
                        UpdateProductTypePrice(id);
                break;
                case "3":
                        Console.Clear();
                        UpdateProductTypeAmount(id);
                break;
                    default:
                    Console.Clear();
                    Console.WriteLine("Wrong input.");
                    break;
             }
                Console.Clear();
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


        private void UpdateProductTypePrice(int id)
        {
            double price = -1;
            m.PrintUpdatePriceText();
            while (price < 0)
            {
                price = ConsoleReadLineTryParseDouble();
                if (price < 0) Console.WriteLine("Price cannot be below on");
            }
            pr.AdjustPrice(id, price);
        }

        private void UpdateProductTypeDescription(int id)
        {
            string description = "";
            Console.WriteLine("Enter the description(can't be empty):");
            while (description == "")
            {
                description = Console.ReadLine();
                if (description == "") Console.WriteLine("Error: Description can't be empty");
            }
            pr.AdjustDescription(id, description);
        }

        private void UpdateProductTypeAmount(int id)
        {
            int amount = -1;
            m.PrintUpdateAmountText();
            while (amount < 0)
            {
                amount = ConsoleReadLineTryParseInteger();
            }
            pr.AdjustAmount(id, amount);
        }
    }
}

