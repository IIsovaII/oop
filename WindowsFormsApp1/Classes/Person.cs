using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Person
    {
        private string _name;
        public string name { get => _name; set => _name = value; }
        public string _sex;
        public string sex { get => _sex; set => _sex = value; }

        public Person(string Name, string Sex)
        {
            name = Name;
            sex = Sex;
        }
    }
}
