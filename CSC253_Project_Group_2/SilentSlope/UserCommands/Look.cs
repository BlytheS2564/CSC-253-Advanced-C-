using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Look
    {
        public static void LookupObjects(string strObject, Room roomObject, List<List<IRoom>> inRoomList)
        {
            /**
             * looks for the str object ( verb subject object type object) to see what the look action should look for
             */
            List<IRoom> weaponList = inRoomList[0];
            List<IRoom> lootList = inRoomList[1];
            List<IRoom> mobList = inRoomList[2];
            List<IRoom> playerList = inRoomList[4];
            Player player = new Player();
            foreach (Player p in playerList)
            {
                player = p;
            }
            List<string> defaultList = new List<string>();
            switch (strObject)
            {
                case "room":
                    Console.WriteLine("");
                    Console.WriteLine(roomObject.RoomID);
                    Console.WriteLine(roomObject.RoomName);
                    Console.WriteLine(roomObject.RoomDescription);
                    if (roomObject.RoomContents != null)
                    {
                        foreach (var item in roomObject.RoomContents)
                        {
                            if (item is Mob item1)
                            {
                                Console.WriteLine("----------------");
                                Console.WriteLine("Monsters in room");
                                Console.WriteLine($"Monster: {item1.Name}");
                                Console.WriteLine($"HP-{item1.Health}");
                                Console.WriteLine($"Room location: Room {item1.CurrentRoom}");
                                Console.WriteLine("");
                            }
                            if (item is Loot item2)
                            {
                                Console.WriteLine("----------------");
                                Console.WriteLine("loot in room");
                                Console.WriteLine(item2.Name);
                                Console.WriteLine("");
                            }
                            if (item is Weapon item3)
                            {
                                Console.WriteLine("----------------");
                                Console.WriteLine("weapons in room");
                                Console.WriteLine(item3.Name);
                            }
                        }
                    }
                    break;
                case "attack":
                    if (roomObject.RoomContents != null)
                    {
                        foreach (var item in roomObject.RoomContents)
                        {
                            if (item is Mob item1)
                            {
                                Console.WriteLine(item1.Name);
                                Console.WriteLine(item1.CurrentRoom);
                                item1.Health = Attack(item1.Health);
                                Console.WriteLine($"Attacking {item1.Name} with 10 damage");
                                Console.WriteLine($"Monsters new health is HP-{item1.Health}");
                            }
                        }
                    }
                    break;
                case "inventory":
                    Console.WriteLine("");
                    Console.WriteLine(player.Inventory);
                    break;
                case "player":
                case "stats":
                    Console.WriteLine("");
                    Console.WriteLine(player.Name);
                    Console.WriteLine(player.Health);
                    Console.WriteLine(player.Armor);
                    break;
                case "mobs":
                    foreach (Mob a in mobList)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(a.Name);
                        Console.WriteLine(a.Health);
                    }
                    break;
                case "weapons":
                    foreach (Weapon a in weaponList)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(a.Name);
                        Console.WriteLine(a.Description);
                        Console.WriteLine(a.Damage);
                    }
                    break;
                case "items":
                    foreach (Loot a in lootList)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(a.Name);
                        Console.WriteLine(a.Description);
                        Console.WriteLine(a.Heal);
                    }
                    break;

                default:
                    AllObjects(strObject, player, roomObject, mobList, lootList, weaponList);
                    break;
            }
        }
        public static int Attack(int health)
        {
            int newhealth = health - 10;
            return newhealth;
        }
        public static void AllObjects(string strObject, Player player, Room roomObject,
            List<IRoom> mobList, List<IRoom> lootList, List<IRoom> weaponList)
        {
            /**
             * If it didnt fit in the above, they were looking for a specific object.
             * this for each loop looks through each of the 3 lists of objects to find
             * the object name that matches the user's input stored in strObject.
             */
            foreach (Mob a in mobList)
            {
                if (a.Name.ToLower() == strObject) { Console.WriteLine(a); }
            }
            foreach (Weapon a in weaponList)
            {
                if (a.Name.ToLower() == strObject) { Console.WriteLine(a); }
            }
            foreach (Loot a in lootList)
            {
                if (a.Name.ToLower() == strObject) { Console.WriteLine(a); }
            }
        }
    }
}

