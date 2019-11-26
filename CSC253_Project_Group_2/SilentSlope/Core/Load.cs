using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Load
    {
        public static List<IRoom> Player(List<IRoom> playerList)
        {
            /**
             * Requests the users name and password in order to locate and verify the user via the Player.txt file.
             */
            Player player = new Player();
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Please enter player name: ");
            Console.ResetColor();
            string tempName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Please enter password: ");
            Console.ResetColor();
            string tempPass = Console.ReadLine();

            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("Player.txt");
                Console.WriteLine("");
                while (!inputFile.EndOfStream)
                {
                    player = new Player();
                    player.Name = inputFile.ReadLine();
                    player.Password = inputFile.ReadLine();
                    player.Health = int.Parse(inputFile.ReadLine());
                    player.Attack = int.Parse(inputFile.ReadLine());
                    player.Armor = int.Parse(inputFile.ReadLine());
                    player.Crit = int.Parse(inputFile.ReadLine());
                    player.Zodiac = inputFile.ReadLine();
                    player.Relic = inputFile.ReadLine();
                    player.CurrentRoom = int.Parse(inputFile.ReadLine());
                    playerList.Add(player);
                }

                inputFile.Close();

                // password authentication

                if (tempName == player.Name && tempPass == player.Password)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Player found!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ReadLine();
                    return playerList;
                }
                else
                {
                    player = new Player();
                    player.Name = "";
                    player.Password = "";
                    player.Health = 100;
                    player.Attack = 10;
                    player.Armor = 0;
                    player.Crit = 0;
                    player.Zodiac = "";
                    player.Relic = "";
                    player.CurrentRoom = 8;
                    playerList.Add(player);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player name / Password did not match.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ReadLine();
                    GameUtilities.GameMenu();
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player not found!");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            return playerList;
        }
        public static List<IRoom> Rooms(List<IRoom> roomList)
        {
            // loads the room objects from Rooms.txt
            int count = 0;

            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("Rooms.txt");
                Console.WriteLine("");
                while (!inputFile.EndOfStream)
                {
                    Room room = new Room();
                    room.RoomID = int.Parse(inputFile.ReadLine());
                    room.RoomName = inputFile.ReadLine();
                    room.RoomDescription = inputFile.ReadLine();
                    count++;
                    roomList.Add(room);
                }

                inputFile.Close();
                return roomList;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }


            foreach (Room a in roomList)
            {
                Console.WriteLine(a);
            }


            return roomList;
        }
        public static List<IRoom> Mobs(List<IRoom> mobList)
        {
            // loads the mob objects from Mobs.txt
            int count = 0;

            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("Mobs.txt");
                Console.WriteLine("");
                while (!inputFile.EndOfStream)
                {
                    Mob mob = new Mob();
                    mob.ID = int.Parse(inputFile.ReadLine());
                    mob.Name = inputFile.ReadLine();
                    mob.Health = int.Parse(inputFile.ReadLine());
                    mob.Attack = int.Parse(inputFile.ReadLine());
                    mob.Armor = int.Parse(inputFile.ReadLine());
                    mob.Drop = int.Parse(inputFile.ReadLine());
                    count++;
                    mobList.Add(mob);
                }

                inputFile.Close();
                return mobList;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }


            foreach (Mob a in mobList)
            {
                Console.WriteLine(a);
            }


            return mobList;
        }
        public static List<IRoom> Weapons(List<IRoom> weaponList)
        {
            // loads the weapon objects from the Weapons.txt file
            int count = 0;

            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("Weapons.txt");
                Console.WriteLine("");
                while (!inputFile.EndOfStream)
                {
                    Weapon weapon = new Weapon();
                    weapon.ID = int.Parse(inputFile.ReadLine());
                    weapon.Name = inputFile.ReadLine();
                    weapon.Description = inputFile.ReadLine();
                    weapon.Damage = int.Parse(inputFile.ReadLine());
                    count++;
                    weaponList.Add(weapon);
                }

                inputFile.Close();
                return weaponList;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }


            foreach (Weapon a in weaponList)
            {
                Console.WriteLine(a);
            }


            return weaponList;
        }
        public static List<IRoom> Loots(List<IRoom> lootList)
        {
            //loads item objects from Items.txt file
            int count = 0;

            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("Items.txt");
                Console.WriteLine("");
                while (!inputFile.EndOfStream)
                {
                    Loot item = new Loot();
                    item.ID = int.Parse(inputFile.ReadLine());
                    item.Name = inputFile.ReadLine();
                    item.Description = inputFile.ReadLine();
                    item.Heal = int.Parse(inputFile.ReadLine());
                    count++;
                    lootList.Add(item);
                }

                inputFile.Close();
                return lootList;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }


            foreach (Item a in lootList)
            {
                Console.WriteLine(a);
            }


            return lootList;
        }
    }
}