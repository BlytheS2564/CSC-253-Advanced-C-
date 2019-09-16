using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 9-1-19
 * CSC 253
 * Samuel Blythe
 * RetailItem Class displays item inventory
 */

namespace RetailItem_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            RetailItem.Item item = new RetailItem.Item();

            List<RetailItem.Item> items = new List<RetailItem.Item>();

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Retail Item Inventory");
                Console.WriteLine("");
                Console.WriteLine("1. View items");
                Console.WriteLine("2. Exit");
                string input = Console.ReadLine();

                if (input == "1") 
                {
                    RetailItem.Item item1 = new RetailItem.Item("Jacket", 12, 59.95);
                    items.Add(item1);

                    RetailItem.Item item2 = new RetailItem.Item("Jeans", 40, 34.95);
                    items.Insert(1, item2);

                    RetailItem.Item item3 = new RetailItem.Item("Shirt", 20, 24.95);
                    items.Insert(2, item3);

                    int count = 1;
                    foreach (var i in items)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Item {count}");
                        Console.WriteLine($"Description: {i.Description}");
                        Console.WriteLine($"Units On Hand: {i.UnitsOnHand}");
                        Console.WriteLine($"Price: ${i.Price}");
                        count += 1;
                    }
                }
                else if (input == "2")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Please Type 1 or 2.");
                    Console.WriteLine(" ");
                }

            } while (exit == false);

        }

    }
}
