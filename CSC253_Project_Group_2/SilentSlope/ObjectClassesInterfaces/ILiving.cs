using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public interface ILiving : IRoom
    {
        int ID { get; set; }
        string Name { get; set; }
        int Health { get; set; }
        int Attack { get; set; }
        int Armor { get; set; }
        int CurrentRoom { get; set; }
    }
}