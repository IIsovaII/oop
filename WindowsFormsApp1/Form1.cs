using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 2000; // 2 seconds
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
        }

        public Zoo zoo = new Zoo();

        private void Timer1_Tick(object sender, EventArgs e)
        {
            zoo.Feeding();

            label8.Text = "timer is active";
        }

        
        public void AddAnimal(string animalType)
        {
            zoo.AddAnimal(animalType);

            listBox1.Items.Add(animalType);
            label5.Text = zoo.animals.Count.ToString();
        }

        public void AddWorker(List<string> w)
        {
            zoo.AddWorker(w);

            listBox2.Items.Add(w[0]);
            label6.Text = zoo.workers.Count.ToString();
        }

        public void AddVisitor(List<string> p)
        {
            zoo.AddVisitor(p);

            listBox3.Items.Add(p[0]);
            label7.Text = zoo.people.Count.ToString();
        }

        // add
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label8.Text = "timer is stoped";

            selectAdd subform = new selectAdd();
            subform.ShowDialog();
            string results = subform.CommunicationType;

            if (results == "Animal")
                AddAnimal(subform.CommunicationStuff[0]);
            else if (results == "Worker")
                AddWorker(subform.CommunicationStuff);
            else if (results == "Visitor")
                AddVisitor(subform.CommunicationStuff);

            timer1.Start();
            label8.Text = "timer is active";
        }


        // remove
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                zoo.Remove("animal", listBox1.SelectedIndex);

                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                label5.Text = zoo.animals.Count.ToString();
            }
            else if (listBox2.SelectedIndex != -1)
            {
                zoo.Remove("worker", listBox2.SelectedIndex);

                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                label6.Text = zoo.workers.Count.ToString();
            }
            else if (listBox3.SelectedIndex != -1)
            {
                zoo.Remove("Visitor", listBox3.SelectedIndex);

                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
                label7.Text = zoo.people.Count.ToString();
            }
        }

        //voise
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                zoo.animals[listBox1.SelectedIndex].VoiseFunc();

                listBox1.SetSelected(listBox1.SelectedIndex, false);
            }
        }

        //status
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label8.Text = "timer is stoped";

            if (listBox1.SelectedIndex != -1)
            {
                zoo.animals[listBox1.SelectedIndex].ShowStatus();

                listBox1.SetSelected(listBox1.SelectedIndex, false);
            }
            else if (listBox2.SelectedIndex != -1)
            {
                zoo.workers[listBox2.SelectedIndex].showStatus();

                listBox2.SetSelected(listBox2.SelectedIndex, false);
            }
            else if (listBox3.SelectedIndex != -1)
            {
                zoo.people[listBox3.SelectedIndex].showStatus();

                listBox3.SetSelected(listBox3.SelectedIndex, false);
            }

            timer1.Start();
            label8.Text = "timer is active";
        }

        //edit
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label8.Text = "timer is stoped";

            if (listBox1.SelectedIndex != -1)
            {
                using (var searchForm = new EditAnimalForm())
                {
                    searchForm.localAnimal = zoo.animals[(int)listBox1.SelectedIndex];
                    searchForm.ShowDialog();
                    zoo.animals[listBox1.SelectedIndex] = searchForm.localAnimal;

                    listBox1.Items[listBox1.SelectedIndex] = searchForm.localAnimal.name;
                }
                listBox1.SetSelected(listBox1.SelectedIndex, false);
            }
            else if (listBox2.SelectedIndex != -1)
            {
                using (var editForm = new EditWorkerForm())
                {
                    editForm.localWorker = zoo.workers[(int)listBox2.SelectedIndex];
                    editForm.ShowDialog();
                    zoo.workers[listBox2.SelectedIndex] = editForm.localWorker;

                    listBox2.Items[listBox2.SelectedIndex] = editForm.localWorker.name;
                }
                listBox2.SetSelected(listBox2.SelectedIndex, false);
            }
            else if (listBox3.SelectedIndex != -1)
            {
                using (var editForm = new EditVisitorForm())
                {
                    editForm.localVisitor = zoo.people[(int)listBox3.SelectedIndex];
                    editForm.ShowDialog();
                    zoo.people[listBox3.SelectedIndex] = editForm.localVisitor;

                    listBox3.Items[listBox3.SelectedIndex] = editForm.localVisitor.name;
                }
                listBox3.SetSelected(listBox3.SelectedIndex, false);
            }

            timer1.Start();
            label8.Text = "timer is active";
        }
    }
}