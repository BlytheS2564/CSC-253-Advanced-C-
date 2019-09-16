using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailItem
{
    public class Item
    {
        private string _description;
        private double _unitsOnHand;
        private double _price;

        public Item()
        {
            Description = " ";
            UnitsOnHand = 0;
            Price = 0;
        }

        public Item(string description, double unitsOnHand, double price)
        {
            Description = description;
            UnitsOnHand = unitsOnHand;
            Price = price;
        }

        public string Description { get { return _description; } set { _description = value; } }
        public double UnitsOnHand { get { return _unitsOnHand; } set { _unitsOnHand = value; } }
        public double Price { get { return _price; } set { _price = value; } }
    }

}
