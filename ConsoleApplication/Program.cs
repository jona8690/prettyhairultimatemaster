using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHairLibrary;

namespace CLI
{
    class Program
    {
        private bool isRunning;
        private ProductRepository pr = new ProductRepository();

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
            isRunning = true;

            while (isRunning)
            {
                Menu();
            }
        }

        private void PrintMenuTitle() {
            // Fancy title
            Console.WriteLine("Pretty Hair");
        }

        private void Menu()
        {
            
            Console.WriteLine("1. View all product types");
            Console.WriteLine("2. Update product.");
            Console.WriteLine("3. Close");
            MenuSelectOption();
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
                    ViewProductTypes();
                    break;
                case 2:
                    UpdateProduct();
                    break;
                default:
                    Console.WriteLine("Wrong input try again.");
                    break;
            }
        }

        private ProductType SelectProduct() {
            ProductType p; 
            Console.WriteLine(pr.ViewAllProducts());
            int option;
            Console.WriteLine("Select a product by typing in the ID: ");
            int.TryParse(Console.ReadLine(),out option);
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
            ProductType p = SelectProduct();
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
            else {
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
            else {
                Console.WriteLine("Amount can't be below 0, old amount is used instead!");
            }
            Console.WriteLine();
            pr.UpdateProduct(id, description,price, amount);
            Console.Clear();
        }

        private void ViewProductTypes()
        {
            Console.Clear();
            Console.WriteLine(HeadLine("Show all products"));
            Console.WriteLine(pr.ViewAllProducts());
        }

        private string HeadLine(string sr) {
            return "*------------------" + sr +"------------------*";
        }
    }
}

