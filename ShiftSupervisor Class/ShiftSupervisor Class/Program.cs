using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 10-27-19
* CSC 253
* Samuel Blythe
* ShiftSupervisor - This program adds employees into the system using classes and inheritance. 
*/


namespace ShiftSupervisor_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            EmployeeClassLibrary.ProductionWorker productionWorker = new EmployeeClassLibrary.ProductionWorker();

            EmployeeClassLibrary.ShiftSupervisor shiftSupervisor = new EmployeeClassLibrary.ShiftSupervisor();

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Employee Info");
                Console.WriteLine("");
                Console.WriteLine("1. Add Production Worker");
                Console.WriteLine("2. Add Shift Supervisor");   
                Console.WriteLine("3. Exit");
                string input = Console.ReadLine();

                if (input == "1")
                {

                    Console.WriteLine(" ");
                    Console.WriteLine("Employee Name: ");
                    string input2 = Console.ReadLine();
                    productionWorker.Name = input2;

                    Console.WriteLine("Employee IdNumber: ");
                    string input3 = Console.ReadLine();
                    int.TryParse(input3, out int idInput);
                    productionWorker.IdNumber = idInput;

                    Console.WriteLine("Shift: ");
                    string input4 = Console.ReadLine();
                    int.TryParse(input4, out int shift);
                    productionWorker.Shift = shift;

                    Console.WriteLine("Pay Rate: ");
                    string input5 = Console.ReadLine();
                    double.TryParse(input5, out double payRate);
                    productionWorker.PayRate = payRate;


                    Console.WriteLine(" ");
                    Console.WriteLine("Employee");
                    Console.WriteLine($"Name: {productionWorker.Name}");
                    Console.WriteLine($"IdNumber: {productionWorker.IdNumber}");
                    Console.WriteLine($"Shift: {productionWorker.Shift}");
                    Console.WriteLine($"Pay Rate: ${productionWorker.PayRate}");
                    Console.WriteLine(" ");

                    productionWorker = new EmployeeClassLibrary.ProductionWorker();
                }
                else if (input == "2")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Employee Name: ");
                    string input2 = Console.ReadLine();
                    shiftSupervisor.Name = input2;

                    Console.WriteLine("Employee IdNumber: ");
                    string input3 = Console.ReadLine();
                    int.TryParse(input3, out int idInput);
                    shiftSupervisor.IdNumber = idInput;

                    Console.WriteLine("Salary: ");
                    string input4 = Console.ReadLine();
                    double.TryParse(input4, out double salary);
                    shiftSupervisor.Salary = salary;

                    Console.WriteLine("Bonus: ");
                    string input5 = Console.ReadLine();
                    double.TryParse(input5, out double bonus);
                    shiftSupervisor.Bonus = bonus;

                    Console.WriteLine(" ");
                    Console.WriteLine("Employee");
                    Console.WriteLine($"Name: {shiftSupervisor.Name}");
                    Console.WriteLine($"IdNumber: {shiftSupervisor.IdNumber}");
                    Console.WriteLine($"Salary: ${shiftSupervisor.Salary}");
                    Console.WriteLine($"Bonus: ${shiftSupervisor.Bonus}");
                    Console.WriteLine(" ");

                    shiftSupervisor = new EmployeeClassLibrary.ShiftSupervisor();
                }


                else if (input == "3")
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
