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
    public partial class EditVisitorForm : Form
    {
        public EditVisitorForm()
        {
            InitializeComponent();
        }

        public Visitor localVisitor;

        private void EditVisitorForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = localVisitor.name;
            textBox2.Text = localVisitor.sex;

            button1.Click += new EventHandler(getSelectedRB_Click);
        }

        void getSelectedRB_Click(object sender, EventArgs e)
        {
            localVisitor.name = textBox1.Text;
            localVisitor.sex = textBox2.Text;

            this.Close();
        }
    }
}
