using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IAviary
    {
        void PlusFeed(int feedPoints);

        string AddAnimal();

        void Moving();

        List<Animal> Animals();

        int ShowSize();

        int ShowFeederFullness();

        void AnimalsEating();
    }
}
