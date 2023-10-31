using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger
{
    internal class Burger : Item
    {
        double price = 10.50;
        String name = "Hamburgesa";
        int unidades;
        double size;

        int extraQueso;
        int extraCebolla;
        int extraBacon;
        int extraPepinillo;

        public Burger(int cantidad, int selectedSize)
        {
            unidades = cantidad;
            size = selectedSize-1;
        }
        public override double CalculatePrice()
        {
            return Math.Round(unidades*price*(1+size/10),2);
        }

        public override string GetName()
        {
            return name;
        }

        public override double GetPricePerUnit()
        {
            return Math.Round(price * (1 + size / 10),2);
        }

        public override int GetQuantity()
        {
            return unidades;
        }

        public override string ToString()
        {
            string tam = "Normal";
            if (size == 2)
            {
                tam = "Extra Grande";
            } else if(size>0)
            {
                tam = "Grande";
            }
            String a = String.Format("{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}\tTamaño:{4,-15}", GetName(), GetQuantity(), GetPricePerUnit(), CalculatePrice(),tam);
            return a;
        }
    }
}
