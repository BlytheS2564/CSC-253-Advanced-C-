using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Use
    {
        public static List<List<IRoom>> UseWhat(string strObject, Room roomObject, List<List<IRoom>> inRoomList)
        {
            List<IRoom> playerList = new List<IRoom>();
            List<IRoom> roomContentsList = new List<IRoom>();
            playerList = inRoomList[4];
            IRoom tempPlayer = playerList[0];

            if (tempPlayer is Player player)
            {
                if (player.Inventory.Count != 0)
                {
                    for (int i = 0; i < player.Inventory.Count; i++)
                    {
                        IRoom content = player.Inventory[i];
                        if (content is Loot loot)
                        {
                            if (loot.Name.ToLower() == strObject)
                            {
                                int used = Item(player, loot);
                                if (used == 1)
                                {
                                    player.Inventory.RemoveAt(i);
                                }
                            }
                        }
                        else if (content is Weapon weapon)
                        {
                            if (weapon.Name.ToLower() == strObject)
                            {
                                Weapon(player, weapon);
                            }
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cannot use that item");
                            Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                    }

                }
                else
                {
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No items in inventory");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                }
                
            }
            return inRoomList;
        }
        public static int Item(Player player, Loot loot)
        {
            int used = 1;
            if (loot.Heal != 0)
            {
                if ((player.Zodiac == "Aries") || (player.Zodiac == "Cancer") || (player.Zodiac == "Virgo") || (player.Zodiac == "Sagittarius"))
                {
                    if (player.Health < 120)
                    {
                        player.Health += loot.Heal;

                        if (player.Health > 120)
                        {
                            int healthBalance = player.Health - 120;
                            int newHeal = loot.Heal - healthBalance;
                            Console.WriteLine($"You have healed for {newHeal} health ({healthBalance} overhealed)");
                            player.Health = 120;
                        }
                        else
                        {
                            Console.WriteLine($"You have healed for {loot.Heal} health");
                        }
                        Console.WriteLine($"Current health is {player.Health}");
                        return used;
                    }
                    else
                    {
                        Console.WriteLine($"Health is already at max");
                        used = 0;
                        return used;
                    }
                }
                else
                {
                    if (player.Health < 100)
                    {
                        player.Health += loot.Heal;

                        if (player.Health > 100)
                        {
                            int healthBalance = player.Health - 100;
                            int newHeal = loot.Heal - healthBalance;
                            Console.WriteLine($"You have healed for {newHeal} health ({healthBalance} overhealed)");
                            player.Health = 100;
                        }
                        else
                        {
                            Console.WriteLine($"You have healed for {loot.Heal} health");
                        }
                        Console.WriteLine($"Current health is {player.Health}");
                        return used;
                    }
                    else
                    {
                        Console.WriteLine($"Health is already at max");
                        used = 0;
                        return used;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Cannot use that item");
                used = 0;
                return used;
            }

        }
        public static void Weapon(Player player, Weapon weapon)
        {
            if (weapon.Damage != 0)
            {
                if ((player.Zodiac == "Pisces") || (player.Zodiac == "Gemini") || (player.Zodiac == "Libra") || (player.Zodiac == "Scorpio"))
                {
                    player.Attack = 15;
                }
                else
                {
                    player.Attack = 10;
                }
                player.Attack += weapon.Damage;
                Console.WriteLine($"You have equiped {weapon.Name} with {weapon.Damage} damage");
                Console.WriteLine($"New player damage is {player.Attack}");
            }
            else
            {
                Console.WriteLine("Cannot use that weapon");
            }
        }
    }
}
