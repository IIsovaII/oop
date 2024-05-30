using System;
using System.Windows.Forms;

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
