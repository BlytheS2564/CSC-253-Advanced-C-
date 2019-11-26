using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Move
    {
        const int ROWS = 2;
        const int COLS = 2;

        enum RoomIDs
        {
            Bedroom = 0,
            Kitchen = 1,
            Attic = 2,
            Basement = 3,
            Backyard = 4,
        }
        public static List<List<IRoom>> Direction(string strVerb, int row, int col, string roomName,
             List<List<IRoom>> inRoomList)
        {
            // changes the rows and columns to allow new coordinates. sends to Movement right below.
            List<IRoom> weaponList = inRoomList[0];
            List<IRoom> lootList = inRoomList[1];
            List<IRoom> mobList = inRoomList[2];
            List<IRoom> roomList = inRoomList[3];
            List<IRoom> playerList = inRoomList[4];
            Player player = new Player();
            foreach (Player p in playerList)
            {
                player = p;
            }
            var reset = new Tuple<int, int>(row, col);
            var MovementVariables = new Tuple<int, int, Player>(row, col, player);
            roomList = GameEvents.MobMovementChance(roomList);
            switch (strVerb)
            {
                case "north":
                case "n":
                    row--;
                    Console.WriteLine(" ");
                    player = Movement(row, col, roomName, roomList, reset, player);
                    Console.WriteLine("You move north");
                    break;
                case "south":
                case "s":
                    row++;
                    Console.WriteLine(" ");
                    Console.WriteLine("You move south");
                    player = Movement(row, col, roomName, roomList, reset, player);
                    break;
                case "east":
                case "e":
                    col++;
                    Console.WriteLine(" ");
                    Console.WriteLine("You move east");
                    player = Movement(row, col, roomName, roomList, reset, player);
                    break;
                case "west":
                case "w":
                    col--;
                    Console.WriteLine(" ");
                    Console.WriteLine("You move west");
                    player = Movement(row, col, roomName, roomList, reset, player);
                    break;

                default:
                    Console.WriteLine("Not a command");
                    break;
            }
            List<IRoom> newPlayerList = new List<IRoom>();
            newPlayerList.Add(player);
            inRoomList = Game.AddtoRoomList(weaponList, lootList, mobList, inRoomList, roomList, playerList);
            return inRoomList;

        }
        public static void Test(List<IRoom> roomList)
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
                                Console.WriteLine("New locations");
                                Console.WriteLine(item1.Name);
                                Console.WriteLine(item1.CurrentRoom);
                            }
                        }
                    }
                }
            }
        }

        public static bool PositionCheck(int row, int col, Tuple<int, int> reset)
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
        public static string RoomCheck(int newRoom, List<IRoom> roomList)
        {
            /**Takes the room number which corresponds to the 2D array (ie: coordinate 0,0 = room 1)
             * and matches it with the proper object stored in the object list to get the roomname
             */

            foreach (Room Item in roomList)
            {
                if (newRoom == Item.RoomID)
                {
                    Console.WriteLine(Item.RoomName);
                    return Item.RoomName;
                }
            }
            string roomName = "Not a room";
            return roomName;

            
        }

        /** Input is taken, turned to lower case to always match what I want. It's then compared to the switch cases.
             *  I used a technique called switch stacking to allow various inputs to work for one path. After input
             *  a corresponding case is activated and met with a message of the direction you are moving. Depending
             *  on the direction, 1 is either added or taken away from a row or column in the coordinate. This new
             *  coordinate is then sent to PositionCheck() to determine if it is within the range of the array.
             *  If the check passed, the variable roomCheck will be true allowing the new room coordinates to be
             *  located revealing the room number. The room number is then sent to RoomCheck() to locate the 
             *  room name from the Room array. If the room name doesnt exist, "Not a room" is returned which
             *  triggers an error message and a roll back on the col or row variable that was previously altered.
             *  This essentially returns you back to the room in which you were before the illegal movement. If
             *  successful, You are greated with a message telling you the name of the new room you are in.
             *  This is repeated for each direction. Additionally you have help and exit input cases.
             */
        public static Player Movement(int row, int col, string roomName,
            List<IRoom> roomList, Tuple<int, int> reset, Player player)
        {

            bool roomCheck = false;
            int[,] roomArray = { { 1, 2, 3 },
                                { 4, 5, 6 },
                                { 7, 8, 9 } };

            roomCheck = PositionCheck(row, col, reset);
            if (roomCheck == true)
            {
                int newRoom = roomArray[row, col];
                roomName = RoomCheck(newRoom, roomList);

                player.CurrentRoom = newRoom;
                if (roomName == "Not a room")
                {
                    row = reset.Item1;
                    col = reset.Item2;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot move in that direction");
                    Console.ResetColor();
                    Console.WriteLine("");
                    newRoom = roomArray[row, col];
                    roomName = RoomCheck(newRoom, roomList);
                    player.CurrentRoom = newRoom;
                    Console.WriteLine($"You are now in the {roomName}");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"You are now in the {roomName}");
                }
            }

            roomCheck = false;
            return player;
        }
    }
}
