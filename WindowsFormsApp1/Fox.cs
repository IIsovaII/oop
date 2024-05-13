using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Fox : Animal
    {
        public Fox(string name = "Fox", int hungerPoints = 0, bool isHungry = false, int hungerLimit = 70,
            string voise = "\"Ring-ding-ding-ding-dingeringeding!\n" +
                            "Gering-ding-ding-ding-dingeringeding!\n" +
                            "Gering-ding-ding-ding-dingeringeding!\"") : base(hungerPoints, isHungry)
        {
            this.name = name;
            this.HungerLimit = hungerLimit;
            this.Voise = voise;
        }
    }
}
