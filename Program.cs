using Object_OrientedOOP.HotelReservationSystem;
using Object_OrientedOOP.Part1_ProceduralToOOP.src;

namespace Object_OrientedOOP
{
    public class Program
    {
        public static void Main()
        {
            //            OrderSystem system = new OrderSystem();

            //            SeedSampleData(system);

            //            RunDemoScenario(system);

            //            RunInteractiveMenu(system);
            //            HotelManager hotel = new HotelManager();

            // Create Guest

        }


        public static void SeedSampleData(OrderSystem system)
        {
            Customer customer1 =
                new Customer(
                    1,
                    "Ahmad",
                    "ahmad@email.com",
                    "Nablus",
                    true);

            Customer customer2 =
                new Customer(
                    2,
                    "Omar",
                    "omar@email.com",
                    "Ramallah",
                    false);

            system.AddCustomer(customer1);
            system.AddCustomer(customer2);

            Product product1 =
                new Product(
                    1,
                    "Laptop",
                    800m,
                    10);

            Product product2 =
                new Product(
                    2,
                    "Mouse",
                    25m,
                    20);

            Product product3 =
                new Product(
                    3,
                    "Keyboard",
                    50m,
                    15);

            system.AddProduct(product1);
            system.AddProduct(product2);
            system.AddProduct(product3);
        }

        public static void RunDemoScenario(OrderSystem system)
        {
            system.CreateOrder(
                1,
                1,
                new DateTime(2026, 9, 25));

            system.AddLineToOrder(1, 1, 1);
            system.AddLineToOrder(1, 2, 2);

            system.MarkOrderAsPaid(1);

            Console.WriteLine("Demo Order:");
            system.FindOrder(1).PrintOrder();

            Console.WriteLine();
            Console.WriteLine(
                $"Total Sales: {system.TotalSalesPaidOnly()}");
            Console.WriteLine();
        }

        public static void RunInteractiveMenu(OrderSystem system)
        {
            bool running = true;

            while (running)
            {
                PrintMenu();

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddCustomerFromConsole(system);
                            break;

                        case "2":
                            system.PrintCustomers();
                            break;

                        case "3":
                            AddProductFromConsole(system);
                            break;

                        case "4":
                            system.PrintProducts();
                            break;

                        case "5":
                            CreateOrderFromConsole(system);
                            break;

                        case "6":
                            AddLineFromConsole(system);
                            break;

                        case "7":
                            PayOrderFromConsole(system);
                            break;

                        case "8":
                            system.PrintAllOrders();
                            break;

                        case "9":
                            Console.WriteLine(
                                $"Total Sales: {system.TotalSalesPaidOnly()}");
                            break;

                        case "0":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Print Customers");
            Console.WriteLine("3. Add Product");
            Console.WriteLine("4. Print Products");
            Console.WriteLine("5. Create Order");
            Console.WriteLine("6. Add Line To Order");
            Console.WriteLine("7. Pay Order");
            Console.WriteLine("8. Print All Orders");
            Console.WriteLine("9. Total Sales");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
        }

        public static void AddCustomerFromConsole(OrderSystem system)
        {
            Console.Write("Customer Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("VIP? true/false: ");
            bool isVip = bool.Parse(Console.ReadLine());

            Customer customer =
                new Customer(
                    id,
                    name,
                    email,
                    city,
                    isVip);

            system.AddCustomer(customer);

            Console.WriteLine("Customer added.");
        }

        public static void AddProductFromConsole(OrderSystem system)
        {
            Console.Write("Product Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            Product product =
                new Product(
                    id,
                    name,
                    price,
                    stock);

            system.AddProduct(product);

            Console.WriteLine("Product added.");
        }

        public static void CreateOrderFromConsole(OrderSystem system)
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            Console.Write("Customer Id: ");
            int customerId = int.Parse(Console.ReadLine());

            system.CreateOrder(
                orderId,
                customerId,
                DateTime.Now);

            Console.WriteLine("Order created.");
        }

        public static void AddLineFromConsole(OrderSystem system)
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            Console.Write("Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            system.AddLineToOrder(
                orderId,
                productId,
                quantity);

            Console.WriteLine("Order line added.");
        }

        public static void PayOrderFromConsole(OrderSystem system)
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            system.MarkOrderAsPaid(orderId);

            Console.WriteLine("Order paid.");
        }
    }
}