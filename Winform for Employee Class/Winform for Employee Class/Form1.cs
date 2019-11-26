using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRLibrary;

/**
* 11-17-19
* CSC 253
* Samuel Blythe
* Uses Winforms to display employee information.
*/

namespace Winform_for_Employee_Class
{  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Employee employee = new Employee("Susan Meyers", 47899, "Accounting", "Vice President");
            Employee employee2 = new Employee("Mark Jones", 39119, "IT", "Programmer");
            Employee employee3 = new Employee("Joy Rogers", 81774, "Manufacturing", "Engineer");

            MessageBox.Show($"Employee 1" + (Environment.NewLine) + $"Name: {employee.Name}" +
            (Environment.NewLine) + $"IdNumber: {employee.IdNumber}" + (Environment.NewLine) +
            $"Department: {employee.Department}" + (Environment.NewLine) + $"Position: {employee.Position}" + (Environment.NewLine) +
            " " + (Environment.NewLine) + $"Employee 2" + (Environment.NewLine) + $"Name: {employee2.Name}" +
            (Environment.NewLine) + $"IdNumber: {employee2.IdNumber}" + (Environment.NewLine) +
             $"Department: {employee2.Department}" + (Environment.NewLine) + $"Position: {employee2.Position}" + (Environment.NewLine) +
             " " + (Environment.NewLine) + $"Employee 3" + (Environment.NewLine) + $"Name: {employee3.Name}" +
            (Environment.NewLine) + $"IdNumber: {employee3.IdNumber}" + (Environment.NewLine) +
            $"Department: {employee3.Department}" + (Environment.NewLine) + $"Position: {employee3.Position}" + (Environment.NewLine) + " ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
