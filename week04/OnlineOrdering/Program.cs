using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nHello again! Here you have my Online Ordering Project.");
        Console.WriteLine("");

        Console.WriteLine("Online Ordering System - W04 Assignment");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine();

        // Order 1: National Client 
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "WM-100", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "KB-200", 75.00, 1));
        order1.AddProduct(new Product("Mouse Pad", "MP-50", 12.99, 3));

        // Order 2: International Client
        Address address2 = new Address("456 Gran Via", "Madrid", "Madrid", "Spain");
        Customer customer2 = new Customer("Maria Gonzalez", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Gaming Monitor", "GM-300", 299.99, 1));
        order2.AddProduct(new Product("USB-C Hub", "UC-400", 45.00, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"--- ORDER #{orderNumber} ---");
            Console.WriteLine();
            
            Console.WriteLine("PACKING LABEL:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("SHIPPING LABEL:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"TOTAL PRICE: ${order.GetTotalCost():0.00}");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();

            orderNumber++;
        }
    }
}