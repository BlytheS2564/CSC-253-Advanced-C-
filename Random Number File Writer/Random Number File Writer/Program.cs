using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 9-26-19
* CSC 253
* Samuel Blythe
* Random Number File Writer asks the user to specify an amount of random numbers to write to a file.
*/

namespace Random_Number_File_Writer
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exit = false;


            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Random Number File Writer");
                Console.WriteLine(" ");
                Console.WriteLine("1. Run program");
                Console.WriteLine("2. Exit");
                Console.WriteLine(" ");
                Console.Write("Choose an option (1 or 2): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    randNum();
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

        public static void randNum()
        {
            int input2;
            Console.WriteLine("");
            Console.WriteLine("How many random numbers would you like to create?");
            string input = Console.ReadLine();
            int.TryParse(input, out input2);

            int num;
            Random rand = new Random();          

            StreamWriter outputFile;
            outputFile = File.CreateText("RandomNumber.txt");

            for (int i = 0; i < input2; i++)
            {
                num = rand.Next(99) + 1;
                outputFile.WriteLine(num);    
            }

            outputFile.Close();

            Console.WriteLine("");
            Console.WriteLine($"The RandomNumber.txt has been created with {input2} number(s).");
        }
    
    }
}
