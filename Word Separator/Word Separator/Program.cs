using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 9-15-19
* CSC 253
* Samuel Blythe
* Word Separator - Type a sentence with no spaces to receive your sentence back with words seperated.
* System.Globalization must be used.
*/

namespace Word_Separator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;


            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Word Separator");
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
            Console.WriteLine("Type a sentence with no spaces to receive your sentence back with words seperated.");
            Console.WriteLine("Example: HelloHowAreYou");
            Console.WriteLine(" ");
            string input2 = Console.ReadLine();


            var sepString = "";
            bool firstChar = false;
            foreach (char c in input2)
            {
                if (char.IsUpper(c))
                {
                    if (input2.IndexOf(c) == 0 && !firstChar)
                    {
                        sepString += " " + c.ToString();
                        firstChar = true;
                    }
                    else
                        sepString += " " + c.ToString();
                }
                else
                    sepString += c.ToString();

                sepString = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sepString);
                
            }

            Console.WriteLine(" ");
            Console.WriteLine($"Your string with the words separated is: {sepString.Trim()}");
            Console.ReadLine();

        }
    
    }
}
