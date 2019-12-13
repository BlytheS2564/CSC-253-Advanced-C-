using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class CreateNewChar
    {
        enum AstrologyZodiac
        {
            Aquarius = 1,
            Pisces = 2,
            Aries = 3,
            Taurus = 1,
            Gemini = 2,
            Cancer = 3,
            Leo = 1,
            Libra = 2,
            Virgo = 3,
            Capricorn = 1,
            Scorpio = 2,
            Sagittarius = 3
        }
        public static Player CharacterDetails(Player player)
        {
            // asks the user questions to fill out the player class object

            int validate = -1;

            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter player name: ");
            Console.ResetColor();
            player.Name = Console.ReadLine();
            Console.WriteLine(" ");

            player.Health = 100;
            player.Attack = 10;
            player.Armor = 0;
            player.Relic = "Null";
            player.CurrentRoom = 8;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            player = AstrologyZodiacSign(player);
            Console.ResetColor();
            Console.WriteLine(" ");

            // a do while look to make sure the password is done correctly. Sents it to PasswordCheck for validation
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Create user password");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Password must contain at least:");
                Console.WriteLine("(1) Upper character");
                Console.WriteLine("(1) Lower character");
                Console.WriteLine("(1) Special character: !@#$%^&*?_~-£().,");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Create password: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                validate = PasswordCheck.CheckPass(input);
                if (validate == 0) { player.Password = input; }
                else if (validate == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must have Upper Case Character"); Console.ResetColor();
                }
                else if (validate == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must have Lower Case Character"); Console.ResetColor();
                }
                else if (validate == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must have Special Character !@#$%^&*?_~-£().,"); Console.ResetColor();
                }
            } while (validate != 0);

            Console.WriteLine(" ");
            Console.WriteLine("Character Created");
            Console.ReadLine();
            return player;
        }
        public static Player AstrologyZodiacSign(Player player)
        {
            // takes the month and day to determine astrology sign
            string astro_sign = "";
            int day = 0;
            string month = "";
            bool isMonth = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("What month were you born? ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(Example: October) ");
                month = Console.ReadLine().ToLower();
                if (month == "january" || month == "february" || month == "march" ||
                    month == "april" || month == "may" || month == "june" || month == "july" ||
                    month == "august" || month == "september" || month == "october" ||
                    month == "november" || month == "december")
                { isMonth = true; }
            } while (isMonth == false);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("What day were you born? ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("(Example. 31) ");
            while (!int.TryParse(Console.ReadLine(), out day))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Enter a numerical date.");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("What day were you born? ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(Example. 31) ");
                Console.ResetColor();
            }

            if (month == "december")
            {
                if (day < 22)
                    astro_sign = "Sagittarius";
                else
                    astro_sign = "Capricorn";
            }

            else if (month == "january")
            {
                if (day < 20)
                    astro_sign = "Capricorn";
                else
                    astro_sign = "Aquarius";
            }

            else if (month == "february")
            {
                if (day < 19)
                    astro_sign = "Aquarius";
                else
                    astro_sign = "Pisces";
            }

            else if (month == "march")
            {
                if (day < 21)
                    astro_sign = "Pisces";
                else
                    astro_sign = "Aries";
            }
            else if (month == "april")
            {
                if (day < 20)
                    astro_sign = "Aries";
                else
                    astro_sign = "Taurus";
            }

            else if (month == "may")
            {
                if (day < 21)
                    astro_sign = "Taurus";
                else
                    astro_sign = "Gemini";
            }

            else if (month == "june")
            {
                if (day < 21)
                    astro_sign = "Gemini";
                else
                    astro_sign = "Cancer";
            }

            else if (month == "july")
            {
                if (day < 23)
                    astro_sign = "Cancer";
                else
                    astro_sign = "Leo";
            }

            else if (month == "august")
            {
                if (day < 23)
                    astro_sign = "Leo";
                else
                    astro_sign = "Virgo";
            }

            else if (month == "september")
            {
                if (day < 23)
                    astro_sign = "Virgo";
                else
                    astro_sign = "Libra";
            }

            else if (month == "october")
            {
                if (day < 23)
                    astro_sign = "Libra";
                else
                    astro_sign = "Scorpio";
            }

            else if (month == "november")
            {
                if (day < 22)
                    astro_sign = "Scorpio";
                else
                    astro_sign = "Sagittarius";
            }
            player.Zodiac = astro_sign;
            Console.WriteLine($"You have received the blessing of the {astro_sign}");
            if ((astro_sign == "Aquarius") || (astro_sign == "Taurus") || (astro_sign == "Leo") || (astro_sign == "Capricorn"))
            {
                Console.WriteLine("(Reduced damage taken)");
                player.Armor = 5;
            }
            else if ((astro_sign == "Pisces") || (astro_sign == "Gemini") || (astro_sign == "Libra") || (astro_sign == "Scorpio"))
            {
                Console.WriteLine("(Increased attack damage)");
                player.Attack = 15;
            }
            else if ((astro_sign == "Aries") || (astro_sign == "Cancer") || (astro_sign == "Virgo") || (astro_sign == "Sagittarius"))
            {
                Console.WriteLine("(Increased max health)");
                player.Health = 120;
            }
            Console.WriteLine("");
            Console.ReadLine();
            return player;
        }

        public static void PassError(int validate)
        {

        }
    }
}
