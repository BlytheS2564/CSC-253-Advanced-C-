using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    // initializes item class
    public class Item : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

