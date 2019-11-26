using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    // initializes mob class
    public class Mob : Living, IMob
    {

        public int Drop { get; set; }
        
        public Mob Clone(int roomID)
        {
            Mob mob = (Mob)this.MemberwiseClone();
            mob.CurrentRoom = this.CurrentRoom;
            mob.CurrentRoom = roomID;
            return mob;
        }
        public Mob DeepCopy(string Name, int Health, int Attack, int Armor, int CurrentRoom, int Drop)
        {
            Mob deepCopyMob = new Mob();
            deepCopyMob.Name = Name;
            deepCopyMob.Health = Health;
            deepCopyMob.Attack = Attack;
            deepCopyMob.Armor = Armor;
            deepCopyMob.CurrentRoom = CurrentRoom;
            deepCopyMob.Drop = Drop;
            return deepCopyMob;
        }
        public override void IsAlive(int damage, int health)
        {
            throw new NotImplementedException();
        }
        public override void IsAlive(int heal, int health, string a)
        {
            throw new NotImplementedException();
        }
    }
}
