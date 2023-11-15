using ConsoleBurguer;
using Hamburger;
using System.ComponentModel.Design;


internal class Program {
    private static Pedido pedido = new Pedido();

    private static void Main(string[] args) {
        //Aquí declaramos la codificación de texto de la consola
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        //Iniciamos el menu y el bucle de la aplicación
        while (true) {
            Menu();
        }

    }

    /// <sumary>
    /// Este método muestra el menu principal, también funciona como la pantalla de inicio de la aplicación.
    /// Incluye Console.Clear() al principio para limpiar la pantalla cada vez que se vuelve a este menu
    /// </sumary>
    private static void Menu() {
        Console.Clear();
        Console.WriteLine("Bienvenido a Los Pollos Hermanos!\n");
        Console.WriteLine("1. Ver pedido actual");
        Console.WriteLine("2. Añadir al pedido");
        Console.WriteLine("3. Ver menú");
        Console.WriteLine("4. Salir");

        int nSel = solicitarOpcion(1,4);

        switch (nSel) {
            case 1:
                MostrarPedido();
                break;
            case 2:
                SeleccionItem();
                break;
            case 3:
                verMenu();
                break;
            case 4:
                //Cerramos la aplicación
                Environment.Exit(3);
                break;
            default:
                Error();
                break;
        }
    }

    /// <sumary>
    /// Este método imprime por pantalla el pedido acumulado
    /// Utiliza el método propio de cada item para mostrarlo por pantalla
    /// </sumary>
    private static void MostrarPedido() {
        string s = string.Format("\n{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}", "Item", "Cantidad", "Precio Ud (€)", "Precio (€)");
        Console.Write("Fecha:\t{0}",pedido.getDate().ToString());
        Console.WriteLine(s);
        //Se van imprimiendo los items del pedido con el método propio de cada uno
        foreach (Item item in pedido.getItems()) {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("\nTotal a pagar: " + pedido.getTotal() + " €");
        Console.WriteLine("\nPresiona una tecla para continuar...");
        Console.ReadLine();
    }

    /// <sumary>
    /// Este método permite al usuario seleccionar que item quiere añadir al pedido
    /// Si no seleccionar una opción válida, no hace nada
    /// </sumary>
    private static void SeleccionItem() {
        Console.WriteLine("\n1. Hamburguesa");
        Console.WriteLine("2. Patatas");
        Console.WriteLine("3. Bebida");
        int nSel = solicitarOpcion(1,3);

        switch (nSel) {
            case 1:
                SeleccionHamburguesa();
                break;
            case 2:
                SeleccionPatatas();
                break;
            case 3:
                SeleccionBebida();
                break;
            default:
                Error();
                break;
        }
    }

    /// <sumary>
    /// Este método permite al usuario seleccionar el tamaño de las patatas que quiere
    /// Si la opción no es válida, vuelve al menú principal
    /// </sumary>
    private static void SeleccionPatatas() {
        int cantidadN = solicitarCantidad();

        if (cantidadN > 0) {
            Console.WriteLine("Tamaño de patas:");
            Console.WriteLine("1. Ración simple");
            Console.WriteLine("2. Ración doble");
            int nSel = solicitarOpcion(1, 3);


            switch (nSel) {
                case 1:
                    pedido.addItem(new Patatas(cantidadN, nSel));
                    break;
                case 2:
                    pedido.addItem(new Patatas(cantidadN, nSel));
                    break;
                default:
                    Error();
                    break;
            }
        }
    }

    /// <sumary>
    /// Este método permite al usuario seleccionar el tamaño de la hamburguesa que quiere y si quiere extras
    /// </sumary>
    private static void SeleccionHamburguesa() {
        int cantidadN = solicitarCantidad();
        int nSel;
        int[] extras = {0, 0, 0, 0};

        if (cantidadN > 0) {
            Console.WriteLine("\nTamaño de la hamburguesa:");
            Console.WriteLine("1. Normal");
            Console.WriteLine("2. Grande");
            Console.WriteLine("3. Extra Grande");

            nSel = solicitarOpcion(1,3);

            //Aquí se le piden al usuario los extras, puede pedir tantos como quiera.
            int extra = solicitarExtras();
            while(extra>0) {
                extras[extra-1]++;
                extra = solicitarExtras();
            }
            

            switch (nSel) {
                case 1:
                    pedido.addItem(new Burger(cantidadN, nSel, extras));
                    break;
                case 2:
                    pedido.addItem(new Burger(cantidadN, nSel, extras));
                    break;
                case 3:
                    pedido.addItem(new Burger(cantidadN, nSel, extras));
                    break;
                default:
                    Error();
                    break;
            }
        }
    }
    
    /// <sumary>
    /// Este método permite al usuario pedir extras para su hamburguesa
    /// </sumary>
    /// <returns>Devuelve un valor entero que representa el extra pedido. 0 es el valor por defecto que no representa ningún extra</returns>
    private static int solicitarExtras() {
        int extra = 0;
        Console.WriteLine("\n¿Quieres algún extra en tus hamburguesas? S/N\nCada extra vale 1 €");
        Console.WriteLine("Una hamburguesa normal lleva:\n\t- 200gr Vacuno\n\t- Cebolla caramelizada\n\t- Tomate\n\t- Queso");
        if (Console.ReadLine().ToUpper() == "S") {
            Console.WriteLine("Extras:");
            Console.WriteLine("1. Queso");
            Console.WriteLine("2. Cebolla");
            Console.WriteLine("3. Bacon");
            Console.WriteLine("4. Pepinillo");
            extra = solicitarOpcion(1, 4);
        }
        return extra;
    }

    /// <sumary>
    /// Este método muestra al usuario la opciones de bebida y le permite hacer una selección
    /// </sumary>
    private static void SeleccionBebida() {
        Console.WriteLine("\n1. Agua");
        Console.WriteLine("2. Coca-Cola");
        Console.WriteLine("3. Nestea");
        int nSel = solicitarOpcion(1,3);

        int cantidadN = solicitarCantidad();

        switch (nSel) {
            case 1:
                pedido.addItem(new Agua(cantidadN));
                break;
            case 2:
                pedido.addItem(new CocaCola(cantidadN));
                break;
            case 3:
                pedido.addItem(new Nestea(cantidadN));
                break;
            default:
                Error();
                break;
        }
    }

    /// <sumary>
    /// Este método se utiliza para hacer una pausa y mostrar un mensaje de error en la pantalla
    /// </sumary>
    private static void Error() {
        Console.WriteLine("Selección no reconocida");
        Console.WriteLine("\nPresiona una tecla para continuar...");
        Console.ReadLine();
    }

    /// <sumary>
    /// Este método le pide al usuario una cantidad por pantalla y la devuelve como entero
    /// También comprueba que la cantidad no sea <= 0
    /// Si la cantidad es <= 0, o no se puede parsear, devuelve -1 como error
    /// </sumary>
    /// <returns> </returns>
    private static int solicitarCantidad() {
        Console.WriteLine("Introduce la cantidad:");
        var cantidadSel = Console.ReadLine();
        int cantidadN = -1;
        int.TryParse(cantidadSel, out cantidadN);
        if (cantidadN <= 0) {
            Console.WriteLine("La cantidad introducida no es válida");
            return -1;
        } else {
            return cantidadN;
        }
    }


    /// <sumary>
    /// Este método le pide al usuario que seleccione una opción entre un mínimo y un máximo
    /// Devuelve el valor seleccionado como un entero
    /// Si la opción introducida no se puede parsear, o si no es una opción válida, 
    /// imprimer un mensaje de error y devuelve -1
    /// </sumary>
    /// <returns>El valor seleccionado como un entero</returns>
    private static int solicitarOpcion(int min, int max) {
        var selection = Console.ReadLine();
        int nSel = -1;
        int.TryParse(selection, out nSel);

        if (nSel < min || nSel >max) {
            return -1;
        } else {
            return nSel;
        }
    }

    /// <sumary>
    /// Imprime en la pantalla todas las opciones de comida, bebia y patatas
    /// </sumary>
    private static void verMenu() {
        Console.Clear();
        Console.WriteLine("\t\tMENU:");
        Console.WriteLine("\n\tHamburguesa\t10.50 €");
        Console.WriteLine("\nIngredientes:\n\t- 200gr Vacuno\n\t- Cebolla caramelizada\n\t- Tomate\n\t- Queso");
        Console.WriteLine("Extras (conllevan un coste adicional de 1 €):");
        Console.WriteLine("\t- Queso\n\t- Cebolla\n\t- Bacon\n\t- Pepinillo");
        Console.WriteLine("\n\tPatatas\n\n\tRación simple:\t5.25 €\n\tRación doble: 7.88 €\t");
        Console.WriteLine("\n\tBebidas:\n");
        Console.WriteLine("\tAgua: 1.80 €\t");
        Console.WriteLine("\tCocaCola: 2.30 €\t");
        Console.WriteLine("\tNestea: 2.80 €\t");

        Console.WriteLine("\nPresiona una tecla para continuar...");
        Console.ReadLine();
    }
}
