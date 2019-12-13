using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Game
    {
        const int ROWS = 2;
        const int COLS = 2;
        enum RoomIDs
        {
            Bedroom = 0,
            Kitchen = 1,
            Attic = 2,
            Basement = 3,
            Backyard = 4
        }
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
        enum Relic
        {
            Red = 1,
            Blue = 2,
            Yellow = 3
        }
        public static void CreateNewCharacter()
        {
            Player player = new Player();
            List<List<IRoom>> inRoomList = new List<List<IRoom>>();
            player = CreateNewChar.CharacterDetails(player);
            inRoomList = Loading(player);
            Save.SavePlayer(inRoomList);
        }
        public static List<List<IRoom>> AddItemsToList(List<IRoom> weaponList, List<IRoom> lootList,
            List<List<IRoom>> itemList)
        {
            itemList.Add(weaponList);
            itemList.Add(lootList);
            return itemList;
        }
        public static List<List<IRoom>> AddtoRoomList(List<IRoom> weaponList, List<IRoom> lootList,
            List<IRoom> mobList, List<List<IRoom>> inRoomList, List<IRoom> roomList, List<IRoom> playerList)
        {
            List<List<IRoom>> inRoomList2 = new List<List<IRoom>>();
            inRoomList2.Add(weaponList);
            inRoomList2.Add(lootList);
            inRoomList2.Add(mobList);
            inRoomList2.Add(roomList);
            inRoomList2.Add(playerList);
            inRoomList = inRoomList2;
            return inRoomList;
        }
        public static List<List<IRoom>> Loading(Player player)
        {
            List<IRoom> playerList = new List<IRoom>();
            List<IRoom> roomList = new List<IRoom>();
            List<IRoom> mobList = new List<IRoom>();
            List<IRoom> weaponList = new List<IRoom>();
            List<IRoom> lootList = new List<IRoom>();
            List<List<IRoom>> inRoomList = new List<List<IRoom>>();
            List<List<IRoom>> itemList = new List<List<IRoom>>();
            List<List<string>> loadLists = new List<List<string>>();

            playerList.Add(player);
            roomList = Load.Rooms(roomList);
            mobList = Load.Mobs(mobList);
            weaponList = Load.Weapons(weaponList);
            lootList = Load.Loots(lootList);
            itemList = AddItemsToList(weaponList, lootList, itemList);
            inRoomList = AddtoRoomList(weaponList, lootList, mobList, inRoomList, roomList, playerList);
            inRoomList = CreateRandomMob.RandomCreate(inRoomList);
            Save.SaveWorld(inRoomList);
            return inRoomList;
        }
        public static void SilentSlope()
        {

            //object player, List<object> roomList, List<List<string>> loadLists
            
            List<IRoom> playerList = new List<IRoom>();
            List<IRoom> roomList = new List<IRoom>();
            List<IRoom> mobList = new List<IRoom>();
            List<IRoom> weaponList = new List<IRoom>();
            List<IRoom> lootList = new List<IRoom>();
            List<List<IRoom>> inRoomList = new List<List<IRoom>>();
            List<List<IRoom>> itemList = new List<List<IRoom>>();
            List<List<string>> loadLists = new List<List<string>>();

            roomList = Load.Rooms(roomList);
            mobList = Load.Mobs(mobList);
            weaponList = Load.Weapons(weaponList);
            lootList = Load.Loots(lootList);
            itemList = AddItemsToList(weaponList, lootList, itemList);
            inRoomList = AddtoRoomList(weaponList, lootList, mobList, inRoomList, roomList, playerList);
            inRoomList = Load.Player(inRoomList);
            playerList = inRoomList[4];
            int test = playerList.Count;
            Console.WriteLine(test);
            if (playerList.Count == 0)
            {
                Console.WriteLine("works");
            }
            else
            {
                inRoomList = CreateRandomMob.RandomCreate(inRoomList);
                Save.SaveWorld(inRoomList);

                //initializes the game. sets bool variables below
                bool exit2 = false;
                bool roomCheck = false;

                //creates the 2D array assigning an int number to each coordinate.
                int[,] movement = { { 1, 2, 3 },
                                { 4, 5, 6 },
                                { 7, 8, 9 } };

                //sets row and col for room starting position
                int row = 2;
                int col = 1;
                string roomName = "Bedroom";

                //intro message
                Console.WriteLine("You wake up in a dark room..");
                Console.ReadLine();
                Console.WriteLine("This room feels unfamiliar..");
                Console.ReadLine();
                Console.WriteLine("You hear a low growl permeating the darkness..");
                Console.ReadLine();
                Console.WriteLine("You stumble about looking for a way out of the house.");
                Console.ReadLine();
                Console.WriteLine($"You are currently in the {roomName}. You see a door to the north.");

                //do while loop to contain running program

                int roomID = GameUtilities.RoomIDsEnum(roomName);
                int count2 = 0;
                Room roomObject = new Room();
                foreach (Room Item in roomList)
                {
                    if (Item.RoomID == roomID)
                    {
                        roomObject = Item;
                    }

                }
                List<int> coordinates = new List<int>();

                do
                {
                    
                    Console.ReadLine();
                    Console.Write("Which direction would you like to move?: ");
                    string input = Console.ReadLine().ToLower();

                    inRoomList = InputSplit.Split(input, roomObject,
                        row, col, roomName, inRoomList);
                    Player player = new Player();
                    foreach (Player p in playerList)
                    {
                        player = p;
                    }
                    if (player.CurrentRoom == 2)
                    {
                        if (player.Inventory.Count != 0)
                        {
                            foreach (IRoom items in player.Inventory)
                            {
                                if (items is Loot item3)
                                {
                                    if (item3.Name == "Picture")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("The vile skinwalker recognizes the picture of a boy..");
                                        Console.ReadLine();
                                        Console.WriteLine("The boy it used to before the change..");
                                        Console.ReadLine();
                                        Console.WriteLine("The skinwalker fades into a mist");
                                        Console.ReadLine();
                                        Console.WriteLine("");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("YOU HAVE ESCAPED!");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                        exit2 = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The vile skinwalker pounces on you.. killing you instantly");
                                        player.Health = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The vile skinwalker pounces on you.. killing you instantly");
                            Console.ResetColor();
                            Console.ReadLine();
                            player.Health = 0;
                        }
                        
                    }
                    if (player.Health <= 0)
                    {
                        GameUtilities.GameOverMenu(player);
                        if (player.Health <= 0)
                        {
                            exit2 = true;
                            break;
                        }
                    }
                    
                    int newRoom = player.CurrentRoom;
                    coordinates = GameUtilities.RoomCheck(newRoom, row, col);
                    row = coordinates[0];
                    col = coordinates[1];
                    roomObject = GameUtilities.newRoomObject(newRoom, roomList);
                    player.CurrentRoom = roomObject.RoomID;
                    inRoomList = Game.AddtoRoomList(weaponList, lootList, mobList, inRoomList, roomList, playerList);
                    switch (input)
                    {
                        case "save":
                            Save.SavePlayer(inRoomList);
                            Save.SaveWorld(inRoomList);
                            break;
                        case "help":
                            GameUtilities.Help();
                            break;
                        case "map":
                            GameUtilities.Map(roomList);
                            break;
                        case "4":
                        case "exit":
                            exit2 = true;
                            break;
                    }
                    if (exit2 == true) { break; };

                } while (exit2 == false);
            }
        }
    }
}
