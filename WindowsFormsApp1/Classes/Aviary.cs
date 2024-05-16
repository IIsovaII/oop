using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class Aviary : IAviary
    {
        private int size;
        private List<Animal> animals = new List<Animal>();
        private int feederSize;
        private int feederFullness;

        public Aviary(List<Animal> animals, int feederSize, int feederFullness, int size)
        {

            this.animals = animals;
            this.feederSize = feederSize;
            this.feederFullness = feederFullness;
            this.size = size;
        }

        public void PlusFeed(int feedPoints)
        {
            feederFullness += feedPoints;
        }

        public string  AddAnimal()
        {
            string type = "None";
            if (animals.Count == 0)
            {
                AddAimalForm subform = new AddAimalForm();
                subform.ShowDialog();
                type = (subform.CommunicationStuff[0]);

                if (type == "Cat")
                    this.animals.Add(new Cat());
                else if (type == "Frog")
                    this.animals.Add(new Frog());
                else
                    this.animals.Add(new Fox());

                return type;
            }
            if (this.animals.Count < size)
            {
                type = this.animals[0].name;
                if (type == "Cat")
                    this.animals.Add(new Cat());
                else if (type == "Frog")
                    this.animals.Add(new Frog());
                else
                    this.animals.Add(new Fox());
            }
            return type;
        }

        public void Moving()
        {
            Random random = new Random();
            foreach (Animal an in animals)
                an.IsVisible = (random.Next(10) % 2 == 0);
        }

        public List<Animal> Animals()
        {
            return animals;
        }

        public int ShowSize()
        {
            return size;
        }

        public int ShowFeederFullness()
        {
            return feederFullness;
        }

        public void AnimalsEating()
        {
            foreach (Animal an in animals)
            {
                if (feederFullness > 0 && an.IsHungry())
                {
                    an.Feeding();
                    feederFullness -= 1;
                }
            }
        }
    }
}
