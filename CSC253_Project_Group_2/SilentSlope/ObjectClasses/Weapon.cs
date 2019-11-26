using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    // initializes weapon class
    public class Weapon : Item, IWeapon
    {
        public int Damage { get; set; }
    }
       
}
