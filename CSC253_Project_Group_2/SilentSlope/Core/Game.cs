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
            CreateNewChar.CharacterDetails(player);
            Save.SavePlayer(player);
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
            inRoomList.Add(weaponList);
            inRoomList.Add(lootList);
            inRoomList.Add(mobList);
            inRoomList.Add(roomList);
            inRoomList.Add(playerList);
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

            playerList = Load.Player(playerList);
            roomList = Load.Rooms(roomList);
            mobList = Load.Mobs(mobList);
            weaponList = Load.Weapons(weaponList);
            lootList = Load.Loots(lootList);
            itemList = AddItemsToList(weaponList, lootList, itemList);
            inRoomList = AddtoRoomList(weaponList, lootList, mobList, inRoomList, roomList, playerList);
            roomList = CreateRandomMob.RandomCreate(inRoomList);
            inRoomList = AddtoRoomList(weaponList, lootList, mobList, inRoomList, roomList, playerList);
            Save.SaveWorld(roomList);

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

                switch (input)
                {
                    case "save":
                        Save.SavePlayer(player);
                        Save.SaveWorld(roomList);
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
