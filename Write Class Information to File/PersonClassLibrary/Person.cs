using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class Person
    {
        private string _name;
        private int _idnumber;
        private string _department;
        private string _position;

        public Person()
        {
            Name = " ";
            Department = " ";
            IdNumber = 0;
            Position = " ";
        }

        public Person(string name, int idnumber, string department, string position)
        {
            Name = name;
            Department = department;
            IdNumber = idnumber;
            Position = position;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Department { get { return _department; } set { _department = value; } }
        public int IdNumber { get { return _idnumber; } set { _idnumber = value; } }
        public string Position { get { return _position; } set { _position = value; } }
    }
}
