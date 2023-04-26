// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


using net_ef_videogame.Classes;

while (true)
{
    int option = 0;

    while (option is 0)
    {
        Console.WriteLine("Menù");
        Console.WriteLine("1. Inserisci videogioco");
        Console.WriteLine("2. Inserisci software house");
        Console.WriteLine("3. Ricerca videogiochi");
        Console.WriteLine("4. Elimina videogioco");
        Console.WriteLine("5. Esci");
        var input = Console.ReadLine();
        option = Menu(input);
    }

    switch (option)
    {
        case 1:
            GameManager.AddGame();
            break;
        case 2:
            GameManager.AddSoftwareHouse();
            break;
        case 3:
            GameManager.SearchGame();
            break;
        case 4:
            GameManager.DeleteGame();
            break;
        case 5:
            Environment.Exit(0);
            break;
    }
}

int Menu(string? input)
{
    switch (input)
    {
        case "1":
        case "inserisci videogioco":
            return 1;
        case "2":
        case "inserisci software house":
            return 2;
        case "3":
            return 3;
        case "4":
            return 4;
        case "5":
        case "esci":
        case "exit":
            return 5;
        default:
            Console.WriteLine("Input non valido\n");
            return 0;
    }
}