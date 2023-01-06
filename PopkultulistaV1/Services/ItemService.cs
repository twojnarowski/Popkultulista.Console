using PopkultulistaV1.Models;
using static PopkultulistaV1.Helpers;

namespace PopkultulistaV1.Services;

public class ItemService
{
    private static List<Item> _items = new List<Item>();

    public void AddItem(string? name, int itemType)
    {
        if (Enum.IsDefined(typeof(ItemType), itemType))
        {
            if (name.Length > 0)
            {
                Item item = new() { Name = name, ItemType = (ItemType)itemType, FomoScore = 0, Id = GenerateId() };
                _items.Add(item);
                Console.WriteLine("Dodano pozycję!");
            }
            else
            {
                Console.WriteLine("Nie podano nazwy!");
            }
        }
        else
        {
            Console.WriteLine("Podano błędny typ!");
        }
    }

    public IEnumerable<Item> BrowseItems()
    {
        return _items;
    }

    public void RemoveItem(int chosenId)
    {
        if (_items.Any(x => x.Id == chosenId))
        {
            Item item = _items.Single(x => x.Id == chosenId);
            _items.Remove(item);
            Console.WriteLine("Usunięto pozycję!");
        }
        else
        {
            Console.WriteLine("Pozycja z takim ID nie istnieje!");
        }
    }

    public Item GetItem(int chosenId)
    {
        if (_items.Any(x => x.Id == chosenId))
        {
            Item item = _items.Single(x => x.Id == chosenId);
            return item;
        }
        else
        {
            Console.WriteLine("Podana pozycja nie istnieje!");
            return null;
        }
    }

    private int GenerateId()
    {
        if (!IsEmpty())
        {
            return _items.Max(x => x.Id) + 1;
        }
        else
        {
            return 1;
        }
    }

    public bool IsEmpty()
    {
        return !_items.Any();
    }
}