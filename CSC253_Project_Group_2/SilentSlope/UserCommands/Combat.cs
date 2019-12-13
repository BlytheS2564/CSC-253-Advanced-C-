using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Combat
    {
        public static List<List<IRoom>> PlayerCombat(List<List<IRoom>> inRoomList, Room roomObject)
        {
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
            Mob mob = new Mob();

            List<string> defaultList = new List<string>();

            foreach (var item in roomObject.RoomContents)
            {
                if (item is Mob item1)
                {
                    mob = item1;
                }
            }

            bool isDead = false;
            int input = 0;

            Console.WriteLine($"You encountered a {mob.Name} with {mob.Health} health.");
            Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Run");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please choose 1 or 2");
                    Console.WriteLine(" ");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Run");
                }

                if (input == 1)
                {
                    Random rand = RandomGenerator.GenerateRandom();
                    Console.WriteLine("");
                    Console.WriteLine($"You stare eachother down and after a brief pause..");
                    Console.WriteLine("");
                    Console.WriteLine($"You take a swing at the {mob.Name}");
                    Console.ReadLine();
                    Random rand2 = RandomGenerator.GenerateRandom();

                    do
                    {
                        for (int i = 0; mob.Health > 0 || player.Health > 0; i++)
                        {

                            int attackChance = RandomGenerator.AttackChance(rand);
                            int attackChance2 = RandomGenerator.AttackChance(rand);

                            if (attackChance == 1)
                            {
                                if (player.Health <= 0)
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"The player has died.");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    { isDead = true; }
                                    break;
                                }
                                Console.WriteLine("");
                                Console.WriteLine($"You missed.");
                                if (attackChance2 == 1)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine($"The {mob.Name} swings back.");
                                    Console.WriteLine($"The {mob.Name} missed.");
                                    Console.WriteLine($"Player Health: {player.Health}");
                                    Console.WriteLine($"{mob.Name} Health: {mob.Health}");
                                }
                                else if (attackChance2 == 2)
                                {

                                    Console.WriteLine("");
                                    Console.WriteLine($"The {mob.Name} swings back.");

                                    if (player.Armor > 0)
                                    {
                                        int attack = mob.Attack;
                                        attack -= player.Armor;
                                        player.Health -= attack;
                                        Console.WriteLine($"Your armor absorbed {player.Armor} damage.");
                                        Console.WriteLine($"The {mob.Name} hit you for {attack} points of damage.");
                                    }
                                    else
                                    {
                                        player.Health -= mob.Attack;
                                        Console.WriteLine($"The {mob.Name} hit you for {mob.Attack} points of damage.");
                                    }
                                    Console.WriteLine($"Player Health: {player.Health}");
                                    Console.WriteLine($"{mob.Name} Health: {mob.Health}");
                                }
                            }
                            else if (attackChance == 2)
                            {
                                mob.Health -= player.Attack;
                                Console.WriteLine("");
                                Console.WriteLine($"You hit the {mob.Name} for {player.Attack} points of damage.");
                                Console.WriteLine($"Player Health: {player.Health}");
                                Console.WriteLine($"{mob.Name} Health: {mob.Health}");
                                if (mob.Health <= 0)
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"The {mob.Name} has died.");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadLine();
                                    roomObject.RoomContents.Remove(mob);
                                    { isDead = true; }
                                    break;
                                }
                                if (attackChance2 == 1)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine($"The {mob.Name} swings back.");
                                    Console.WriteLine($"The {mob.Name} missed.");
                                    Console.WriteLine($"Player Health: {player.Health}");
                                    Console.WriteLine($"{mob.Name} Health: {mob.Health}");
                                }
                                else if (attackChance2 == 2)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine($"The {mob.Name} swings back.");

                                    if (player.Armor > 0)
                                    {
                                        int attack = mob.Attack;
                                        attack -= player.Armor;
                                        player.Health -= attack;
                                        Console.WriteLine($"Your armor absorbed {player.Armor} damage.");
                                        Console.WriteLine($"The {mob.Name} hit you for {attack} points of damage.");
                                    }
                                    else
                                    {
                                        player.Health -= mob.Attack;
                                        Console.WriteLine($"The {mob.Name} hit you for {mob.Attack} points of damage.");
                                    }
                                    Console.WriteLine($"Player Health: {player.Health}");
                                    Console.WriteLine($"{mob.Name} Health: {mob.Health}");
                                }
                            }
                        }
                    } while (isDead == false);
                    return inRoomList;
                }
                else if (input == 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You ran");
                    Console.ReadLine();
                    return inRoomList;
                }
                else
                {
                    Console.WriteLine("Please choose 1 or 2");
                    Console.WriteLine(" ");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Run");
                }
            } while (input != 1 || input != 2);
            return inRoomList;
        }
    }
}