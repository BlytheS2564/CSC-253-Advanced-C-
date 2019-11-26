using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class GameEvents
    {
        public static List<IRoom> MobMovementChance(List<IRoom> roomList)
        {
            Random rand = new Random();
            roomList = MobMovement(roomList, rand);
            return roomList;
        }
        public static List<IRoom> MobMovement(List<IRoom> roomList, Random rand)
        {
            int index = 0;
            int roomIndex = 0;
            bool skip = false;
            Mob tempMob = new Mob();
            Room tempRoom = new Room();
            List<IRoom> roomContents = new List<IRoom>();
            List<IRoom> newRoomContents = new List<IRoom>();
            List<IRoom> newRoomList = new List<IRoom>();
            List<IRoom> tempRoomList = new List<IRoom>();
            newRoomList = roomList;

            
            for (int i = 0; i < roomList.Count; i++)
            {
                IRoom room = roomList[i];
                if (room is Room roomObject)
                {
                    if (roomObject.RoomContents != null)
                    {
                        for (int c = 0; c < roomObject.RoomContents.Count; c++)
                        {
                            IRoom item = roomObject.RoomContents[c];

                            if (item is Mob item1)
                            {
                                int ranNumber = RandomNumber(rand);
                                if (ranNumber <= 20)
                                {
                                    switch (item1.CurrentRoom)
                                    {
                                        case 8:
                                            item1.CurrentRoom = 5;
                                            tempMob = item1;
                                            roomObject.RoomContents.RemoveAt(c);
                                            if (roomList[1] is Room newRoom0)
                                            {
                                                newRoom0.RoomContents.Add(tempMob);
                                                Console.WriteLine($"{item1.Name} has moved to the {newRoom0.RoomName}!");
                                            }
                                            
                                            break;
                                        case 5:
                                            int num = RandomRoom(rand);
                                            item1.CurrentRoom = num;
                                            tempMob = item1;
                                            roomObject.RoomContents.RemoveAt(c);
                                            if (num == 8)
                                            {
                                                if (roomList[0] is Room newRoom1)
                                                {
                                                    newRoom1.RoomContents.Add(tempMob);
                                                    Console.WriteLine($"{item1.Name} has moved to the {newRoom1.RoomName}!");
                                                }
                                            }
                                            if (num == 4)
                                            {
                                                if (roomList[2] is Room newRoom1)
                                                {
                                                    newRoom1.RoomContents.Add(tempMob);
                                                    Console.WriteLine($"{item1.Name} has moved to the {newRoom1.RoomName}!");
                                                }
                                            }
                                            if (num == 6)
                                            {
                                                if (roomList[3] is Room newRoom1)
                                                {
                                                    newRoom1.RoomContents.Add(tempMob);
                                                    Console.WriteLine($"{item1.Name} has moved to the {newRoom1.RoomName}!");
                                                }
                                            }
                                            if (num == 2)
                                            {
                                                if (roomList[4] is Room newRoom1)
                                                {
                                                    newRoom1.RoomContents.Add(tempMob);
                                                    Console.WriteLine($"{item1.Name} has moved to the {newRoom1.RoomName}!");
                                                }
                                            }
                                            break;
                                        case 4:
                                            item1.CurrentRoom = 5;
                                            roomObject.RoomContents.RemoveAt(c);
                                            tempMob = item1;
                                            if (roomList[1] is Room newRoom2)
                                            {
                                                newRoom2.RoomContents.Add(tempMob);
                                                Console.WriteLine($"{item1.Name} has moved to the {newRoom2.RoomName}!");
                                            }
                                            break;
                                        case 6:
                                            item1.CurrentRoom = 5;
                                            roomObject.RoomContents.RemoveAt(c);
                                            tempMob = item1;
                                            if (roomList[1] is Room newRoom3)
                                            {
                                                newRoom3.RoomContents.Add(tempMob);
                                                Console.WriteLine($"{item1.Name} has moved to the {newRoom3.RoomName}!");
                                            }
                                            break;
                                        case 2:
                                            item1.CurrentRoom = 5;
                                            roomObject.RoomContents.RemoveAt(c);
                                            tempMob = item1;
                                            if (roomList[1] is Room newRoom4)
                                            {
                                                newRoom4.RoomContents.Add(tempMob);
                                                Console.WriteLine($"{item1.Name} has moved to the {newRoom4.RoomName}!");
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return roomList;
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
                                
                                Console.WriteLine($"-------test--------");
                                Console.WriteLine($"{roomObject.RoomName}");
                                Console.WriteLine($"{item1.Name}");
                                Console.WriteLine($"{item1.CurrentRoom}");
                                Console.WriteLine($"-------test--------");
                            }
                        }
                    }
                }
            }
        }
        public static int RandomNumber(Random rand)
        {
            int ranNumber;
            ranNumber = rand.Next(100) + 1;
            return ranNumber;
        }
        public static int RandomRoom(Random rand)
        {
            int ranNumber;
            var roomlist = new List<int> { 2, 4, 6, 8 };
            int index = rand.Next(roomlist.Count);
            ranNumber = roomlist[index];
            return ranNumber;
        }
        
    }
}
