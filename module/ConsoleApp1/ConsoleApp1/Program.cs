using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
}

public class Delivery
{
    public int ProductId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public int Quantity { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Apple", Price = 20 },
            new Product { ProductId = 2, ProductName = "Banana", Price = 50 },
            new Product { ProductId = 3, ProductName = "Cherry", Price = 40 },
            new Product { ProductId = 4, ProductName = "Blowberry", Price = 30 },
            new Product { ProductId = 5, ProductName = "Elderberry", Price = 35 },
            new Product { ProductId = 1, ProductName = "Apple", Price = 20}
        };

        List<Delivery> deliveries = new List<Delivery>
        {
            new Delivery { ProductId = 1, DeliveryDate = DateTime.Now, Quantity = 100 },
            new Delivery { ProductId = 2, DeliveryDate = DateTime.Now.AddDays(-2), Quantity = 150 },
            new Delivery { ProductId = 3, DeliveryDate = DateTime.Now.AddDays(-4), Quantity = 200 },
            new Delivery { ProductId = 4, DeliveryDate = DateTime.Now.AddDays(-1), Quantity = 180 },
            new Delivery { ProductId = 5, DeliveryDate = DateTime.Now.AddDays(-3), Quantity = 75 },
            new Delivery { ProductId = 1, DeliveryDate = DateTime.Now.AddDays(-2), Quantity= 200 }
        };

        // a) Вивести без повторів назви товарів
        static void CWNameOfProducts(List<Product> products)
        {
            var uniqueProductNames = products.Select(p => p.ProductName).Distinct();
            Console.WriteLine("Unique product names:");
            foreach (var name in uniqueProductNames)
                Console.WriteLine(name);
        }

        // b) Вивести максимальний обсяг поставок товару із заданою назвою
        static void CWMaxDelivery(string targetProductName, List<Delivery> deliveries, List<Product> products)
        {
            var maxDeliveryForProduct = deliveries
                .Where(d => products.Any(p => p.ProductId == d.ProductId && p.ProductName == targetProductName))
                .Max(d => d.Quantity);
            Console.WriteLine($"Max delivery for {targetProductName}: {maxDeliveryForProduct}");
        }

        // c) Зберегти дані однієї з колекцій в xml-файлі
        static void SaveToXML(List<Product> products)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream("products.xml", FileMode.Create))
            {
                serializer.Serialize(fs, products);
            }
            Console.WriteLine("Products saved to products.xml");
        }

        // Виклик методів
        CWNameOfProducts(products);
        CWMaxDelivery("Apple", deliveries, products);
        SaveToXML(products);
    }
}