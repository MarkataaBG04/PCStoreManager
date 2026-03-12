using System.Text;

namespace PCStoreManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Component> components = new Dictionary<string, Component>();

            MainMenu();

            string input;

            while ((input = Console.ReadLine()) != "0")
            {
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        AddNewComponent(components);
                        break;
                    case "2":
                        Console.Clear();
                        SellComponent(components);
                        break;
                    case "3":
                        Console.Clear();
                        CheckAvailability(components);
                        break;
                    case "4":
                        Console.Clear();
                        MostExpensiveProduct(components);
                        break;
                    case "5":
                        Console.Clear();
                        CategorySearch(components);
                        break;
                    default:
                        Console.WriteLine($"Invalid option!");
                        break;
                }

                MainMenu();
            }
            Console.Clear();
            Console.WriteLine("Thank you for using PC Store Manager. See you next time!");
        }

        private static void CategorySearch(Dictionary<string, Component> components)
        {
            Console.WriteLine("You chose to search by category.");
            Console.WriteLine("Enter the category you want to search for:");
            string inputCategory = Console.ReadLine();

            // Филтрираме case-insensitive и подреждаме по цена
            var results = components
                .Where(c => c.Value.Category.Equals(inputCategory, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Value.Price)
                .OrderBy(c => c.Value.Quantity)
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine($"No components found in category {inputCategory}.");
            }
            else
            {
                Console.WriteLine($"Components in category {inputCategory}:");
                foreach (var comp in results)
                {
                    Console.WriteLine($"Name: {comp.Key}, Price: ${comp.Value.Price}, Quantity: {comp.Value.Quantity}");
                }
            }
        }

        private static void MostExpensiveProduct(Dictionary<string, Component> components)
        {
            if (components.Count == 0)
            {
                Console.WriteLine("There are no components in the store yet.");
            }
            else
            {
                Console.WriteLine("You chose to show the most expensive product.");

                var mostExpensive = components.OrderByDescending(p => p.Value.Price).First();

                Console.WriteLine($"The most expensive component is {mostExpensive.Value.Name}.");
                Console.WriteLine($"Category: {mostExpensive.Value.Category}, Price: ${mostExpensive.Value.Price:F2}, Quantity: {mostExpensive.Value.Quantity}");
            }
        }

        private static void CheckAvailability(Dictionary<string, Component> components)
        {
            Console.WriteLine("You chose to check availability.");
            Console.WriteLine("Enter the name of the component to check stock:");
            string componentName = Console.ReadLine();

            if (components.ContainsKey(componentName))
            {
                if (components[componentName].Quantity >= 1)
                {
                    Console.WriteLine($"Component {componentName} is in stock: {components[componentName].Quantity} units. Price: ${components[componentName].Price:f2}");
                }
                else
                {
                    Console.WriteLine($"Component {componentName} is out of stock.");
                }
            }
            else
            {
                Console.WriteLine($"Component {componentName} does not exist in the store.");
            }
        }

        private static void SellComponent(Dictionary<string, Component> components)
        {
            Console.WriteLine("You chose to sell a component.");
            Console.WriteLine("Enter the name of the component you want to sell:");
            string componentName = Console.ReadLine();

            if (components.ContainsKey(componentName))
            {
                if (components[componentName].Quantity >= 1)
                {
                    components[componentName].Quantity -= 1;
                    Console.WriteLine($"Component {componentName} sold successfully! Remaining quantity: {components[componentName].Quantity}.");
                }
                else
                {
                    Console.WriteLine($"Component {componentName} is out of stock.");
                }
            }
            else
            {
                Console.WriteLine($"Component {componentName} does not exist in the store.");
            }
        }

        private static void AddNewComponent(Dictionary<string, Component> components)
        {
            Console.WriteLine("You chose to add a new component.");
            Console.WriteLine("Please enter the details below:");

            Console.WriteLine("Enter component name:");
            string componentName = Console.ReadLine();
            if (!components.ContainsKey(componentName))
            {
                Console.WriteLine("Enter component category (CPU, GPU, RAM, SSD, etc.):");
                string category = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter component price:");
                decimal price;
                if (!decimal.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    return;
                }

                Console.WriteLine("Enter quantity in stock:");

                int quantity;
                if (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    return;
                }

                Component component = new Component(componentName, category, price, quantity);

                components.Add(componentName, component);
                Console.WriteLine($"Component {componentName} has been added successfully!");
            }
            else
            {
                Console.WriteLine($"Component {componentName} already exists.");
                Console.WriteLine("Enter quantity in stock:");
                int quanity = int.Parse(Console.ReadLine());
                components[componentName].Quantity += quanity;
                Console.WriteLine($"Quantity updated to {components[componentName].Quantity}.");
            }

        }

        private static void MainMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("===============================");
            Console.WriteLine("       🖥️ PC Store Manager");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Add a new component");
            Console.WriteLine("2. Sell a component");
            Console.WriteLine("3. Check availability");
            Console.WriteLine("4. Show the most expensive product");
            Console.WriteLine("5. Search by category");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
        }
    }

    class Component 
    {
        public Component(string name, string category, decimal price, int quanity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quanity;
        }


        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
