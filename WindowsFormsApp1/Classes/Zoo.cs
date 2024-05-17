using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Zoo
    {
        public List<IAviary> aviaries;
        public List<Worker> workers;
        public List<Visitor> people;

        public int timerTicks = 0;
        private int N = 0; // раз в N тиков животные будут переходить

        public Zoo()
        {
            aviaries = new List<IAviary>();
            workers = new List<Worker>();
            people = new List<Visitor>();

            Random random = new Random();
            string type;
            for (int i = 0; i < 15; i++)
            {
                int r = random.Next(3);
                if (r == 0) type = "Cat";
                else if (r == 1) type = "Frog";
                else type = "Fox";

                AddAnimal(type);
            }
        }


        private void AddAnimalWithType(int index, string type)
        {
            if (type == "Cat")
                aviaries[index].Animals().Add(new Cat());
            else if (type == "Frog")
                aviaries[index].Animals().Add(new Frog());
            else
                aviaries[index].Animals().Add(new Fox());
        }

        public bool AddAnimal(string animalType)
        {
            for (int i = 0; i < aviaries.Count; i++)
            {
                if (aviaries[i].Animals().Count == 0 || (aviaries[i].Animals()[0].name == animalType && aviaries[i].Animals().Count() < aviaries[i].ShowSize()))
                {
                    AddAnimalWithType(i, animalType);
                    return true;
                }
            }

            AddAviary(new List<string> { "5", "5" });
            AddAnimalWithType(aviaries.Count - 1, animalType);
            return false;
        }

        public void AddAviary(List<string> a)
        {
            aviaries.Add(new Aviary(new List<Animal>(),
                Int32.Parse(a[0]), 0, Int32.Parse(a[1])));
        }

        public void AddVisitor(List<string> p)
        {
            people.Add(new Visitor(p[0], p[1], Int32.Parse(p[2])));
        }

        public void AddWorker(List<string> w)
        {
            var rand = new Random();
            workers.Add(new Worker(w[0], w[1], w[2], rand.Next(aviaries.Count()), false));
        }

        public void Remove(string type, int index)
        {
            // удаленеи животного внутри вольера
            if (type == "worker")
            {
                workers.RemoveAt(index);
                return;
            }
            people.RemoveAt(index);
        }

        public void Delicacy()
        {
            foreach (var v in people)
            {
                v.Delicacy(aviaries);
            }
        }

        public void Feeding()
        {
            foreach (Worker w in workers)
            {
                w.Feeding(aviaries[w.aviaryForCare]);
            }
        }

        public void HungerGrow()
        {
            foreach (IAviary a in aviaries)
            {
                foreach (Animal an in a.Animals())
                    an.PlusHungry();
            }
        }


        public void Eat()
        {
            foreach (IAviary a in aviaries)
            {
                a.AnimalsEating();
            }
        }

        public void Moving()
        {
            if (timerTicks % 5 == N)
                foreach (IAviary a in aviaries)
                    a.Moving();
        }
    }
}
