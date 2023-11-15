using Hamburger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBurguer {
    internal class Patatas : Item {
        private double price = 5.25;
        private String name = "Patatas";
        private int unidades;
        private double size;

        /**
         * Constructor de las patatas.
         * Si ración = 1 -> Es ración simple
         * Si ración = 2 -> Es ración doble
         */
        public Patatas(int cantidad, int racion) {
            if(racion>1) {
                name += " dobles";
            } else {
                name += " simples";
            }
            size = 0.5 + racion / 2;
            unidades = cantidad;
        }

        public override double CalculatePrice() {
            return Math.Round(price * size * unidades, 2);
        }

        public override string GetName() {
            return name;
        }

        public override double GetPricePerUnit() {
            return Math.Round(price * size, 2);
        }

        public override int GetQuantity() {
            return unidades;
        }

        public override string ToString() {
            String a = String.Format("{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}", GetName(), GetQuantity(), GetPricePerUnit(), CalculatePrice());
            return a;
        }
    }
}
