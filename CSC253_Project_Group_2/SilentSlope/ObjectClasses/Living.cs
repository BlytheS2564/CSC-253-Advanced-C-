using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    // initializes mob class
    public abstract class Living : ILiving
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Armor { get; set; }
        public int CurrentRoom { get; set; }

        public abstract void IsAlive(int damage, int health);
        public abstract void IsAlive(int heal, int health, string a);
    }
}