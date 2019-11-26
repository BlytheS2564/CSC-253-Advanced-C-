using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLibrary;

namespace EmployeeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            do
            {
                MainMenu();
                string input = Console.ReadLine();
                if (input == "1")
                {

                    Employee employee = new Employee();

                    Console.WriteLine("");
                    employee.Name = "Susan Meyers";
                    employee.IdNumber = 47899;
                    employee.Department = "Accounting";
                    employee.Position = "Vice President";

                    Console.WriteLine("Employee 1");
                    Console.WriteLine($"Name: {employee.Name}");
                    Console.WriteLine($"IdNumber: {employee.IdNumber}");
                    Console.WriteLine($"Department: {employee.Department}");
                    Console.WriteLine($"Position: {employee.Position}");
                    Console.WriteLine("");


                    Employee employee2 = new Employee("Mark Jones", 39119, "IT", "Programmer");

                    Console.WriteLine("Employee 2");
                    Console.WriteLine($"Name: {employee2.Name}");
                    Console.WriteLine($"IdNumber: {employee2.IdNumber}");
                    Console.WriteLine($"Department: {employee2.Department}");
                    Console.WriteLine($"Position: {employee2.Position}");
                    Console.WriteLine("");

                    Employee employee3 = new Employee("Joy Rogers", 81774, "Manufacturing", "Engineer");

                    Console.WriteLine("Employee 3");
                    Console.WriteLine($"Name: {employee3.Name}");
                    Console.WriteLine($"IdNumber: {employee3.IdNumber}");
                    Console.WriteLine($"Department: {employee3.Department}");
                    Console.WriteLine($"Position: {employee3.Position}");
                    Console.ReadLine();
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
        public static void MainMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Would you like to view company employees?");
            Console.WriteLine("1. View");
            Console.WriteLine("2. Exit ");
            Console.WriteLine(" ");
        }
    
    }
}
