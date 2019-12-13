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
        public static void SavePlayer(List<List<IRoom>> inRoomList)
        {
            List<IRoom> playerList = inRoomList[4];
            try
            {
                // saves player object data to Player.txt file
                StreamWriter outputFile;
                outputFile = File.CreateText("Player.txt");
                foreach (Player player in playerList)
                {
                    outputFile.WriteLine(player.Name);
                    outputFile.WriteLine(player.Password);
                    outputFile.WriteLine(player.Health);
                    outputFile.WriteLine(player.Attack);
                    outputFile.WriteLine(player.Armor);
                    outputFile.WriteLine(8);
                    outputFile.WriteLine(player.Crit);
                    outputFile.WriteLine(player.Zodiac);
                    outputFile.WriteLine(player.Relic);
                }

                outputFile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            SavePlayerInventory(playerList);
        }
        public static void SavePlayerInventory(List<IRoom> playerList)
        {
            try
            {
                // saves player object data to Player.txt file
                StreamWriter outputFile;
                outputFile = File.CreateText("PlayerInventory2.txt");
                foreach (Player player in playerList)
                {
                    outputFile.WriteLine(player.Name);
                    foreach (IRoom item in player.Inventory)
                    {
                        if(item is Loot loot)
                        {
                            outputFile.WriteLine(loot.Name);
                        }
                        if(item is Weapon weapon)
                        {
                            outputFile.WriteLine(weapon.Name);
                        }
                    }
                    outputFile.WriteLine("end");
                }

                outputFile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SaveWorld(List<List<IRoom>> inRoomList)
        {
            List<IRoom> roomList = inRoomList[3];
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
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
