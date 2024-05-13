using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddAimalForm : Form
    {
        public AddAimalForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeRadioButtons();
        }

        private RadioButton selectedrb;
        public List<string> CommunicationStuff = new List<string>();

        public void InitializeRadioButtons()
        {
            selectedrb = radioButton1;
            radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            getSelectedRB.Click += new EventHandler(getSelectedRB_Click);

        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            selectedrb = rb;
        }

        void getSelectedRB_Click(object sender, EventArgs e)
        {
            CommunicationStuff.Add(selectedrb.Text);
            this.Close();
        }
    }
}
