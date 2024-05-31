using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public class Zoo
    {
        public List<Entity> entities;

        public List<IAviary> aviaries;
        /*public List<Guid> workers;
        public List<Guid> people;*/


        public int timerTicks = 0;
        private int N = 0; // раз в N тиков животные будут переходить

        public List<T> GetEntitiesByType<T>(T type) where T : Entity
        {
            var values = from x in entities where (x is T) select (T)x;
            List<T> list = values.ToList();
            

            return list;
        }

        public Zoo()
        {
            entities = new List<Entity>();
            aviaries = new List<IAviary>();
            /*workers = new List<Guid>();
            people = new List<Guid>();*/

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

        public void AddEntity<T>(T entity) where T : Entity
        {
            entities.Add(entity);
        }


        private void AddAnimalWithType(int index, string type)
        {
            if (type == "Cat")
            {
                Cat a = new Cat();
                AddEntity(a);
                aviaries[index].Animals().Add(a.Id);
            }
            else if (type == "Frog")
            {
                Frog a = new Frog();
                AddEntity(a);
                aviaries[index].Animals().Add(a.Id);
            }
            else
            {
                Fox a = new Fox();
                AddEntity(a);
                aviaries[index].Animals().Add(a.Id);
            }
        }

        public bool AddAnimal(string animalType)
        {
            for (int i = 0; i < aviaries.Count; i++)
            {
                if (aviaries[i].Animals().Count == 0)
                {
                    AddAnimalWithType(i, animalType);
                    return true;
                }
                else
                {
                    Animal animal = (Animal)entities.Find(x => x.Id == aviaries[i].Animals()[0]);
                    if (animal.name == animalType && aviaries[i].Animals().Count() < aviaries[i].ShowSize())
                    {
                        AddAnimalWithType(i, animalType);
                        return true;
                    }
                }
            }

            AddAviary(new List<string> { "5", "5" });
            AddAnimalWithType(aviaries.Count - 1, animalType);
            return false;
        }

        public void AddAviary(List<string> a)
        {
            aviaries.Add(new Aviary(new List<Guid>(), Int32.Parse(a[0]), Int32.Parse(a[1]), entities));
        }

        public void AddVisitor(List<string> p)
        {
            Visitor V = new Visitor(p[0], p[1], Int32.Parse(p[2]));
            AddEntity(V);
        }

        public void AddWorker(List<string> w)
        {
            var rand = new Random();
            Worker W = new Worker(w[0], w[1], w[2], rand.Next(aviaries.Count()), false);
            AddEntity(W);
        }

        public void Remove(string type, int index)
        {
            // удаленеи животного внутри вольера
            if (type == "worker")
            {
                var workers = GetEntitiesByType(new Worker());
                entities.Remove(workers[index]);
                return;
            }
            var people = GetEntitiesByType(new Visitor());

            entities.Remove(people[index]);

            people.Sort(new visitorComparer());
        }

        public void Delicacy()
        {
            foreach (Visitor v in GetEntitiesByType(new Visitor()).Cast<Visitor>())
            {
                v.Delicacy(aviaries);
            }
        }

        public void Feeding()
        {
            foreach (Worker w in GetEntitiesByType(new Worker()).Cast<Worker>())
            {
                w.Feeding(aviaries[w.aviaryForCare]);
            }
        }

        public void HungerGrow()
        {
            foreach (IAviary a in aviaries)
            {
                foreach (Guid an in a.Animals())
                {
                    Animal animal = (Animal)entities.FirstOrDefault(x => x.Id == an);
                    animal.PlusHungry();
                }
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
