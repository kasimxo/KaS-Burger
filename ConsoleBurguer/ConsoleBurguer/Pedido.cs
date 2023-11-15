using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger {
    internal class Pedido {
        //Esta es la lista de todos los objetos pedidos
        public List<Item> pedido;
        //Este DateTime se usa para añadir una fecha y hora al pedido
        public DateTime date;

        public Pedido(){
            pedido = new List<Item>();
            date = DateTime.Now;
        }

        //Añade un item al pedido, de cualquier tipo
        public void addItem(Item it) {
            pedido.Add(it);
        }

        //Devuelve el total del pedido
        public double getTotal() {
            double total = 0;
            foreach (Item it in pedido) {
                total += it.CalculatePrice();
            }
            return total;
        }

        //Devuelve la lista del pedido
        public List<Item> getItems() {
            return pedido;
        }

        //Devuelve la fecha del pedido
        public DateTime getDate() {
            return date;
        }
    }
}
