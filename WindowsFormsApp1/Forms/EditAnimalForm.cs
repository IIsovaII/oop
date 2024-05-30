using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditAnimalForm : Form
    {
        public EditAnimalForm()
        {
            InitializeComponent();
        }

        public Animal localAnimal;

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox2.Text = localAnimal.HungerPoints.ToString();
            textBox3.Text = localAnimal.HungerLimit.ToString();
            textBox4.Text = localAnimal.Voise;

            button1.Click += new EventHandler(getSelectedRB_Click);
        }

        void getSelectedRB_Click(object sender, EventArgs e)
        {
            localAnimal.HungerPoints = Convert.ToInt32(textBox2.Text);
            localAnimal.HungerLimit = Convert.ToInt32(textBox3.Text);
            localAnimal.Voise = textBox4.Text;

            this.Close();
        }
    }
}
