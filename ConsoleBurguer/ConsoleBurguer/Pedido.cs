using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger
{
    internal class Pedido
    {
        public List<Item> pedido;

        public Pedido(){
            pedido = new List<Item>();
        }

        public void addItem(Item it)
        {
            pedido.Add(it);
        }

        public double getTotal()
        {
            double total = 0;
            foreach (Item it in pedido)
            {
                total += it.CalculatePrice();
            }
            return total;
        }
        public List<Item> getItems()
        {
            return pedido;
        }
    }
}
