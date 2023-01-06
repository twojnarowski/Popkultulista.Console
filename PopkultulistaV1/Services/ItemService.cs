using PopkultulistaV1.Models;
using static PopkultulistaV1.Helpers;

namespace PopkultulistaV1.Services;

public class ItemService
{
    private static List<Item> _items = new List<Item>();

    public void Add(string? name, int type)
    {
        Item item = new() { Name = name, ItemType = (ItemType)type, FomoScore = 0, Id = GenerateId() };
        _items.Add(item);
    }

    public IEnumerable<Item> Browse()
    {
        return _items;
    }

    public void Remove(int chosenId)
    {
        if (_items.Any(x => x.Id == chosenId))
        {
            Item item = _items.Single(x => x.Id == chosenId);
            _items.Remove(item);
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