using System.Data;
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

            OrderItem item1 = new OrderItem(product1, 4);
            OrderItem item2 = new OrderItem(product2, 5);
            OrderItem item3 = new OrderItem(product3, 5);
            OrderItem item4 = new OrderItem(product4, 5);
            
            //Console.WriteLine(item1.ItemTotalPrice);

            // Create customer
            Customer customer1 = new Customer(1, "Nada", "nada@gmail.com");

            // Create order
            Order order1 = new Order(1, customer1);
            Console.WriteLine("N.Items is Order1: "+order1.ItemsNum + "/ with the customer: " + customer1.Name);
            Console.WriteLine(order1.OrderIsEmpty);
            Console.WriteLine("----------------");
            // Add items
            Console.WriteLine("Add items");
            OrderItem[] items = [item2, item3];
            order1.AddItem(item1);
            order1.AddItem(item2);
            order1.AddItem(item3);
            order1.AddItem(item4);
            Console.WriteLine("N.Items is Order1: " + order1.ItemsNum+ "/ with the customer: "+ customer1.Name);
            Console.WriteLine(order1.OrderIsEmpty);
            Console.WriteLine("----------------");

            // Process order
            Console.WriteLine("Process order");
            order1.CompleteOrder();
            Console.WriteLine("the order1 status is: " + order1.Status);
            Console.WriteLine("----------------");

            // Raise events --> update stock & payment process
            Console.WriteLine(" Raise events");
            OrderProcess process = new OrderProcess();
            Stock stock = new Stock();
            Payment pay = new Payment();

            //////////////////////////// subscribe to event first
            ///OrderCreated
            ///////→ Stock.OnOrderCreated
            ///////→ Payment.OnOrderCreated
            stock.Subscribe(process);
            pay.Subscribe(process); 
            //////////////////////////// EVENT FIRED second
            process.OnOrderCreated(order1);
           

            Console.WriteLine(product1.Stock);
            Console.WriteLine(product2.Stock);


           

            // Log results

            Console.ReadKey();

        }

    }
}


/// To do:
///     - generic in Order & order item
///     - delegate
///     - Events Ordersssssss