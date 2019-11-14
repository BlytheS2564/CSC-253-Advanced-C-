using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/**
* 10-30-19
* CSC 253
* Samuel Blythe
* TeamLeader Class - This program adds a ProductionWorker or TeamLeader into the system using classes and inheritance. 
*/

namespace TeamLeader_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            EmployeeClassLibrary.Employee employee = new EmployeeClassLibrary.Employee();

            EmployeeClassLibrary.ProductionWorker productionWorker = new EmployeeClassLibrary.ProductionWorker();

            EmployeeClassLibrary.TeamLeader teamLeader = new EmployeeClassLibrary.TeamLeader();


            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Employee Info");
                Console.WriteLine("");
                Console.WriteLine("1. Add Production Worker");
                Console.WriteLine("2. Add Team Leader");
                Console.WriteLine("3. Exit");
                string input = Console.ReadLine();


                if (input == "1" || input == "2")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Employee Name: ");
                    string input2 = Console.ReadLine();
                    employee.Name = input2;

                    Console.WriteLine("Employee IdNumber: ");
                    string input3 = Console.ReadLine();
                    int.TryParse(input3, out int idInput);
                    employee.IdNumber = idInput;
                }


                if (input == "1")
                {

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
                    Console.WriteLine($"Name: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(employee.Name)}");
                    Console.WriteLine($"IdNumber: {employee.IdNumber}");
                    Console.WriteLine($"Shift: {productionWorker.Shift}");
                    Console.WriteLine($"Pay Rate: {productionWorker.PayRate.ToString("C", CultureInfo.CurrentCulture)}");
                    Console.WriteLine(" ");

                    productionWorker = new EmployeeClassLibrary.ProductionWorker();
                }
                else if (input == "2")
                {

                    Console.WriteLine("Pay Rate: ");
                    string input5 = Console.ReadLine();
                    double.TryParse(input5, out double payRate);
                    productionWorker.PayRate = payRate;

                    teamLeader.MonthlyBonus = 2400;

                    Console.WriteLine("Training Hours worked: ");
                    string input6 = Console.ReadLine();
                    int.TryParse(input6, out int traininghours);
                    teamLeader.Training = 16;


                    teamLeader.Training -= traininghours;
                    Console.WriteLine(" ");
                    Console.WriteLine("Employee");
                    Console.WriteLine($"Name: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(employee.Name)}");
                    Console.WriteLine($"IdNumber: {employee.IdNumber}");
                    Console.WriteLine($"Pay Rate: {productionWorker.PayRate.ToString("C", CultureInfo.CurrentCulture)}");
                    Console.WriteLine($"Fixed Monthly Bonus: {teamLeader.MonthlyBonus.ToString("C", CultureInfo.CurrentCulture)}");
                    Console.WriteLine($"Training Hours Left: {teamLeader.Training} out of 16 hours.");
                    Console.WriteLine(" ");

                    teamLeader = new EmployeeClassLibrary.TeamLeader();
                }

                else if (input == "3")
                {
                    exit = true;
                }

                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Please Type 1, 2, or 3.");
                    Console.WriteLine(" ");
                }

            } while (exit == false);
        }
    }
}
