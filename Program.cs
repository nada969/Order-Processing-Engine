using System.Diagnostics;
namespace OrderProcessingEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create products
            Product product1 = new Product(1, "scruf", 100, 50);
            Product product2 = new Product(2, "jacket", 150, 5);
            Product product3 = new Product(3, "cap", 10, 40);
            Product product4 = new Product(4, "pants", 190, 88);
            // Create customer
            Customer customer1 = new Customer(1, "Nada", "nada@gmail.com");
            // Create order
            OrderItem item1 = new OrderItem(product1, 4);
            Order<OrderItem> order1 = new Order<OrderItem>(1, customer1, true);
            Console.WriteLine(item1.Product.Stock);
            order1.PrintItems();
            Console.WriteLine("----------------");
            // Add items
            OrderItem item2 = new OrderItem(product2, 5);
            OrderItem item3 = new OrderItem(product3, 5);
            OrderItem item4 = new OrderItem(product4, 5);
            OrderItem[] items = [item2, item3];
            order1.AddItem(item2);
            order1.PrintItems();
            // Process order
            // Raise events
            // Log results

        }
    }
}


/// To do:
///     - generic in Order & order item
///     - delegate
///     - Events Ordersssssss