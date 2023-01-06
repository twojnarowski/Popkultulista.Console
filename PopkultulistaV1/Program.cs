using PopkultulistaV1.Models;
using PopkultulistaV1.Services;
using static PopkultulistaV1.Helpers;

namespace PopkultulistaV1;

public class Program
{
    public static void Main(string[] args)
    {
        ItemService _itemService = new ItemService();
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

            int.TryParse(Console.ReadLine(), out chosenOption);
            Console.Clear();
            if (chosenOption == 1)
            {
                Console.WriteLine("Podaj nazwę pozycji:");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj typ pozycji:");
                foreach (ItemType type in Enum.GetValues(typeof(ItemType)))
                {
                    Console.WriteLine($"{(int)type} - {type}");
                }
                int.TryParse(Console.ReadLine(), out int chosenType);
                _itemService.Add(name, chosenType);
            }
            else if (chosenOption == 2)
            {
                Console.WriteLine("Wpisz ID pozycji do usunięcia:");
                foreach (Item item in _itemService.Browse())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }
                int.TryParse(Console.ReadLine(), out int chosenId);
                _itemService.Remove(chosenId);
            }
            else if (chosenOption == 3)
            {
                if (!_itemService.IsEmpty())
                {
                    Console.WriteLine("Wpisz ID pozycji do wyświetlenia:");
                    foreach (Item item in _itemService.Browse())
                    {
                        Console.WriteLine($"{item.Id} - {item.Name}");
                    }
                    int.TryParse(Console.ReadLine(), out int chosenId);
                    Item itemToShow = _itemService.GetItem(chosenId);
                    Console.WriteLine($"Id: {itemToShow.Id}");
                    Console.WriteLine($"Nazwa: {itemToShow.Name}");
                    Console.WriteLine($"FomoScore: {itemToShow.FomoScore}");
                    Console.WriteLine($"Type: {itemToShow.ItemType}");
                }
                else
                {
                    Console.WriteLine("Brak pozycji do wyświetlenia!");
                }
                Console.WriteLine($"Wciśnij dowolny przycisk, aby kontynuować...");
                Console.ReadKey();
            }
        }
        while (chosenOption != 0);
    }
}