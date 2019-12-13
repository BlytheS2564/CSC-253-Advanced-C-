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
        public Loot DeepCopy(string Name, string Description, int Heal)
        {
            Loot deepCopyLoot = new Loot();
            deepCopyLoot.Name = Name;
            deepCopyLoot.Description = Description;
            deepCopyLoot.Heal = Heal;
            return deepCopyLoot;
        }
    }
}
