using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Visitor : Person 
    {
        public Visitor(string Name, string Sex) : base(Name, Sex) { }

        public void showStatus()
        {
            MessageBox.Show(name + "\n" + sex);
        }
    }
}
