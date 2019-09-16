using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 9-15-19
* CSC 253
* Samuel Blythe
* Average Number of Letters - Program calculates number of words, characters, and average # of chars per word.
*/

namespace Average_Number_of_Letters
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
            Console.WriteLine(" ");
            Console.WriteLine("Type a sentence to receive a word count.");
            Console.WriteLine(" ");
            string input2 = Console.ReadLine();

            char[] sep = { ' ' };
            int words = input2.Split(sep, StringSplitOptions.RemoveEmptyEntries).Length;
            input2 = input2.Replace(" ", "");
            int characters = input2.Length;
            double average = characters / words;

            Console.WriteLine(" ");
            Console.WriteLine($"Number of words typed: {words}");
            Console.WriteLine($"Number of characters typed: {characters}");
            Console.WriteLine($"Average number of letters per word: {average}");
            Console.ReadLine();
           
        }
    }
}
