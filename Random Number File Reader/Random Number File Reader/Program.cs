using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 9-29-19
* CSC 253
* Samuel Blythe
* Random Number File Reader- Reads numbers in a file, displays the number, count, and total.
*/

namespace Random_Number_File_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;


            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Random Number File Reader");
                Console.WriteLine(" ");
                Console.WriteLine("1. Run program");
                Console.WriteLine("2. Exit");
                Console.WriteLine(" ");
                Console.Write("Choose an option (1 or 2): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    reader();
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

        public static void reader()
        {

            Console.WriteLine("");
            Console.WriteLine("Numbers in the text file.");


            int num = 0;
            string text;
            int total = 0;
            int count = 0;
 

            StreamReader inputFile;
            inputFile = File.OpenText("RandomNumber.txt");

            while (!inputFile.EndOfStream)
            {
                text = inputFile.ReadLine();
                int.TryParse(text, out num);
                total += num;
                Console.WriteLine(num);
                ++count;

            }
            Console.WriteLine($" ");
            Console.WriteLine($"Count: {count}");
            Console.WriteLine($"Total: {total}");

            inputFile.Close();


        }
    
    }
}
