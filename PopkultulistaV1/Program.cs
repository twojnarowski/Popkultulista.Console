using Popkultulista.App;
using Popkultulista.App.Managers;

namespace Popkultulista;

public class Program
{
    public static void Main(string[] args)
    {
        ItemManager itemManager = new(new ListItemService());
        int chosenOption;
        do
        {
            Console.Clear();

            Console.WriteLine("Witaj w Popkultuliście!");
            Console.WriteLine("Wybierz akcję do wykonania:");
            Console.WriteLine("1. Dodaj pozycję");
            Console.WriteLine("2. Usuń pozycję");
            Console.WriteLine("3. Zobacz szczegóły pozycji");
            Console.WriteLine("0. Zamknij aplikację");
            Console.WriteLine("Wpisz 1, 2 lub 3...");

            if (int.TryParse(Console.ReadLine(), out chosenOption))
            {
                Console.Clear();
                if (chosenOption == 1)
                {
                    itemManager.AddNewItem();
                }
                else if (chosenOption == 2)
                {
                    itemManager.RemoveItem();
                }
                else if (chosenOption == 3)
                {
                    itemManager.GetItem();
                }
                else
                {
                    Console.WriteLine("Podano błędną opcję!");
                }
            }
            else
            {
                Console.WriteLine("Podano błędną opcję, dziękujemy i do widzenia!");
            }
            Console.WriteLine($"Wciśnij dowolny przycisk, aby kontynuować...");
            Console.ReadKey();
        }
        while (chosenOption != 0);
    }
}