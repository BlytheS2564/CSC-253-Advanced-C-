using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public interface IMob : ILiving
    {
        int Drop { get; set; }
    }
}
