namespace Popkultulista.App.Abstract;

public interface IService<T>
{
    List<T> Items { get; set; }

    List<T> GetAllItems();

    T? GetItemById(Guid id);

    Guid AddItem(T item);

    Guid UpdateItem(T item);

    void RemoveItem(T item);

    bool IsEmpty();
}