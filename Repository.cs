public interface IEntity
{
    int Id { get; }
}

public class Repository<T> where T : IEntity
{
    private readonly Dictionary<int, T> items = new();

    public int Count => items.Count;

    public void Add(T item)
    {
        if (items.ContainsKey(item.Id))
            throw new InvalidOperationException($"Элемент с Id={item.Id} уже существует");
        items.Add(item.Id, item);
    }

    public bool Remove(int id) => items.Remove(id);

    public T? GetById(int id)
    {
        return items.TryGetValue(id, out var item) ? item : default;
    }

    public IReadOnlyList<T> GetAll()
    {
        return items.Values.ToList();
    }

    public IReadOnlyList<T> Find(Predicate<T> predicate)
    {
        var result = new List<T>();
        foreach (var item in items.Values)
        {
            if (predicate(item))
                result.Add(item);
        }
        return result;
    }
}

public class Product : IEntity
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString() => $"Product(Id={Id}, Name=\"{Name}\", Price={Price})";
}

public class User : IEntity
{
    public int Id { get; }
    public string Name { get; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => $"User(Id={Id}, Name=\"{Name}\")";
}
