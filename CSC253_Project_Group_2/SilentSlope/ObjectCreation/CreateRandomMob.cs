using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class CreateRandomMob
    {
        public static List<IRoom> RandomCreate(List<List<IRoom>> inRoomList)
        {
            int count = 0;
            List<IRoom> newRoomList = new List<IRoom>();
            List<IRoom> weaponList = inRoomList[0];
            List<IRoom> lootList = inRoomList[1];
            List<IRoom> mobList = inRoomList[2];
            List<IRoom> roomList = inRoomList[3];
            Random rand = new Random();
            Console.WriteLine("----Spawning loot and mobs----");
            Console.WriteLine(" ");
            foreach (Room room in roomList)
            {
                Console.WriteLine(room.RoomName);
                Console.WriteLine("-------------");
                Room populatedRoom = RandomSpawn(room, inRoomList, rand);
                newRoomList.Add(populatedRoom);
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
            
            return newRoomList;
        }
        public static Room RandomSpawn(Room room, List<List<IRoom>> inRoomList, Random rand)
        {
            int ranNumber = 0;
            ranNumber = RandomNumber(rand);
            if (ranNumber >= 50)
            {
                room = RandomMob(rand, room, inRoomList);
            }
            ranNumber = RandomNumber(rand);
            if (ranNumber >= 50)
            {
                room = RandomItem(rand, room, inRoomList);
            }
            ranNumber = RandomNumber(rand);
            if (ranNumber >= 50)
            {
                room = RandomWeapon(rand, room, inRoomList);
            }
            return room;
        }
        public static Room RandomMob(Random rand, Room room, List<List<IRoom>> inRoomList)
        {

            int ranNumber;
            int count = 0;
            ranNumber = rand.Next(3);
            List<IRoom> mobList = inRoomList[2];
            List<IRoom> RoomContents = new List<IRoom>();
            foreach (Mob mob in mobList)
            {
                if (ranNumber == count)
                {
                    Console.WriteLine(mob.Name);
                    Mob newMob = mob.DeepCopy(mob.Name,mob.Health,mob.Attack,mob.Armor,room.RoomID,mob.Drop);
                    if (room.RoomContents is null)
                    {
                        RoomContents.Add(newMob);
                    }
                    else
                    {
                        RoomContents = ReplaceContents(room);
                        RoomContents.Add(newMob);
                    }
                    room.RoomContents = RoomContents;
                    return room;
                }
                count++;
            }
            return room;
        }
        public static Room RandomItem(Random rand, Room room, List<List<IRoom>> inRoomList)
        {
            int ranNumber;
            int count = 0;
            ranNumber = rand.Next(7);
            List<IRoom> lootList = inRoomList[1];
            List<IRoom> RoomContents = new List<IRoom>();
            foreach (Loot loot in lootList)
            {
                if (ranNumber == count)
                {
                    Console.WriteLine(loot.Name);
                    if (room.RoomContents is null)
                    {
                        RoomContents.Add(loot);
                    }
                    else
                    {
                        RoomContents = ReplaceContents(room);
                        RoomContents.Add(loot);
                    }
                    room.RoomContents = RoomContents;
                    return room;
                }
                count++;
            }
            return room;
        }
        public static Room RandomWeapon(Random rand, Room room, List<List<IRoom>> inRoomList)
        {
            int ranNumber;
            int count = 0;
            ranNumber = rand.Next(3);
            List<IRoom> weaponList = inRoomList[0];
            List<IRoom> RoomContents = new List<IRoom>();
            foreach (Weapon weapon in weaponList)
            {
                if (ranNumber == count)
                {
                    Console.WriteLine(weapon.Name);
                    if (room.RoomContents is null)
                    {
                        RoomContents.Add(weapon);
                    }
                    else
                    {
                        RoomContents = ReplaceContents(room);
                        RoomContents.Add(weapon);
                    }
                    room.RoomContents = RoomContents;
                    return room;
                }
                count++;
            }
            return room;
        }
        public static int RandomNumber(Random rand)
        {
            int ranNumber;
            ranNumber = rand.Next(100) + 1;
            return ranNumber;
        }
        public static List<IRoom> ReplaceContents(Room room)
        {
            List<IRoom> RoomContents = new List<IRoom>();
            foreach (var item in room.RoomContents)
            {
                RoomContents.Add(item);
            }
            return RoomContents;
        }
        public static Room ReplaceContents(Room populatedRoom, Mob newMob)
        {
            List<IRoom> RoomContents = new List<IRoom>();
            foreach (var item in populatedRoom.RoomContents)
            {
                RoomContents.Add(item);
            }
            populatedRoom.RoomContents = RoomContents;
            return populatedRoom;
        }

    }
}
