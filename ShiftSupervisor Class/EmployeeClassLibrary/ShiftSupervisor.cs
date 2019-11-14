using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClassLibrary
{
    public class ShiftSupervisor : Employee
    {
        private double _salary;
        private double _bonus;


        public ShiftSupervisor()
        {
            Salary = 0;
            Bonus = 0;
        }

        public ShiftSupervisor(double salary, double bonus)
        {
            Salary = salary;
            Bonus = bonus;
        }

        public double Salary { get { return _salary; } set { _salary = value; } }
        public double Bonus { get { return _bonus; } set { _bonus = value; } }
    }
}
