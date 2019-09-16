using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarClass;

/**
* 9-1-19
* CSC 153
* Samuel Blythe
* Car Class. Lets you create a car then accelerate and brake.
*/

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            bool exit = false;

            do
            {

                Console.WriteLine(" ");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Create a car.");
                Console.WriteLine("2. Accelerate. ");
                Console.WriteLine("3. Brake. ");
                Console.WriteLine("4. Exit. ");
                Console.WriteLine(" ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("What is the year of your car? ");
                    car.Year = int.Parse(Console.ReadLine());

                    Console.Write($"What is the make of your car? ");
                    car.Make = Console.ReadLine();
                    Console.WriteLine($"You have created a {car.Year} {car.Make}.");
                    Console.ReadLine();
                }
                else if (input == "2")
                {
                    car.Accelerate();
                    Console.WriteLine($"The {car.Year} {car.Make} is going {car.Speed} mph.");
                }
                else if (input == "3")
                {
                    car.Brake();
                    Console.WriteLine($"The {car.Year} {car.Make} is going {car.Speed} mph.");
                }

                else if (input == "4")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Please Type 1, 2, 3, or 4.");
                    Console.WriteLine(" ");
                }

            } while (exit == false);


        }
    }
}

