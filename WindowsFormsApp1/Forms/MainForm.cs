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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public Zoo zoo = new Zoo();
        private bool time;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000; // 2 seconds
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;

            time = true;

            for (int i = 0; i < zoo.aviaries.Count; i++)
            {
                listBox1.Items.Add($"aviary {i + 1}");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (time)
            {
                timer1.Stop();
                time = false;

                label8.Text = "timer is stoped";
            }
            else
            {
                timer1.Start();
                time = true;

                label8.Text = "timer is active";
            }
        }

        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = "timer is active";

            zoo.Eat();
            zoo.Feeding();
            zoo.Delicacy();
            zoo.HungerGrow();

            zoo.timerTicks++;
            zoo.Moving();
        }

        public void AddAviary(List<string> a)
        {
            zoo.AddAviary(a);

            listBox1.Items.Add($"aviary {zoo.aviaries.Count()}");
            label5.Text = zoo.aviaries.Count.ToString();
        }

        public void AddAnimal(string animalType)
        {
            if (!zoo.AddAnimal(animalType))
            {
                listBox1.Items.Add($"aviary {zoo.aviaries.Count()}");
                label5.Text = zoo.aviaries.Count.ToString();
            }
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
            SelectAddForm subform = new SelectAddForm();
            subform.ShowDialog();
            string results = subform.CommunicationType;

            if (results == "Aviary")
                AddAviary(subform.CommunicationStuff);
            else if (results == "Animal")
                AddAnimal(subform.CommunicationStuff[0]);
            else if (results == "Worker")
                AddWorker(subform.CommunicationStuff);
            else if (results == "Visitor")
                AddVisitor(subform.CommunicationStuff);
        }


        // remove
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                MessageBox.Show("You can't remove the aviary");
                listBox1.SetSelected(listBox1.SelectedIndex, false);
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


        //status
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                using (var form = new OneAviaryForm())
                {
                    form.localAviary = zoo.aviaries[listBox1.SelectedIndex];
                    form.entities = zoo.entities;
                    form.ShowDialog();
                    zoo.aviaries[listBox1.SelectedIndex] = form.localAviary;
                }
                

                listBox1.SetSelected(listBox1.SelectedIndex, false);
            }
            else if (listBox2.SelectedIndex != -1)
            {
                zoo.entities.FirstOrDefault(x => x.Id == zoo.workers[listBox2.SelectedIndex]).ShowStatus();

                listBox2.SetSelected(listBox2.SelectedIndex, false);
            }
            else if (listBox3.SelectedIndex != -1)
            {
                zoo.entities.FirstOrDefault(x => x.Id == zoo.people[listBox3.SelectedIndex]).ShowStatus();

                listBox3.SetSelected(listBox3.SelectedIndex, false);
            }
        }

        //edit
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                MessageBox.Show("You can't edit the aviary");
            }
            else if (listBox2.SelectedIndex != -1)
            {
                using (var editForm = new EditWorkerForm())
                {
                    editForm.localWorker = (Worker)zoo.entities.Find(x => x.Id == zoo.workers[(int)listBox2.SelectedIndex]);
                    editForm.ShowDialog();

                    Worker w = editForm.localWorker;
                    zoo.entities.Remove(zoo.entities.FirstOrDefault(x => x.Id == zoo.workers[(int)listBox2.SelectedIndex]));
                    zoo.entities.Add(w);
                    zoo.workers[listBox2.SelectedIndex] = w.Id;

                    listBox2.Items[listBox2.SelectedIndex] = editForm.localWorker.name;
                }
                listBox2.SetSelected(listBox2.SelectedIndex, false);
            }
            else if (listBox3.SelectedIndex != -1)
            {
                using (var editForm = new EditVisitorForm())
                {
                    editForm.localVisitor = (Visitor)zoo.entities.Find(x => x.Id == zoo.people[(int)listBox3.SelectedIndex]); 
                    editForm.ShowDialog();

                    Visitor v = editForm.localVisitor;
                    zoo.entities.Remove(zoo.entities.FirstOrDefault(x => x.Id == zoo.people[(int)listBox3.SelectedIndex]));
                    zoo.entities.Add(v);
                    zoo.people[listBox3.SelectedIndex] = v.Id;

                    listBox3.Items[listBox3.SelectedIndex] = editForm.localVisitor.name;
                }
                listBox3.SetSelected(listBox3.SelectedIndex, false);
            }
        }
               
    }
}