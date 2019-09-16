using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 9-12-19
* CSC 253
* Samuel Blythe
* Word Counter - Counts the number of words in a user typed sentence.
*/


namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;


            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Word Counter");
                Console.WriteLine(" ");
                Console.WriteLine("1. Run program");
                Console.WriteLine("2. Exit");
                Console.WriteLine(" ");
                Console.Write("Choose an option (1 or 2): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    wordCount();
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

        public static void wordCount()
        {
            List<string> wordList = new List<string>();

            Console.WriteLine(" ");
            Console.WriteLine("Type a sentence to receive a word count.");
            Console.WriteLine(" ");
            string input2 = Console.ReadLine();

            char[] sep = { ' ' };
            int words = input2.Split(sep, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine(" ");
            Console.WriteLine($"Number of words typed: {words}");
            Console.ReadLine();
        }
    }
}
