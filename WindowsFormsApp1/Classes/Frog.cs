using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class Frog : Animal
    {
        public Frog(string name = "Frog", int hungerPoints = 0, bool isHungry = false, int hungerLimit = 30, string voise = "quack") : base(hungerPoints, isHungry)
        {
            this.name = name;
            this.HungerLimit = hungerLimit;
            this.Voise = voise;
            this.Food = new List<Food> { new Bugs(), new Worms() };
        }
    }
}
