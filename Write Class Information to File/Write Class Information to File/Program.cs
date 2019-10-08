using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/**
* 10-3-19
* CSC 253
* Samuel Blythe
* This program saves employee information into a class and writes it to a file called userinformation. 
*/

namespace Write_Class_Information_to_File
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            PersonClassLibrary.Person item = new PersonClassLibrary.Person();

            List<PersonClassLibrary.Person> items = new List<PersonClassLibrary.Person>();

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
                    Console.WriteLine("Employee Name: ");
                    string input2 = Console.ReadLine();
                    Console.WriteLine("Employee IdNumber: ");
                    string input3 = Console.ReadLine();
                    int.TryParse(input3, out idInput);
                    Console.WriteLine("Employee Department: ");
                    string input4 = Console.ReadLine();
                    Console.WriteLine("Employee Position: ");
                    string input5 = Console.ReadLine();

                    PersonClassLibrary.Person item1 = new PersonClassLibrary.Person(input2, idInput, input4, input5);
                    items.Add(item1);


                    foreach (var i in items)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Employee");
                        Console.WriteLine($"Name: {i.Name}");
                        Console.WriteLine($"IdNumber: {i.IdNumber}");
                        Console.WriteLine($"Department: {i.Department}");
                        Console.WriteLine($"Position: {i.Position}");
                        Console.WriteLine(" ");

                        StreamWriter outputFile;
                        outputFile = File.AppendText("UserInformation.txt");

                        outputFile.WriteLine(i.Name);
                        outputFile.WriteLine(i.IdNumber);
                        outputFile.WriteLine(i.Department);
                        outputFile.WriteLine(i.Position);

                        outputFile.Close();
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
