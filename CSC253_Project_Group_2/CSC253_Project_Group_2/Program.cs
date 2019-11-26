using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 10/25/19
* CSC 253
* Group 2 - Michael Blythe, Scott Blythe
* CSC 253 Project Sprint 3 Group 2 - Silent Slope
*/

namespace CSC253_Project_Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadLine();
            Console.Clear();
            SilentSlope.GameUtilities.GameMenu();
        }
        public static void Menu()
        {
            // main menu logo display

            Console.WriteLine("");
            Console.WriteLine("   ██████  ██▓ ██▓    ▓█████  ███▄    █ ▄▄▄█████▓");
            Console.WriteLine(" ▒██    ▒ ▓██▒▓██▒    ▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒");
            Console.WriteLine(" ░ ▓██▄   ▒██▒▒██░    ▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░");
            Console.WriteLine("   ▒   ██▒░██░▒██░    ▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░ ");
            Console.WriteLine(" ▒██████▒▒░██░░██████▒░▒████▒▒██░   ▓██░  ▒██▒ ░ ");
            Console.WriteLine(" ▒ ▒▓▒ ▒ ░░▓  ░ ▒░▓  ░░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   ");
            Console.WriteLine(" ░ ░▒  ░ ░ ▒ ░░ ░ ▒  ░ ░ ░  ░░ ░░   ░ ▒░    ░    ");
            Console.WriteLine(" ░  ░  ░   ▒ ░  ░ ░      ░      ░   ░ ░   ░      ");
            Console.WriteLine("       ░   ░      ░  ░   ░  ░         ░          ");
            Console.WriteLine("                                                 ");
            Console.WriteLine("   ██████  ██▓     ▒█████   ██▓███  ▓█████       ");
            Console.WriteLine(" ▒██    ▒ ▓██▒    ▒██▒  ██▒▓██░  ██▒▓█   ▀       ");
            Console.WriteLine(" ░ ▓██▄   ▒██░    ▒██░  ██▒▓██░ ██▓▒▒███         ");
            Console.WriteLine("   ▒   ██▒▒██░    ▒██   ██░▒████▓▒ ▒▒▓█  ▄       ");
            Console.WriteLine(" ▒██████▒▒░██████▒░ ████▓▒░▒██▒ ░  ░░▒████▒      ");
            Console.WriteLine(" ▒ ▒▓▒ ▒ ░░ ▒░▓  ░░ ▒░▒░▒░ ▒▓█░ ░  ░░░ ▒░ ░      ");
            Console.WriteLine(" ░ ░▒  ░ ░░ ░ ▒  ░  ░ ▒ ▒░ ░▒ ░      ░ ░  ░      ");
            Console.WriteLine(" ░  ░  ░    ░ ░   ░ ░ ░ ▒  ░░          ░         ");
            Console.WriteLine("       ░      ░  ░    ░ ░              ░  ░      ");
            Console.WriteLine("                                                 ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("");
        }
        public static void MenuEffect()
        {
            // alternate main menu logo (red) display
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("   ██████  ██▓ ██▓    ▓█████  ███▄    █ ▄▄▄█████▓");
            Console.WriteLine(" ▒██    ▒ ▓██▒▓██▒    ▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒");
            Console.WriteLine(" ░ ▓██▄   ▒██▒▒██░    ▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░");
            Console.WriteLine("   ▒   ██▒░██░▒██░    ▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░ ");
            Console.WriteLine(" ▒██████▒▒░██░░██████▒░▒████▒▒██░   ▓██░  ▒██▒ ░ ");
            Console.WriteLine(" ▒ ▒▓▒ ▒ ░░▓  ░ ▒░▓  ░░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   ");
            Console.WriteLine(" ░ ░▒  ░ ░ ▒ ░░ ░ ▒  ░ ░ ░  ░░ ░░   ░ ▒░    ░    ");
            Console.WriteLine(" ░  ░  ░   ▒ ░  ░ ░      ░      ░   ░ ░   ░      ");
            Console.WriteLine("       ░   ░      ░  ░   ░  ░         ░          ");
            Console.WriteLine("                                                 ");
            Console.WriteLine("   ██████  ██▓     ▒█████   ██▓███  ▓█████       ");
            Console.WriteLine(" ▒██    ▒ ▓██▒    ▒██▒  ██▒▓██░  ██▒▓█   ▀       ");
            Console.WriteLine(" ░ ▓██▄   ▒██░    ▒██░  ██▒▓██░ ██▓▒▒███         ");
            Console.WriteLine("   ▒   ██▒▒██░    ▒██   ██░▒████▓▒ ▒▒▓█  ▄       ");
            Console.WriteLine(" ▒██████▒▒░██████▒░ ████▓▒░▒██▒ ░  ░░▒████▒      ");
            Console.WriteLine(" ▒ ▒▓▒ ▒ ░░ ▒░▓  ░░ ▒░▒░▒░ ▒▓█░ ░  ░░░ ▒░ ░      ");
            Console.WriteLine(" ░ ░▒  ░ ░░ ░ ▒  ░  ░ ▒ ▒░ ░▒ ░      ░ ░  ░      ");
            Console.WriteLine(" ░  ░  ░    ░ ░   ░ ░ ░ ▒  ░░          ░         ");
            Console.WriteLine("       ░      ░  ░    ░ ░              ░  ░      ");
            Console.WriteLine("                                                 ");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("");
            Console.ReadLine();
        }
    }
}
