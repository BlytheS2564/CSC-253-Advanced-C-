using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class Take
    {
        public static List<List<IRoom>> TakeWhat(string strObject, Room roomObject, List<List<IRoom>> inRoomList)
        {
            Loot tempLoot = new Loot();
            Weapon tempWeapon = new Weapon();
            
            List<IRoom> playerList = new List<IRoom>();
            List<IRoom> roomContentsList = new List<IRoom>();
            playerList = inRoomList[4];
            IRoom item1 = playerList[0];
            if (item1 is Player player)
            {
                roomContentsList = roomObject.RoomContents;
                int inventoryCount = player.Inventory.Count();
                for (int i = 0; i < roomContentsList.Count; i++)
                {
                    IRoom item = roomContentsList[i];

                    if (item is Loot lootObject)
                    {
                        if (strObject == lootObject.Name.ToLower())
                        {
                            tempLoot = lootObject;
                            roomObject.RoomContents.RemoveAt(i);
                            player.Inventory.Add(tempLoot);
                            Console.WriteLine($"You have added {tempLoot.Name} to your inventory.");
                            break;
                        }
                    }
                    else if (item is Weapon weaponObject)
                    {
                        if (strObject == weaponObject.Name.ToLower())
                        {
                            tempWeapon = weaponObject;
                            roomObject.RoomContents.RemoveAt(i);
                            player.Inventory.Add(tempWeapon);
                            Console.WriteLine($"You have added {weaponObject.Name} to your inventory.");
                            break;
                        }
                    }

                }
                int newInventoryCount = player.Inventory.Count();
                if (newInventoryCount == inventoryCount)
                {
                    Console.WriteLine("No item found");
                }

            }
            return inRoomList;

        }
    }
}
