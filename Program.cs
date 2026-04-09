using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ läbi switchi");
            Console.WriteLine("Vali tegevus numbriga:");
            Console.WriteLine("1. Filtreerimine (Where)");
            Console.WriteLine("2. Sorteerimine (OrderBy)");
            Console.WriteLine("3. Andmete projitseerimine (Select)");
            Console.WriteLine("4. Andmete vahelejätmine (Skip) ");
            Console.WriteLine("5. Võtmine tingimuse alusel (TakeWhile) ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WhereLINQ();
                    break;
                case 2:
                    SortLINQ();
                    break;
                case 3:
                    SelectLINQ();
                    break;
                case 4:
                    SkipLINQ();
                    break;
                case 5:
                    TakeWhileLINQ();
                    break;
                default:
                    Console.WriteLine("Vale valik");
                    break;
            }
        }
        public static void WhereLINQ()
        {
            var expensiveProducts = Data.Products
                .Where(p => p.Price > 60);
            Console.WriteLine("Tooted, mille hind on üle 60€:");
            foreach (var p in expensiveProducts)
            {
                Console.WriteLine(p.Name + " - " + p.Price + "€");
            }

            var tallinnClients = Data.Clients
                .Where(c => c.City == "Tallinn");
            Console.WriteLine("\nTallinnas elavad kliendid:");
            foreach (var c in tallinnClients)
            {
                Console.WriteLine(c.Name);
            }
        }
        public static void SortLINQ()
        {
            var productsByPriceDesc = Data.Products
                .OrderByDescending(p => p.Price);
            Console.WriteLine("Tooted hinna järgi kahanevalt:");
            foreach (var p in productsByPriceDesc)
            {
                Console.WriteLine(p.Name + " - " + p.Price + "€");
            }

            var clientsByCityThenName = Data.Clients
                .OrderBy(c => c.City)
                .ThenBy(c => c.Name);
            Console.WriteLine("\nKliendid linna ja nime järgi:");
            foreach (var c in clientsByCityThenName)
            {
                Console.WriteLine(c.Name + " (" + c.City + ")");
            }
        }
        public static void SelectLINQ()
        {
            var categories = Data.Products
                .Select(p => p.Category)
                .Distinct();
            Console.WriteLine("Toodete kategooriad:");
            foreach (var cat in categories)
            {
                Console.WriteLine(cat);
            }
        }
        public static void SkipLINQ()
        {
            var skip4Products = Data.Products
                .OrderBy(p => p.Price)
                .Skip(4);
            Console.WriteLine("Tooted, vahele jäetud 4 esimest hinnalt järjestatuna:");
            foreach (var p in skip4Products)
            {
                Console.WriteLine(p.Name + " - " + p.Price + "€");
            }
        }
        public static void TakeWhileLINQ()
        {
            var takeWhileProducts = Data.Products
                .OrderBy(p => p.Price)
                .TakeWhile(p => p.Price < 90);
            Console.WriteLine("Tooted seni, kuni hind < 90€:");
            foreach (var p in takeWhileProducts)
            {
                Console.WriteLine(p.Name + " - " + p.Price + "€");
            }
        }
    }
    public static class Data
    {
        public static List<Product> Products = new List<Product>
        {
            new Product {Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Amount = 5},
            new Product {Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Amount = 10},
            new Product {Id = 3, Name = "Mouse", Category = "Electronics", Price = 25, Amount = 50},
            new Product {Id = 4, Name = "Keyboard", Category = "Electronics", Price = 45, Amount = 30},
            new Product {Id = 5, Name = "Table", Category = "Furniture", Price = 150, Amount = 7},
            new Product {Id = 6, Name = "Chair", Category = "Furniture", Price = 70, Amount = 15},
            new Product {Id = 7, Name = "Lamp", Category = "Home", Price = 40, Amount = 20},
            new Product {Id = 8, Name = "Monitor", Category = "Electronics", Price = 200, Amount = 8},
            new Product {Id = 9, Name = "Book", Category = "Education", Price = 20, Amount = 100},
            new Product {Id = 10, Name = "Headphones", Category = "Electronics", Price = 65, Amount = 12},
        };

        public static List<Client> Clients = new List<Client>
        {
            new Client {Id = 1, Name = "Ivan", City = "Tallinn"},
            new Client {Id = 2, Name = "Anna", City = "Tartu"},
            new Client {Id = 3, Name = "Mark", City = "Tallinn"},
            new Client {Id = 4, Name = "Olga", City = "Narva"},
            new Client {Id = 5, Name = "John", City = "Tallinn"},
        };
    }

    public class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
        public int Amount;
    }

    public class Client
    {
        public int Id;
        public string Name;
        public string City;
    }
}