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
        public static List<List<IRoom>> Player(List<List<IRoom>> inRoomList)
        {
            /**
             * Requests the users name and password in order to locate and verify the user via the Player.txt file.
             */
            List<IRoom> weaponList = inRoomList[0];
            List<IRoom> lootList = inRoomList[1];
            List<IRoom> mobList = inRoomList[2];
            List<IRoom> roomList = inRoomList[3];
            List<IRoom> playerList = inRoomList[4];
            Player player = new Player();
            List<IRoom> Inventory = new List<IRoom>();
            List<IRoom> blankPlayerList = new List<IRoom>();

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
                    player.CurrentRoom = int.Parse(inputFile.ReadLine());
                    player.Crit = int.Parse(inputFile.ReadLine());
                    player.Zodiac = inputFile.ReadLine();
                    player.Relic = inputFile.ReadLine();
                    player.Inventory = Inventory;
                    playerList.Add(player);
                }

                inputFile.Close();

                // password authenticationthey

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            foreach (Player p in playerList)
            {
                if (tempName == p.Name)
                {
                    if (tempPass == p.Password)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Player found!");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.ReadLine();
                        playerList = blankPlayerList;
                        player = LoadPlayerInventory(p, weaponList, lootList);
                        playerList.Add(p);

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Player name / Password did not match");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.ReadLine();
                        playerList = blankPlayerList;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No player found");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ReadLine();
                    playerList = blankPlayerList;
                }
            }
            inRoomList = Game.AddtoRoomList(weaponList, lootList, mobList, inRoomList, roomList, playerList);
            return inRoomList;
        }
        public static Player LoadPlayerInventory(Player player, List<IRoom> weaponList, List<IRoom> lootList)
        {
            string temp = "";
            string temp2 = "";
            string temp3 = "";
            string end = "end";
            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("PlayerInventory2.txt");
                Console.WriteLine("");
                temp = inputFile.ReadLine();
                if (temp == player.Name)
                {
                    while (temp2 != end)
                    {
                        temp2 = inputFile.ReadLine();
                        if (temp2 == end)
                        {
                            
                        }
                        else
                        {
                            foreach (Weapon weapon in weaponList)
                            {
                                if(temp2 == weapon.Name)
                                {
                                    player.Inventory.Add(weapon);
                                }
                            }
                            foreach (Loot loot in lootList)
                            {
                                if (temp2 == loot.Name)
                                {
                                    player.Inventory.Add(loot);
                                }
                            }
                        }
                    }
                }

                inputFile.Close();

                // password authenticationthey

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return player;
        }
        public static List<IRoom> Rooms(List<IRoom> roomList)
        {
            // loads the room objects from Rooms.txt
            int count = 0;
            List<IRoom> RoomContents = new List<IRoom>();

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
                    room.RoomContents = RoomContents;
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
        public static void ViewPicture()
        {
            string temp = "";

            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("monster.txt");
                Console.WriteLine("");
                while (!inputFile.EndOfStream)
                {
                    temp = inputFile.ReadLine();
                    Console.WriteLine(temp);
                }

                inputFile.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            Console.ReadLine();
        }
    }
}