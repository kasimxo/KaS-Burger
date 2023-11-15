using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger {
    internal class Burger : Item {
        private double price = 10.50;
        private String name = "Hamburgesa";
        private int unidades;
        private double size;

        int extraQueso;
        int extraCebolla;
        int extraBacon;
        int extraPepinillo;

        public Burger(int cantidad, int selectedSize, int[] extras) {
            unidades = cantidad;
            size = selectedSize-1;
            extraQueso = extras[0];
            extraCebolla = extras[1];
            extraBacon = extras[2];
            extraPepinillo += extras[3];
        }
        public override double CalculatePrice() {
            return Math.Round(unidades*price*(1+size/10),2)+extraQueso+extraPepinillo+extraCebolla+extraBacon;
        }

        public override string GetName() {
            return name;
        }

        public override double GetPricePerUnit() {
            return Math.Round(price * (1 + size / 10),2) + extraQueso + extraPepinillo + extraCebolla + extraBacon;
        }

        public override int GetQuantity() {
            return unidades;
        }

        public override string ToString() {
            string tam = "Normal";
            if (size == 2) {
                tam = "Extra Grande";
            } else if(size>0) {
                tam = "Grande";
            }
            String a = String.Format("{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}\tTamaño:{4,-15}", GetName(), GetQuantity(), GetPricePerUnit(), CalculatePrice(),tam);
            if (extraQueso + extraBacon + extraCebolla + extraPepinillo > 0) {
                a += String.Format("\n\tExtras:");
                if (extraQueso > 0) {
                    a += String.Format("\n\t\tQueso: x{0,-5}",extraQueso);
                }
                if (extraCebolla > 0) {
                    a += String.Format("\n\t\tCebolla: x{0,-5}", extraCebolla);
                }
                if (extraBacon > 0) {
                    a += String.Format("\n\t\tBacon: x{0,-5}", extraBacon);
                }
                if (extraPepinillo > 0) {
                    a += String.Format("\n\t\tPepinillo: x{0,-5}", extraPepinillo);
                }
            }
            return a;
        }
    }
}
