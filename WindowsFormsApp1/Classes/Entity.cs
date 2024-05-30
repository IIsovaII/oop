using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Entity
    {
        private Guid id = Guid.NewGuid();

        public Guid Id { get => id ; }

        public abstract void ShowStatus();
    }
}
