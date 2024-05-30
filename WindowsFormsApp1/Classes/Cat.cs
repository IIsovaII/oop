using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class Cat : Animal
    {
        public Cat(string name = "Cat", int hungerPoints = 0, bool isHungry = false, int hungerLimit = 50, string voise = "meow") : base(hungerPoints, isHungry)
        {
            this.name = name;
            this.HungerLimit = hungerLimit;
            this.Voise = voise;
            this.Food = new List<Food> { new Fishes(), new Rats() };
        }
    }
}
