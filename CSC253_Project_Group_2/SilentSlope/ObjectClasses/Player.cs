using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    // initializes player class
    public class Player : Living, IPlayer
    {
        public string Password { get; set; }
        public int Crit { get; set; }
        public string Zodiac { get; set; }
        public string Relic { get; set; }
        public List<IItem> Inventory { get; set; }

        public override void IsAlive(int damage, int health)
        {
            Console.WriteLine("");

        }
        public override void IsAlive(int heal, int health, string a)
        {
            throw new NotImplementedException();
        }
    }
}
