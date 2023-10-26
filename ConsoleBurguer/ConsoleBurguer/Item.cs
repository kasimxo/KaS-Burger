using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger
{
    public abstract class Item
    {
        public abstract double GetPricePerUnit();
        public abstract int GetQuantity();
        public abstract double CalculatePrice();
        public abstract String GetName();

        public abstract override string ToString();
        
    }
}
