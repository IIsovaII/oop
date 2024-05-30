using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SelectAddForm : Form
    {
        public SelectAddForm()
        {
            InitializeComponent();
        }

        private void selectAdd_Load(object sender, EventArgs e)
        {
            InitializeRadioButtons();
        }

        private RadioButton selectedrb;
        public List<string> CommunicationStuff { get; set; }
        public string CommunicationType { get; set; }

        public void InitializeRadioButtons()
        {
            selectedrb = radioButton1;
            radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton4.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            button1.Click += new EventHandler(getSelectedRB_Click);

        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            selectedrb = rb;
        }

        void getSelectedRB_Click(object sender, EventArgs e)
        {
            this.CommunicationType = selectedrb.Text;
            if (selectedrb.Text == "Aviary")
            {
                AddAviaryForm subform = new AddAviaryForm();
                subform.ShowDialog();

                this.CommunicationStuff = subform.CommunicationStuff;
            }
            else if (selectedrb.Text == "Animal")
            {
                AddAimalForm subform = new AddAimalForm();
                subform.ShowDialog();

                this.CommunicationStuff = subform.CommunicationStuff;
            }
            else if (selectedrb.Text == "Worker")
            {
                AddWorkerForm subform = new AddWorkerForm();
                subform.ShowDialog();

                this.CommunicationStuff = subform.CommunicationStuff;
            }
            else
            {
                AddVisitorForm subform = new AddVisitorForm();
                subform.ShowDialog();

                this.CommunicationStuff = subform.CommunicationStuff;
            }

            this.Close();
        }
    }
}
