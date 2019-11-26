using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Save
    {
        public static void SavePlayer(Player player)
        {
            try
            {
                // saves player object data to Player.txt file
                StreamWriter outputFile;
                outputFile = File.CreateText("Player.txt");

                outputFile.WriteLine(player.Name);
                outputFile.WriteLine(player.Password);
                outputFile.WriteLine(player.Health);
                outputFile.WriteLine(player.Armor);
                outputFile.WriteLine(player.Crit);
                outputFile.WriteLine(player.Zodiac);
                outputFile.WriteLine(player.Relic);
                outputFile.WriteLine(player.CurrentRoom);

                outputFile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SaveWorld(List<IRoom> roomList)
        {
            try
            {
                // saves room object data to Rooms2.txt file
                StreamWriter outputFile;
                outputFile = File.CreateText("Rooms2.txt");

                Random user = new Random();

                foreach (Room obj in roomList)
                {
                    Room room = new Room();
                    room = obj;
                    outputFile.WriteLine(room.RoomID);
                    outputFile.WriteLine(room.RoomName);
                    outputFile.WriteLine(room.RoomDescription);
                }
                outputFile.Close();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Game Saved");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
