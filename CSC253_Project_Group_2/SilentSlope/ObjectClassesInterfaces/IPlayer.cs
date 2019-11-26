using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public interface IPlayer : ILiving
    {
        string Password { get; set; }
        int Crit { get; set; }
        string Zodiac { get; set; }
        string Relic { get; set; }
        List<IItem> Inventory { get; set; }
    }
}
