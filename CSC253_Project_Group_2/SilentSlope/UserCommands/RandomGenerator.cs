using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class RandomGenerator
    {
        public static Random GenerateRandom()
        {
            Random rand = new Random();
            return rand;
        }
        public static int AttackChance(Random rand)
        {
            int attackChance = rand.Next(3);
            return attackChance;
        }
        public static int RandomNumber(Random rand)
        {
            int ranNumber;
            ranNumber = rand.Next(100) + 1;
            return ranNumber;
        }
    }
}
