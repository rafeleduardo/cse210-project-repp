using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        var laptop = new Product("Laptop", "TECH001", 999.99m, 1);
        var mouse = new Product("Mouse", "TECH002", 29.99m, 2);
        var keyboard = new Product("Keyboard", "TECH003", 59.99m, 1);
        var headphones = new Product("Headphones", "TECH004", 149.99m, 1);
        var monitor = new Product("Monitor", "TECH005", 299.99m, 2);
        
        var usaAddress = new Address("123 Main St", "New York", "NY", "USA");
        var usaCustomer = new Customer("John Smith", usaAddress);

        var internationalAddress = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        var internationalCustomer = new Customer("Jane Doe", internationalAddress);
        
        var order1 = new Order(usaCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);
        order1.AddProduct(keyboard);
        
        var order2 = new Order(internationalCustomer);
        order2.AddProduct(headphones);
        order2.AddProduct(monitor);
        
        Console.WriteLine("=== Order 1 (USA Client) ===");
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\nPackage Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():F2}");

        Console.WriteLine("\n=== Orden 2 (International Client) ===");
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\nPackage Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():F2}");
    }
}