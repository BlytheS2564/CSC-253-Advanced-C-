using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilentSlopeWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static void DisplayLoot(string name, string description, int heal)
        {
            if (heal != 0)
            {
                MessageBox.Show("Loot name: " + name + "\n" + "Description: " + description + "\n" + "Healing: " + heal);
            }
            else
            {
                MessageBox.Show("Loot name: " + name + "\n" + "Description" + description);
            }
        }
        public static void DisplayWeapon(string name, string description, int damage)
        {
            MessageBox.Show("Weapon name: " + name + "\n" + "Description: " + description + "\n" + "Damage: " + damage);

        }
        public static void DisplayMob(string name, int health, int attack)
        {
            MessageBox.Show("Mob name: " + name + "\n" + "Health: " + health + "\n" + "Attack: " + attack);

        }
    }
}
