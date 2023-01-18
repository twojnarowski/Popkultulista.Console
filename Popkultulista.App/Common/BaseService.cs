using Popkultulista.App.Abstract;
using Popkultulista.Core.Common;

namespace Popkultulista.App.Common;

public class BaseService<T> : IService<T> where T : BaseEntity
{
    public List<T> Items { get; set; }

    public BaseService()
    {
        Items = new List<T>();
    }

    public Guid AddItem(T item)
    {
        Items.Add(item);
        return item.Id;
    }

    public List<T> GetAllItems()
    {
        return Items;
    }

    public void RemoveItem(T item)
    {
        Items.Remove(item);
    }

    public Guid UpdateItem(T item)
    {
        var entity = Items.FirstOrDefault(p => p.Id == item.Id);
        if (entity is null)
        {
            return Guid.Empty;
        }
        entity = item;
        return entity.Id;
    }

    public T? GetItemById(Guid id)
    {
        var entity = Items.FirstOrDefault(p => p.Id == id);
        return entity;
    }

    public bool IsEmpty()
    {
        return !Items.Any();
    }
}