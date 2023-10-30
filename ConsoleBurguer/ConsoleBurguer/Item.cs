using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger
{
    public abstract class Item
    {
        /// <summary>
        /// Este método devuelve el precio por unidad, redondeado para tener solo dos decimales
        /// </summary>
        /// <returns>Un doble redondeado a dos decimales</returns>
        public abstract double GetPricePerUnit();
        /// <summary>
        /// Este método devuelve la cantidad (número de unidades) que se han pedido de este item al mismo tiempo
        /// Si posteriormente han pedido esta clase de item estará guardado por separado
        /// </summary>
        /// <returns>Un entero con el número de unidades pedidas</returns>
        public abstract int GetQuantity();
        /// <summary>
        /// Este método devuleve el precio de este item, es decir, el precio por unidad multiplicado por el número de unidades
        /// </summary>
        /// <returns>Un doble redondeado a dos decimales</returns>
        public abstract double CalculatePrice();
        /// <summary>
        /// Este método devuelve el nombre del item, ej: Patatas, Nestea...
        /// </summary>
        /// <returns>Una cadena con el nombre del item</returns>
        public abstract String GetName();
        /// <summary>
        /// Este método devuelve una cadena representando todo el item, tal y como se va a mostrar en el ticket
        /// Es decir, muestra el nombre del item, su precio por unidad, su precio total e incluso observaciones si las hubiera
        /// </summary>
        /// <returns>Una cadena con toda la información del item</returns>
        public abstract override string ToString();
        
    }
}
