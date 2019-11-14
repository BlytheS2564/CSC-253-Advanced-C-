using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClassLibrary
{
    public class TeamLeader : ProductionWorker
    {
        private double _monthlyBonus;
        private int _training;


        public TeamLeader()
        {
            MonthlyBonus = 0;
            Training = 0;
        }

        public TeamLeader(double monthlyBonus, int training)
        {
            MonthlyBonus = monthlyBonus;
            Training = training;
        }

        public double MonthlyBonus { get { return _monthlyBonus; } set { _monthlyBonus = value; } }
        public int Training { get { return _training; } set { _training = value; } }
    }
}
