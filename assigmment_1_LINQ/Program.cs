using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
}

public class Customer
{
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai", UnitsInStock = 39, UnitPrice = 18.00M },
            new Product { ProductID = 2, ProductName = "Chang", UnitsInStock = 17, UnitPrice = 19.00M },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", UnitsInStock = 0, UnitPrice = 10.00M },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", UnitsInStock = 53, UnitPrice = 22.00M },
            new Product { ProductID = 5, ProductName = "Mishi Kobe Niku", UnitsInStock = 0, UnitPrice = 97.00M },
            new Product { ProductID = 6, ProductName = "Ikura", UnitsInStock = 31, UnitPrice = 31.00M },
            new Product { ProductID = 7, ProductName = "Queso Cabrales", UnitsInStock = 0, UnitPrice = 21.05M },
            new Product { ProductID = 8, ProductName = "Queso Manchego La Pastora", UnitsInStock = 4, UnitPrice = 38.00M },
            new Product { ProductID = 9, ProductName = "Guaraná Fantástica", UnitsInStock = 20, UnitPrice = 4.50M },
            new Product { ProductID = 10, ProductName = "Nori", UnitsInStock = 0, UnitPrice = 197.00M }
        };

        Console.WriteLine("--- LINQ - Restriction Operators ---");
        Console.WriteLine();

        var outOfStockProducts = products.Where(p => p.UnitsInStock == 0);
        Console.WriteLine("1. Out of stock products:");
        foreach (var p in outOfStockProducts)
        {
            Console.WriteLine($"- {p.ProductName}");
        }
        Console.WriteLine();

        var expensiveInStockProducts = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
        Console.WriteLine("2. In stock products over $3.00:");
        foreach (var p in expensiveInStockProducts)
        {
            Console.WriteLine($"- {p.ProductName} (Price: {p.UnitPrice})");
        }
        Console.WriteLine();

        string[] digitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var shortNamedDigits = digitNames.Where((name, index) => name.Length < index);
        Console.WriteLine("3. Digits with name shorter than value:");
        foreach (var digit in shortNamedDigits)
        {
            Console.WriteLine($"- {digit}");
        }
        Console.WriteLine();

        Console.WriteLine("--- LINQ - Element Operators ---");
        Console.WriteLine();

        var firstOutOfStockProduct = products.FirstOrDefault(p => p.UnitsInStock == 0);
        Console.WriteLine("1. First product out of stock:");
        if (firstOutOfStockProduct != null)
        {
            Console.WriteLine($"- {firstOutOfStockProduct.ProductName}");
        }
        else
        {
            Console.WriteLine("- None found.");
        }
        Console.WriteLine();

        var expensiveProduct = products.FirstOrDefault(p => p.UnitPrice > 1000.00M);
        Console.WriteLine("2. First product over $1000:");
        if (expensiveProduct != null)
        {
            Console.WriteLine($"- {expensiveProduct.ProductName}");
        }
        else
        {
            Console.WriteLine("- None found.");
        }
        Console.WriteLine();

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var secondNumberGreaterThanFive = numbers.Where(n => n > 5).ElementAtOrDefault(1);
        Console.WriteLine("3. Second number greater than 5:");
        if (secondNumberGreaterThanFive != 0)
        {
            Console.WriteLine($"- {secondNumberGreaterThanFive}");
        }
        else
        {
            Console.WriteLine("- Not enough numbers found.");
        }
        Console.WriteLine();
    }
}