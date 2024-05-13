using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Frog : Animal
    {
        public Frog(string name = "Frog", int hungerPoints = 0, bool isHungry = false, int hungerLimit = 30, string voise = "quack") : base(hungerPoints, isHungry)
        {
            this.name = name;
            this.HungerLimit = hungerLimit;
            this.Voise = voise;
        }
    }
}
