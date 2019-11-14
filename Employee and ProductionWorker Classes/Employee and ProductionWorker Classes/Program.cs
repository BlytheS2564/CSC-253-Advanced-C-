using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeClassLibrary;


/**
* 10-27-19
* CSC 253
* Samuel Blythe
* This program adds employees into the system using classes and inheritance. 
*/

namespace Employee_and_ProductionWorker_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            EmployeeClassLibrary.ProductionWorker employee = new EmployeeClassLibrary.ProductionWorker();

            List<EmployeeClassLibrary.ProductionWorker> employees = new List<EmployeeClassLibrary.ProductionWorker>();

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Employee Info");
                Console.WriteLine("");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Exit");
                string input = Console.ReadLine();

                if (input == "1")
                {

                    int idInput = 0;
                    int shift = 0;
                    double pay = 0;
                    Console.WriteLine(" ");
                    Console.WriteLine("Employee Name: ");
                    string input2 = Console.ReadLine();
                    employee.Name = input2;

                    Console.WriteLine("Employee IdNumber: ");
                    string input3 = Console.ReadLine();
                    int.TryParse(input3, out idInput);
                    employee.IdNumber = idInput;

                    Console.WriteLine("Shift: ");
                    string input4 = Console.ReadLine();
                    int.TryParse(input4, out shift);
                    employee.Shift = shift;

                    Console.WriteLine("Pay Rate: ");
                    string input5 = Console.ReadLine();
                    double.TryParse(input5, out pay);
                    employee.PayRate = pay;

                    employees.Add(employee);
                    employee = new ProductionWorker();

                    foreach (var i in employees)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Employee");
                        Console.WriteLine($"Name: {i.Name}");
                        Console.WriteLine($"IdNumber: {i.IdNumber}");
                        Console.WriteLine($"Shift: {i.Shift}");
                        Console.WriteLine($"PayRate: ${i.PayRate}");
                        Console.WriteLine(" ");
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
