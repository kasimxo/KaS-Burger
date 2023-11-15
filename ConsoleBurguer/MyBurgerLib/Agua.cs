using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger
{
    internal class Agua : Bebida
    {
        double price = 1.80;
        String name = "Agua";
        int unidades;
        public Agua(int num) {
            this.unidades = num;
        }
        public override double CalculatePrice()
        {
            return Math.Round(price*unidades,2);
        }

        public override string GetName()
        {
            return name;
        }

        public override double GetPricePerUnit()
        {
            return price;
        }

        public override int GetQuantity()
        {
            return unidades;
        }

        public override string ToString()
        {
           
            String a = String.Format("{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}", GetName(), GetQuantity(), GetPricePerUnit(), CalculatePrice());
            return a;
        }
    }
}
