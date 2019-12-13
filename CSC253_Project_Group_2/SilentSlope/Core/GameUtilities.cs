using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class GameUtilities
    {
        const int ROWS = 2;
        const int COLS = 2;
        public static void Help()
        {
            // Help menu featuring a brief explaination of the game and control directions
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Help Menu");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------");
            Console.WriteLine("This is a survival horror text based game.");
            Console.WriteLine("Explore the rooms by using the following inputs");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Movement controls");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Type 'north' or 'n' to move north");
            Console.WriteLine("Type 'south' or 's' to move south");
            Console.WriteLine("Type 'east' or 'e' to move east");
            Console.WriteLine("Type 'west' or 'w' to move west");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Action controls");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Type 'look player' or 'look stats' for player info");
            Console.WriteLine("Type 'look room' for room info");
            Console.WriteLine("Type 'take (item name)' to add an item to your inventory");
            Console.WriteLine("Type 'use (item name)'  to equip or use an item");
            Console.WriteLine("Type 'look mobs', 'look weapons', or 'look items' for full obj lists");
            Console.WriteLine("Type 'attack' to attack current mob in room");
            Console.WriteLine(" ");
            Console.WriteLine("Typing 'look' followed by the name of a specific mob, weapon, or item");
            Console.WriteLine("will show you details about that specific object (example: look Beef jerky");
            Console.WriteLine(" ");
            Console.WriteLine("Type 'map' to see current enemies and their locations");
            Console.WriteLine("Type 'save' to save current progress");
            Console.WriteLine("Type 'help' to read the help menu");
            Console.WriteLine("Type 'exit' to exit");
            Console.WriteLine("---------------------------");
            Console.ResetColor();
            Console.ReadLine();
            return;
        }
        public static bool PositionCheck(int row, int col)
        {
            /** Takes the newly created coordinates (row and col) and determines whether the new position will be out 
             *  of the range of the current 2D array. Throws and error otherwise. The Bool roomCheck is turned
             *  to true if the coordinates are within range.
             */
            bool roomCheck = false;
            if (row >= 0 && row <= ROWS)
            {
                // Make sure the column is within range. 
                if (col >= 0 && col <= COLS)
                {
                    roomCheck = true;
                    return roomCheck;
                }
                else
                {
                    // Error message for invalid column.
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot move in that direction");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    return roomCheck;
                }
            }
            else
            {
                // Error message for invalid row.
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot move in that direction");
                Console.ResetColor();
                Console.WriteLine(" ");
                return roomCheck;
            }

        }
        public static List<int> RoomCheck(int newRoom, int row, int col)
        {
            /**Takes the room number which corresponds to the 2D array (ie: coordinate 0,0 = room 1)
             * and matches it with the index stored in the Room array to get the room name.
             */

            List<int> coordinates = new List<int>();
            if (newRoom == 8)
            {
                row = 2;
                col = 1;
                coordinates.Add(row);
                coordinates.Add(col);
                return coordinates;
            }
            else if (newRoom == 5)
            {
                row = 1;
                col = 1;
                coordinates.Add(row);
                coordinates.Add(col);
                return coordinates;
            }
            else if (newRoom == 4)
            {
                row = 1;
                col = 0;
                coordinates.Add(row);
                coordinates.Add(col);
                return coordinates;
            }
            else if (newRoom == 6)
            {
                row = 1;
                col = 2;
                coordinates.Add(row);
                coordinates.Add(col);
                return coordinates;
            }
            else if (newRoom == 2)
            {
                row = 0;
                col = 1;
                coordinates.Add(row);
                coordinates.Add(col);
                return coordinates;
            }
            else
            {
                coordinates.Add(row);
                coordinates.Add(col);
                return coordinates;
            }

        }

        // room enums for lookup purposes
        enum RoomIDs
        {
            Bedroom = 8,
            Kitchen = 5,
            Attic = 4,
            Basement = 6,
            Backyard = 2,
        }

        public static int RoomIDsEnum(string roomName)
        {
            switch (roomName)
            {
                case "Bedroom":
                    return (int)RoomIDs.Bedroom;
                case "Kitchen":
                    return (int)RoomIDs.Kitchen;
                case "Attic":
                    return (int)RoomIDs.Attic;
                case "Basement":
                    return (int)RoomIDs.Basement;
                case "Backyard":
                    return (int)RoomIDs.Backyard;
                default:
                    return (int)RoomIDs.Bedroom;

            }
        }
        //returns the current room object
        public static Room newRoomObject(int newRoom, List<IRoom> roomList)
        {
            Room roomObject = new Room();
            foreach (Room Item in roomList)
            {
                if (newRoom == Item.RoomID)
                {
                    roomObject = Item;
                    return roomObject;
                }
            }
            return roomObject;
        }

        public static void Map(List<IRoom> roomList)
        {
            List<string> map = new List<string>();
            map = MapBuilder(roomList, map);
            foreach (var m in map)
            {
                Console.WriteLine(m);
            }
        }
        public static List<string> MapBuilder(List<IRoom> roomList, List<string> map)
        {
            foreach (var room in roomList)
            {
                if (room is Room roomObject)
                {
                    if (roomObject.RoomContents != null)
                    {
                        foreach (var item in roomObject.RoomContents)
                        {
                            if (item is Mob item1)
                            {
                                map.Add($"Danger - {roomObject.RoomName} contains {item1.Name}");
                            }
                        }
                    }
                }
            }
            return map;
        }
        public static void GameMenu()
        {
            //standard main menu display with switch options to run the program, get help / directions, or exit
            bool exit = false;
            do
            {
                Menu();
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        SilentSlope.Game.CreateNewCharacter();
                        break;
                    case "2":
                        SilentSlope.Game.SilentSlope();
                        break;
                    case "3":
                    case "help":
                        Help();
                        break;
                    case "4":
                    case "exit":
                        exit = true;
                        break;
                    case "picture":
                        Load.ViewPicture();
                        break;
                }
                if (exit == true) { break; };
            } while (exit == false);
        }
        public static void Menu()
        {
            // main menu diplay
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
            Console.WriteLine("   ▒   ██▒▒██░    ▒██   ██░▒████▓▒ ▒▒▓█  ▄      ");
            Console.WriteLine(" ▒██████▒▒░██████▒░ ████▓▒░▒██▒ ░  ░░▒████▒      ");
            Console.WriteLine(" ▒ ▒▓▒ ▒ ░░ ▒░▓  ░░ ▒░▒░▒░ ▒▓█░ ░  ░░░ ▒░ ░      ");
            Console.WriteLine(" ░ ░▒  ░ ░░ ░ ▒  ░  ░ ▒ ▒░ ░▒ ░      ░ ░  ░      ");
            Console.WriteLine(" ░  ░  ░    ░ ░   ░ ░ ░ ▒  ░░          ░         ");
            Console.WriteLine("       ░      ░  ░    ░ ░              ░  ░      ");
            Console.WriteLine("                                                 ");
            Console.ResetColor();
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Load game");
            Console.WriteLine("3. How to play");
            Console.WriteLine("4. Exit");
            Console.WriteLine(" ");
            Console.Write("Choose an option: ");
            Console.ResetColor();
        }
        public static void GameOver()
        {
            // main menu diplay
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("  ▄████ ▄▄▄      ███▄ ▄███▓█████     ▒█████  ██▒   █▓█████ ██▀███  ");
            Console.WriteLine(" ██▒ ▀█▒████▄   ▓██▒▀█▀ ██▓█   ▀    ▒██▒  ██▓██░   █▓█   ▀▓██ ▒ ██▒");
            Console.WriteLine("▒██░▄▄▄▒██  ▀█▄ ▓██    ▓██▒███      ▒██░  ██▒▓██  █▒▒███  ▓██ ░▄█ ▒");
            Console.WriteLine("░▓█  ██░██▄▄▄▄██▒██    ▒██▒▓█  ▄    ▒██   ██░ ▒██ █░▒▓█  ▄▒██▀▀█▄  ");
            Console.WriteLine("░▒▓███▀▒▓█   ▓██▒██▒   ░██░▒████▒   ░ ████▓▒░  ▒▀█░ ░▒████░██▓ ▒██▒");
            Console.WriteLine(" ░▒   ▒ ▒▒   ▓▒█░ ▒░   ░  ░░ ▒░ ░   ░ ▒░▒░▒░   ░ ▐░ ░░ ▒░ ░ ▒▓ ░▒▓░");
            Console.WriteLine("  ░   ░  ▒   ▒▒ ░  ░      ░░ ░  ░     ░ ▒ ▒░   ░ ░░  ░ ░  ░ ░▒ ░ ▒░");
            Console.WriteLine("░ ░   ░  ░   ▒  ░      ░     ░      ░ ░ ░ ▒      ░░    ░    ░░   ░ ");
            Console.WriteLine("      ░      ░  ░      ░     ░  ░       ░ ░       ░    ░  ░  ░     ");
            Console.WriteLine("                                                 ░                 ");
            Console.WriteLine("");
            Console.ResetColor();
        }
        public static void GameOverMenu(Player player)
        {
            //standard main menu display with switch options to run the program, get help / directions, or exit
            bool exit = false;
            GameOver();
            do
            {
                Console.Write("Continue? (y/n): ");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        player.Health = 100;
                        exit = true;
                        Console.WriteLine(" ");
                        Console.WriteLine("You have been revived");
                        Console.WriteLine(" ");
                        break;
                    case "n":
                    case "exit":
                        exit = true;
                        Console.Clear();
                        break;
                }
                if (exit == true) { break; };
            } while (exit == false);
        }

    }
}