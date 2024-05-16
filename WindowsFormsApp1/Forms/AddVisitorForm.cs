using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class AddVisitorForm : Form
    {
        public AddVisitorForm()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button1.Click += new EventHandler(getSelectedRB_Click);
        }

        public List<string> CommunicationStuff = new List<string>();


        void getSelectedRB_Click(object sender, EventArgs e)
        {
            CommunicationStuff.Add(textBox1.Text);
            CommunicationStuff.Add(textBox2.Text);
            CommunicationStuff.Add(textBox3.Text);
            this.Close();
        }

    }
}
