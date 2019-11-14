using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClassLibrary
{
    public class Employee
    {
        private string _name;
        private int _idnumber;


        public Employee()
        {
            Name = " ";
            IdNumber = 0;
        }

        public Employee(string name, int idnumber)
        {
            Name = name;
            IdNumber = idnumber;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int IdNumber { get { return _idnumber; } set { _idnumber = value; } }
    }
}
