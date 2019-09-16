using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 9-1-19
* CSC 253
* Samuel Blythe
* Population predictor 
*/

namespace Population
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                bool exit = false;


                do
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Population Predictor");
                    Console.WriteLine(" ");
                    Console.WriteLine("1. Run program");
                    Console.WriteLine("2. Exit");
                    Console.WriteLine(" ");
                    Console.Write("Choose an option (1 or 2): ");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        double organism = 0;
                        double popIncrease = 0;
                        double days = 0;
                        double approxPop = 0;


                        Console.WriteLine("How many organisms do you have?");
                        string input2 = Console.ReadLine();
                        if (double.TryParse(input2, out organism))
                        {

                            Console.WriteLine($"Number of Organisms is {organism}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");

                        }

                        Console.WriteLine(" ");
                        Console.WriteLine("What is the average daily population increase percentage?");
                        string input3 = Console.ReadLine();

                        if (double.TryParse(input3, out popIncrease))
                        {
                            Console.WriteLine($"Population increase is {popIncrease}%");
                            popIncrease = popIncrease / 100;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }

                        Console.WriteLine(" ");
                        Console.WriteLine("How many days will the organisms be left to multiply?");
                        string input4 = Console.ReadLine();

                        if (double.TryParse(input4, out days))
                        {

                            Console.WriteLine($"Number of days is {days}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                        if (days == 1)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Day 1: 1");
                            Console.WriteLine($"Population after 1 day is {organism}.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine($"Day 1: {organism}");

                            for (double i = 2; i <= days; i++)
                            {
                                approxPop = (popIncrease * organism) + organism;
                                organism = approxPop;

                                Console.WriteLine($"Day {i}: {approxPop}");

                            }

                            Console.WriteLine(" ");
                            Console.WriteLine($"Population after {days} days is {organism}.");
                            Console.ReadLine();
                        }
                    }

                    else if (input == "2")
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Please type '1' or '2'");
                        Console.WriteLine(" ");
                    }
                } while (exit == false);
            }
        }
    }
}
