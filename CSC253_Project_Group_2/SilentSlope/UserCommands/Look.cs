using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilentSlopeWinForm;

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
            List<string> checkItemList = new List<string>() { "bandaid", "rubber ball", "pencil", "tape", "picture",
                "child's drawing", "beef jerky", "energy drink"};
            List<string> checkMobList = new List<string>() { "contorted apparition", "tortured ghoul", "faceless horror",
                "vile skinwalker", "dryadic petrifier"};
            List<string> checkWeaponList = new List<string>() { "knife", "hammer", "wooden plank", "rusty spoon" };
            Player player = new Player();
            string name = "";
            int health = 0;
            int damage = 0;
            foreach (Player p in playerList)
            {
                player = p;
            }
            List<string> defaultList = new List<string>();
            switch (strObject)
            {
                case "room":
                    Console.WriteLine("");
                    Console.WriteLine("----------------");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Room information");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.WriteLine($"Current room: {roomObject.RoomName}");
                    Console.WriteLine($"Room description: {roomObject.RoomDescription}");
                    Console.WriteLine(" ");
                    if (roomObject.RoomContents != null)
                    {
                        foreach (var item in roomObject.RoomContents)
                        {
                            if (item is Mob item1)
                            {
                                Console.WriteLine("----------------");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Monsters in room");
                                Console.ResetColor();
                                Console.WriteLine(" ");
                                
                                Console.WriteLine($"Monster: {item1.Name}");
                                Console.WriteLine($"HP-{item1.Health}");
                                Console.WriteLine("");
                            }
                            if (item is Loot item2)
                            {
                                Console.WriteLine("----------------");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Loot in room");
                                Console.ResetColor();
                                Console.WriteLine(" ");

                                Console.WriteLine(item2.Name);
                                Console.WriteLine("");
                            }
                            if (item is Weapon item3)
                            {
                                Console.WriteLine("----------------");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Weapons in room");
                                Console.ResetColor();
                                Console.WriteLine(" ");

                                Console.WriteLine(item3.Name);
                            }
                        }
                    }
                    break;
                case "inventory":
                    Console.WriteLine("");
                    Console.WriteLine("----------------");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Player Inventory");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    foreach (IRoom item in player.Inventory)
                    {
                        if (item is Weapon weapon)
                        {
                            Console.WriteLine($"Weapon: {weapon.Name}");
                            Console.WriteLine($"Damage: {weapon.Damage}");
                            Console.WriteLine($"Description: {weapon.Description}");
                            Console.WriteLine(" ");
                        }
                    }
                    foreach (IRoom item in player.Inventory)
                    {
                        if (item is Loot loot)
                        {
                            if (loot.Heal != 0)
                            {
                                Console.WriteLine($"Potion: {loot.Name}");
                                Console.WriteLine($"Heal amount: {loot.Heal}");
                                Console.WriteLine($"Description: {loot.Description}");
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.WriteLine($"Loot: {loot.Name}");
                                Console.WriteLine($"Description: {loot.Description}");
                                Console.WriteLine(" ");
                            }
                        }
                    }
                    break;
                case "player":
                case "stats":
                    Console.WriteLine("----------------");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Player Stats");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine($"Name: {player.Name}");
                    Console.WriteLine($"Health: {player.Health}");
                    Console.WriteLine($"Armor: {player.Armor}");
                    Console.WriteLine($"Attack: {player.Attack}");
                    Console.WriteLine($"Crit: {player.Crit}");
                    Console.WriteLine($"Current Room: {player.CurrentRoom}");
                    Console.WriteLine("");
                    break;
                case "mobs":
                    foreach (Mob a in mobList)
                    {
                        Console.WriteLine("----------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("All mobs in game");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine($"Mob Name: {a.Name}");
                        Console.WriteLine($"Health: {a.Health}");
                    }
                    break;
                case "weapons":
                    foreach (Weapon a in weaponList)
                    {
                        Console.WriteLine("----------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("All weapons in game");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine($"Weapon Name: {a.Name}");
                        Console.WriteLine($"Description: {a.Description}");
                        Console.WriteLine($"Damage: {a.Damage}");
                    }
                    break;
                case "items":
                    foreach (Loot a in lootList)
                    {
                        Console.WriteLine("----------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("All loot in game");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine($"Item Name: {a.Name}");
                        Console.WriteLine($"Description: {a.Description}");
                        Console.WriteLine($"Heal: {a.Heal}");
                    }
                    break;

                default:
                    if (checkItemList.Contains(strObject)){ List<IRoom> iList = lootList; DetailedLook(iList, strObject); }
                    else if (checkMobList.Contains(strObject)) { List<IRoom> iList = mobList; DetailedLook(iList, strObject); }
                    else if (checkWeaponList.Contains(strObject)) { List<IRoom> iList = weaponList; DetailedLook(iList, strObject); }
                    else { AllObjects(strObject, player, roomObject, mobList, lootList, weaponList); }
                    break;
            }
        }
        public static int Attack(int health)
        {
            int newhealth = health - 10;
            return newhealth;
        }
        public static void DetailedLook(List<IRoom> iList, string strObject)
        {
            string name = "";
            string description = "";
            int health = 0;
            int damage = 0;
            int heal = 0;
            int attack = 0;

            foreach(IRoom item in iList)
            {
                if (item is Weapon weapon)
                {
                    if (weapon.Name.ToLower() == strObject)
                    {
                        name = weapon.Name;
                        description = weapon.Description;
                        damage = weapon.Damage;
                        SilentSlopeWinForm.Form1.DisplayWeapon(name, description, damage);
                    }
                }
                if (item is Loot loot)
                {
                    if( loot.Name.ToLower() == strObject)
                    {
                        name = loot.Name;
                        description = loot.Description;
                        heal = loot.Heal;
                        SilentSlopeWinForm.Form1.DisplayLoot(name, description, heal);
                    }
                }
                if (item is Mob mob)
                {
                    if( mob.Name.ToLower() == strObject)
                    {
                        name = mob.Name;
                        health = mob.Health;
                        attack = mob.Attack;
                        SilentSlopeWinForm.Form1.DisplayMob(name, health, attack);
                    }
                }

            }
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

