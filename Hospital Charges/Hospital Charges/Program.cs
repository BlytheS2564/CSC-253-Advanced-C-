using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 9-1-19
* CSC 253
* Samuel Blythe
* Calculates Hospital Charges
*/

namespace Hospital_Charges
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            double daysStayed = 0;
            double medication = 0;
            double surgical = 0;
            double lab = 0;
            double rehab = 0;
            double totalStayed = 0;
            double miscChargeTotal = 0;


            do
            {
                MainMenu();
                string input2 = Console.ReadLine();
                if (input2 == "1")
                {
                    totalStayed = CalcStayCharges(daysStayed);
                }
                else if (input2 == "2")
                {
                    miscChargeTotal = CalcMiscCharges(medication, surgical, lab, rehab);
                }
                else if (input2 == "3")
                {
                    CalcTotalCharges(totalStayed, miscChargeTotal, daysStayed, medication, surgical, lab, rehab);
                }
                else if (input2 == "4")
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
        
        public static void MainMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Hospital Charge Calculator");
            Console.WriteLine(" ");
            Console.WriteLine("Which charges would you like to add to your bill?");
            Console.WriteLine(" ");
            Console.WriteLine("1. Days spent in the Hospital.");
            Console.WriteLine("2. Miscellaneous Charges.");
            Console.WriteLine("3. View Total Charges.");
            Console.WriteLine("4. Exit ");

        }

        private static double CalcStayCharges(double daysStayed)
        {

            Console.WriteLine("How many days did the patient stay in the hospital?");
            string daysInput = Console.ReadLine();
            if (double.TryParse(daysInput, out daysStayed))
            {
                double totalStayed = 0;
                totalStayed = daysStayed * 350;

                Console.WriteLine(" ");
                Console.WriteLine("At $350 per night");
                Console.WriteLine($"Total stay charge: ${totalStayed}.");
                Console.WriteLine(" ");

                return totalStayed;
            }
            else
            {
                daysStayed = 0;
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Please Type 1 or 2.");
                Console.WriteLine(" ");

                return daysStayed;
            }
        }



        private static double CalcMiscCharges(double medication, double surgical, double lab, double rehab)
        {
                double miscChargeTotal = 0;

                Console.Write("Please enter medication charges: $");
                medication = double.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                Console.Write("Please enter surgical charges: $");
                surgical = double.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                Console.Write("Please enter lab fees: $");
                lab = double.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                Console.Write("Please enter rehab charges: $");
                rehab = double.Parse(Console.ReadLine());
                Console.WriteLine(" ");


                miscChargeTotal = medication + surgical + lab + rehab;

                Console.WriteLine($"Total medication charge: ${medication}.");
                Console.WriteLine($"Total surgical charge: ${surgical}.");
                Console.WriteLine($"Total lab charge: ${lab}.");
                Console.WriteLine($"Total rehab charge: ${rehab}.");
                Console.WriteLine(" ");
                Console.WriteLine($"Total Misc Charges: ${miscChargeTotal}.");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                return miscChargeTotal;

        }


        private static void CalcTotalCharges(double totalStayed, double miscChargeTotal, double daysStayed, double medication, double surgical, double lab, double rehab)
        {

            double total = 0;
            total = totalStayed + miscChargeTotal;

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine($"Total Hospital Charges: ${total}.");
            Console.WriteLine(" ");
        }

    }
}
