using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Zoo
    {
        public List<Animal> animals;
        public List<Worker> workers;
        public List<Visitor> people;

        public Zoo()
        {
            animals = new List<Animal>();
            workers = new List<Worker>();
            people = new List<Visitor>();
        }

        public void AddAnimal(string animalType)
        {
            if (animalType == "Cat")
                this.animals.Add(new Cat());
            else if (animalType == "Frog")
                this.animals.Add(new Frog());
            else
                this.animals.Add(new Fox());
        }

        public void AddVisitor(List<string> p)
        {
            this.people.Add(new Visitor(p[0], p[1]));
        }

        public void AddWorker(List<string> w)
        {
            var rand = new Random();
            this.workers.Add(new Worker(w[0], w[1], w[2], rand.Next(this.animals.Count()), false));
        }

        public void Remove(string type, int index)
        {
            if (type == "animal")
            {
                this.animals.RemoveAt(index);
                return;
            }
            if (type == "worker")
            {
                this.workers.RemoveAt(index);
                return;
            }
            this.people.RemoveAt(index);
        }

        public void Feeding()
        {
            foreach (Worker w in this.workers)
                if (w.IsBuzy()) w.BuzyChange();

            for (int i = 0; i < this.animals.Count; i++)
            {
                if (animals[i].IsHungry()) 
                {
                    foreach (Worker w in this.workers)
                    {
                        if (!w.IsBuzy() && Math.Min(w.animalForCare, animals.Count()-1) == i)
                        {
                            w.BuzyChange();
                            animals[i].Feeding();
                        }
                    }
                }
            }

            foreach (Animal an in this.animals)
            {
                an.PlusHungry();
            }
        }
    }
}
