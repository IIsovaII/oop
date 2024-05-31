using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class visitorComparer:IComparer<Visitor>
    {
        public int Compare(Visitor x, Visitor y)
        {
            //throw new NotImplementedException();
            return x.Wallet - y.Wallet;
        }
    }
}
