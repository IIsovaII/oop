using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Visitor : Person 
    {
        private int wallet;
        public Visitor(string Name, string Sex, int wallet) : base(Name, Sex)
        {
            this.wallet = wallet;
        }

        public int Wallet { get => wallet; set => wallet = value; }

        public void ShowStatus()
        {
            MessageBox.Show(name + "\n" + sex);
        }

        public void BuySomething(int money)
        {
            wallet -= money;
        }
    }
}
