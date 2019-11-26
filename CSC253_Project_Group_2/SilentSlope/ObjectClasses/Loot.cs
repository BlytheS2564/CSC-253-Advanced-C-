using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    // initializes item class
    public class Loot : Item, ILoot
    {
        public int Heal { get; set; }
    }
}
