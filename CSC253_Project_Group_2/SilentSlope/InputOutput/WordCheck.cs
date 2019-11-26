using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class WordCheck
    {
        // takes the word list created in InputSplit and determines where to send it based on
        // the amount of items in the list (1 word: meaning its a simple direction, help, or exit command,
        // 2 words: a look command to look at lists. 3 words: a look command for individual objects)
        // Sends to verb to determine which command it is.
        public static List<List<IRoom>> WordSplit(String[] stringlist, int count, 
            Room roomObject, int row, int col, string roomName, List<List<IRoom>> inRoomList)
        {
            string strVerb = stringlist[0];
            if (count == 2)
            {
                string strObject = stringlist[1];
                inRoomList = Verb(strVerb, strObject, roomObject, row, col, roomName, inRoomList);
            }
            else if (count == 3)
            {
                string strObject = stringlist[1] + " " + stringlist[2];
                inRoomList = Verb(strVerb, strObject, roomObject, row, col, roomName, inRoomList);
            }
            else
            {
                string strObject = "";
                inRoomList = Verb(strVerb, strObject, roomObject, row, col, roomName, inRoomList);
            }
            return inRoomList;

        }
        public static List<List<IRoom>> Verb(string strVerb, string strObject, Room roomObject, 
            int row, int col, string roomName, List<List<IRoom>> inRoomList)
        {
            bool combat = false;
            // switch to send to proper method based on the "verb" which was the first index item in the string list.
            // which was created in InputSplit.
            switch (strVerb)
            {
                case "look":
                    Look.LookupObjects(strObject, roomObject, inRoomList);
                    break;

                case "north":
                case "n":
                case "south":
                case "s":
                case "west":
                case "w":
                case "east":
                case "e":
                    inRoomList = Move.Direction(strVerb, row, col, roomName, inRoomList);
                    break;
                case "attack":
                    if (roomObject.RoomContents != null)
                    {
                        for (int i = 0; i < roomObject.RoomContents.Count; i++)
                        {
                            IRoom content = roomObject.RoomContents[i];
                            if (content is Mob item1)
                            {
                                Combat.PlayerCombat(inRoomList, roomObject);
                                combat = true;
                                if(combat == true)
                                {
                                    break;
                                }
                            }
                        }
                        if (combat == false)
                        {
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nothing to attack");
                            Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                    }
                    break;

                default:
                    OtherCommands(strVerb);
                    break;
            }
            return inRoomList;

        }

        public static void OtherCommands(string strVerb)
        {

        }
    }
}
