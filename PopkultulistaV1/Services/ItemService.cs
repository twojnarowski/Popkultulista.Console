using PopkultulistaV1.Models;
using static PopkultulistaV1.Helpers;

namespace PopkultulistaV1.Services;

internal class ItemService
{
    private static List<Item> _items = new List<Item>();

    internal void Add(string? name, int type)
    {
        Item item = new() { Name = name, ItemType = (ItemType)type, FomoScore = 0, Id = GenerateId() };
        _items.Add(item);
    }

    internal IEnumerable<Item> Browse()
    {
        return _items;
    }

    internal void Remove(int chosenId)
    {
        if (_items.Any(x => x.Id == chosenId))
        {
            Item item = _items.Single(x => x.Id == chosenId);
            _items.Remove(item);
        }
    }

    internal Item Get(int chosenId)
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

    internal bool IsEmpty()
    {
        return !_items.Any();
    }
}