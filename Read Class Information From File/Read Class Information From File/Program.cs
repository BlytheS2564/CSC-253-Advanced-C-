using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/**
* 10-6-19
* CSC 253
* Samuel Blythe
* This program reads the UserInformation text file, saves the information to a class, and displays the information.
*/

namespace Read_Class_Information_From_File
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
                Console.WriteLine("1. View Employee");
                Console.WriteLine("2. Exit");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    string name = " ";
                    int id = 0;
                    string dept = " ";
                    string pos = " ";

                    StreamReader inputFile;
                    inputFile = File.OpenText("UserInformation.txt");

                    while (!inputFile.EndOfStream)
                    {
                        name = inputFile.ReadLine();
                        id = int.Parse(inputFile.ReadLine());
                        dept = inputFile.ReadLine();
                        pos = inputFile.ReadLine();
                    }

                    PersonClassLibrary.Person item1 = new PersonClassLibrary.Person(name, id, dept, pos);
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
                    }

                    inputFile.Close();
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
