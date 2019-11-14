using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClassLibrary
{
    public class ProductionWorker : Employee
    {
        private int _shift;
        private double _payRate;


        public ProductionWorker()
        {
            Shift = 0;
            PayRate = 0;
        }

        public ProductionWorker(int shift, double payRate)
        {
            Shift = shift;
            PayRate = payRate;
        }

        public int Shift { get { return _shift; } set { _shift = value; } }
        public double PayRate { get { return _payRate; } set { _payRate = value; } }
    }
}
