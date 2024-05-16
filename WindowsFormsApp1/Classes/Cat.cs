using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Cat : Animal
    {
        public Cat(string name = "Cat", int hungerPoints = 0, bool isHungry = false, int hungerLimit = 50, string voise = "meow") : base(hungerPoints, isHungry)
        {
            this.name = name;
            this.HungerLimit = hungerLimit;
            this.Voise = voise;
        }
    }
}
