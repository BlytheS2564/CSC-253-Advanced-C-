using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
* 9-15-19
* CSC 253
* Samuel Blythe
* Most Frequent Character - Type a string to receive the most frequently used character.
*/

namespace Most_Frequent_Character
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;


            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Most Frequent Character");
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
            int[] characters = new int[256];
            int charCount = -1;
            char character = ' ';

            Console.WriteLine(" ");
            Console.WriteLine("Type a string to receive the most frequently used character.");
            Console.WriteLine(" ");
            string input2 = Console.ReadLine();


            int length = input2.Length;
            for (int i = 0; i < length; i++)
            {
                characters[input2[i]]++;
            }

            for (int i = 0; i < length; i++)
            {
                if (charCount < characters[input2[i]])
                {
                    charCount = characters[input2[i]];
                    character = input2[i];
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine($"In your string: {input2}");
            Console.WriteLine($"The character which occurs the most is: {character}");
            Console.WriteLine($"The number of times this character appears is: {charCount}");
            Console.ReadLine();

        }
    }
}
