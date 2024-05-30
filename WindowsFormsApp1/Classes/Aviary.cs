using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1
{

    public class Aviary : IAviary
    {
        private int size;
        private List<Guid> animals = new List<Guid>();
        private int feederSize;
        private int feederFullness;
        public List<Entity> entities;
        private Food FoodForFeed;


        public Aviary(List<Guid> animals, int feederSize, int feederFullness, int size, List<Entity> entities)
        {

            this.animals = animals;
            this.feederSize = feederSize;
            this.feederFullness = feederFullness;
            this.size = size;
            this.entities = entities;
            newFood();
        }

        public void PlusFeed(int feedPoints)
        {
            feederFullness += feedPoints;
        }

        public string AddAnimal()
        {
            string type = "None";
            if (animals.Count == 0)
            {
                AddAimalForm subform = new AddAimalForm();
                subform.ShowDialog();
                type = (subform.CommunicationStuff[0]);

                if (type == "Cat")
                {
                    Cat a = new Cat();
                    entities.Add(a);
                    this.animals.Add(a.Id);
                }
                else if (type == "Frog")
                {
                    Frog a = new Frog();
                    entities.Add(a);
                    this.animals.Add(a.Id);
                }
                else
                {
                    Fox a = new Fox();
                    entities.Add(a);
                    this.animals.Add(a.Id);
                }
                return type;
            }
            if (this.animals.Count < size)
            {
                Animal animal = (Animal)entities.FirstOrDefault(x => x.Id == this.animals[0]);
                type = animal.name;

                if (type == "Cat")
                {
                    Cat a = new Cat();
                    entities.Add(a);
                    this.animals.Add(a.Id);
                }
                else if (type == "Frog")
                {
                    Frog a = new Frog();
                    entities.Add(a);
                    this.animals.Add(a.Id);
                }
                else
                {
                    Fox a = new Fox();
                    entities.Add(a);
                    this.animals.Add(a.Id);
                }
            }
            return type;
        }

        public void Moving()
        {
            Random random = new Random();
            foreach (Guid an in animals)
            {
                Animal animal = (Animal)entities.FirstOrDefault(x => x.Id == an);
                animal.IsVisible = (random.Next(10) % 2 == 0);
            }
        }

        public List<Guid> Animals()
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
            foreach (Guid an in animals)
            {
                Animal animal = (Animal)entities.FirstOrDefault(x => x.Id == an);
                if (feederFullness > 0 && animal.IsHungry())
                {
                    animal.Feeding();
                    feederFullness -= 1;
                }
            }
        }

        public void Delicacy(Visitor visitor)
        {
            foreach (Guid an in this.animals)
            {
                Animal animal = (Animal)entities.FirstOrDefault(x => x.Id == an);
                if (animal.IsVisible && animal.IsHungry())
                {
                    animal.Feeding();
                    visitor.BuySomething(5);
                }
            }
        }

        public List<Food> ShowFoodForFeed()
        {
            Animal animal = (Animal)entities.FirstOrDefault(x => x.Id == animals[0]);
            return animal.Food;
        }

        public void newFood()
        {
            Random rand = new Random();
            if (animals.Count() == 0)
                FoodForFeed = new Food();
            else
            {
                Animal animal = (Animal)entities.FirstOrDefault(x => x.Id == this.animals[0]);
                int n = rand.Next(animal.Food.Count());
                FoodForFeed = animal.Food[n];
            }
        }
    }
}
