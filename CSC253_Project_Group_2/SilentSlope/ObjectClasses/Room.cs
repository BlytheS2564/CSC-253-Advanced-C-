using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    // initializes room class
    public class Room : IRoom
    {

        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public List<IRoom> RoomContents { get; set; }

        public override string ToString()
        {
            return $"ID: {RoomID}" + "\n" + $"Name: {RoomName}" + "\n" + $"Description: {RoomDescription}" + "\n";
        }

    }
}
