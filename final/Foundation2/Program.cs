using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("PC case", "F103B5", 150, 1);
        Product product2 = new Product("Computer fans", "A27C5D", 30, 3);
        Product product3 = new Product("Motherboard", "G754K2", 120, 1);
        Product product4 = new Product("Display Port Monitor", "D6G9E2", 120, 2);
        Product product5 = new Product("4K GPU", "FG92Q1", 1400, 1);

        Address address1 = new Address("15248 White Oak Ave", "Hurricane", "Utah", "USA");
        Address address2 = new Address("15 Juniper Rd", "Smithbridge", "AB", "Canada");

        Customer customer1 = new Customer("Harold Cook", address1);
        Customer customer2 = new Customer("Jaque Flemmel", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.TotalPrice()}\n");

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.TotalPrice()}\n");
    }
}