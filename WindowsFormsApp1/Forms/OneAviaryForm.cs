﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OneAviaryForm : Form
    {
        public OneAviaryForm()
        {
            InitializeComponent();
        }

        public List<Entity> entities;
        public IAviary localAviary;

        private void OneAviaryForm_Load(object sender, EventArgs e)
        {
            label3.Text = localAviary.Animals().Count().ToString();
            label5.Text = localAviary.ShowFeederFullness().ToString();

            for (int i = 0; i < localAviary.Animals().Count(); i++)
            {
                Animal animal = (Animal)entities.Find(x => x.Id == localAviary.Animals()[i]);
                listBox1.Items.Add(animal.name);
            }
        }

        // voise
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Animal animal = (Animal)entities.Find(x => x.Id == localAviary.Animals()[listBox1.SelectedIndex]);
                MessageBox.Show(animal.Voise);

                listBox1.SetSelected(listBox1.SelectedIndex, false);
            }
        }
        
        // remove
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                entities.Remove(entities.Find(x => x.Id == localAviary.Animals()[listBox1.SelectedIndex]));

                localAviary.Animals().RemoveAt(listBox1.SelectedIndex);

                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                label3.Text = localAviary.Animals().Count().ToString();
            }
        }

        // status
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                entities.Find(x => x.Id == localAviary.Animals()[listBox1.SelectedIndex]).ShowStatus();
            }
        }

        // add
        private void button5_Click(object sender, EventArgs e)
        {
            string type = localAviary.AddAnimal();
            if (type == "None")
            {
                MessageBox.Show("Is full");
            }
            else
            {
                listBox1.Items.Add(type);
            }
            label3.Text = localAviary.Animals().Count().ToString();
        }

        // edit
        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                using (var editForm = new EditAnimalForm())
                {
                    editForm.localAnimal = (Animal)entities.Find(x => x.Id == localAviary.Animals()[listBox1.SelectedIndex]);
                    editForm.ShowDialog();

                    Animal a = editForm.localAnimal;
                    entities.Remove(entities.Find(x => x.Id == localAviary.Animals()[listBox1.SelectedIndex]));
                    entities.Add(a);
                    localAviary.Animals()[listBox1.SelectedIndex] = a.Id;

                    listBox1.Items[listBox1.SelectedIndex] = editForm.localAnimal.name;
                }
                listBox1.SetSelected(listBox1.SelectedIndex, false);
            }
        }

        // done
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
