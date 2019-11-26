using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class InputSplit
    {
        //Takes input and splits the string into individual words analyzing, sends the list to wordcheck.wordsplit
        public static List<List<IRoom>> Split(string input, Room roomObject,
            int row, int col, string roomName, List<List<IRoom>> inRoomList)
        {
            int count = 0;
            String[] stringlist = input.Split(' ');
            foreach (string s in stringlist)
            {
                count++;
            }

            WordCheck.WordSplit(stringlist, count, roomObject, row, col, roomName, inRoomList);
            return inRoomList;
        }
    }
}

