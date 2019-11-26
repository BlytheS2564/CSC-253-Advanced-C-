using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLibrary
{
    public class Employee
    {
        private string _name;
        private int _idnumber;
        private string _department;
        private string _position;


        public Employee()
        {
            Name = " ";
            IdNumber = 0;
            Department = " ";
            Position = " ";
        }

        public Employee(string name, int idnumber, string department, string position)
        {
            Name = name;
            IdNumber = idnumber;
            Department = department;
            Position = position;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int IdNumber
        {
            get
            {
                return _idnumber;
            }

            set
            {
                _idnumber = value;
            }
        }

        public string Department
        {
            get
            {
                return _department;
            }

            set
            {
                _department = value;
            }
        }

        public string Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }
    }
}
