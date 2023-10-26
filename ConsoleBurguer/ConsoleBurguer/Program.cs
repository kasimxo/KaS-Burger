// See https://aka.ms/new-console-template for more information
using ConsoleBurguer;
using Hamburger;
using System.ComponentModel.Design;





Pedido pedido = new Pedido();
Console.OutputEncoding = System.Text.Encoding.Unicode;




while (true)
{
    Menu();
}





void Menu()
{
    Console.Clear();
    Console.WriteLine("Bienvenido a Los Pollos Hermanos!");
    Console.WriteLine("1. Ver pedido actual");
    Console.WriteLine("2. Añadir al pedido");
    Console.WriteLine("3. Salir");
    var selection = Console.ReadLine();
    int nSel=0;
    Int32.TryParse(selection, out nSel);
    
    switch (nSel)
    {
        case 1:
            MostrarPedido();
            break;
        case 2:
            SeleccionItem();
            break;
        case 3:
            System.Environment.Exit(3);
            break;
        default:
            Error();
            Menu();
            break;
    }
}

void MostrarPedido()
{
    String s = String.Format("\n{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}", "Item","Cantidad","Precio Ud (€)","Precio (€)");
    Console.WriteLine(s);
    foreach(Item item in pedido.getItems())
    {
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine("\nTotal a pagar: "+pedido.getTotal()+" €");
    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadLine();
}
void SeleccionItem()
{
    Console.WriteLine("\n1. Comida");
    Console.WriteLine("2. Bebida");
    var selection = Console.ReadLine();
    int nSel = 0;
    Int32.TryParse(selection, out nSel);

    switch (nSel)
    {
        case 1:
            SeleccionComida();
            break;
        case 2:
            SeleccionBebida();
            break;
        default:
            Error();
            Menu();
            break;
    }
}

void SeleccionComida() {
    Console.WriteLine("Introduce la cantidad:");
    var cantidadSel = Console.ReadLine();
    int cantidadN = 0;
    Int32.TryParse(cantidadSel, out cantidadN);

    if (cantidadN > 0)
    {
        Console.WriteLine("\nTamaño de la hamburguesa:");
        Console.WriteLine("1. Normal");
        Console.WriteLine("2. Grande");
        Console.WriteLine("3. Extra Grande");
        var selection = Console.ReadLine();
        int nSel = 0;
        Int32.TryParse(selection, out nSel);
    
        switch (nSel)
        {
            case 1:
                pedido.addItem(new Burger(cantidadN, nSel));
                break;
            case 2:
                pedido.addItem(new Burger(cantidadN, nSel));
                break;
            case 3:
                pedido.addItem(new Burger(cantidadN, nSel));
                break;
            default:
                Error();
                Menu();
                break;
        }
    }
}
void SeleccionBebida() {
    Console.WriteLine("\n1. Agua");
    Console.WriteLine("2. Coca-Cola");
    Console.WriteLine("3. Nestea");
    var selection = Console.ReadLine();
    int nSel = 0;
    Int32.TryParse(selection, out nSel);

    Console.WriteLine("Introduce la cantidad:");
    var cantidadSel = Console.ReadLine();
    int cantidadN = 0;
    Int32.TryParse(cantidadSel, out cantidadN);

    switch (nSel)
    {
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
            Menu();
            break;
    }
}

void Error() {
    Console.WriteLine("Selección no reconocida");
    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadLine();
}

