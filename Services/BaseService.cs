using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Services;

// Shared logic for every service, so each service only has to say how its data is loaded
public abstract class BaseService<T>(IStorageProvider db) : IService<T> where T : class, IStorageObject
{
    protected IStorageProvider Db { get; } = db;

    private List<T>? _items;

    // Read from disk the first time, then keep the list in memory
    private List<T> Items => _items ??= Load();

    // Each class is saved in its own folder, so every service reads the folders it needs
    protected abstract List<T> Load();

    // Fills in objects that are only saved as ids, like a teacher's courses. Does nothing by default.
    protected virtual void LinkRelated(T item) { }

    public List<T> GetAll()
    {
        foreach (var item in Items)
        {
            LinkRelated(item);
        }
        return [.. Items];
    }

    // Only one kind, e.g. GetAll<RemoteCourse>()
    public List<TSub> GetAll<TSub>() where TSub : T => GetAll().OfType<TSub>().ToList();

    public T GetSingle(string id)
    {
        foreach (var item in GetAll())
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        throw new KeyNotFoundException($"{typeof(T).Name} with id {id} was not found");
    }

    public void Create(T obj)
    {
        if (Items.Any(item => item.Id == obj.Id))
        {
            throw new InvalidOperationException($"{typeof(T).Name} with id {obj.Id} already exists");
        }
        Save(obj);
    }

    public void Update(T obj) => Save(obj);

    public void Delete(string id)
    {
        Db.Delete(id);
        _items = null;
    }

    private void Save(T obj)
    {
        Db.Save(obj);
        // Load again next time so the list matches the files
        _items = null;
    }
}
