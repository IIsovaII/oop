using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditWorkerForm : Form
    {
        public EditWorkerForm()
        {
            InitializeComponent();
        }

        public Worker localWorker;

        private void EditWorkerForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = localWorker.name;
            textBox2.Text = localWorker.sex;
            textBox3.Text = localWorker.job;

            button1.Click += new EventHandler(getSelectedRB_Click);
        }

        void getSelectedRB_Click(object sender, EventArgs e)
        {
            localWorker.name = textBox1.Text;
            localWorker.sex = textBox2.Text;
            localWorker.job = textBox3.Text;

            this.Close();
        }
    }
}
