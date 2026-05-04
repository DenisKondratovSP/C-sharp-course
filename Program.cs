Console.OutputEncoding = System.Text.Encoding.UTF8;

var ints = new List<int> { 1, 2, 2, 3, 1, 4, 5, 3, 5 };
Console.WriteLine($"Distinct ints:    [{string.Join(", ", ints)}] -> [{string.Join(", ", CollectionUtils.Distinct(ints))}]");

var strs = new List<string> { "a", "b", "a", "c", "b", "d", "a" };
Console.WriteLine($"Distinct strings: [{string.Join(", ", strs)}] -> [{string.Join(", ", CollectionUtils.Distinct(strs))}]");

var words = new List<string> { "кот", "собака", "ёж", "лошадь", "лев", "слон", "як" };
var byLen = CollectionUtils.GroupBy(words, w => w.Length);
Console.WriteLine("\nGroupBy слов по длине:");
foreach (var pair in byLen)
    Console.WriteLine($"  {pair.Key}: [{string.Join(", ", pair.Value)}]");

var text1 = new Dictionary<string, int> { ["кот"] = 3, ["и"] = 5, ["пёс"] = 2 };
var text2 = new Dictionary<string, int> { ["кот"] = 7, ["в"] = 4, ["пёс"] = 1, ["дом"] = 6 };
var merged = CollectionUtils.Merge(text1, text2, (a, b) => a + b);
Console.WriteLine("\nMerge двух счётчиков слов (сумма при конфликте):");
foreach (var pair in merged)
    Console.WriteLine($"  {pair.Key}: {pair.Value}");

var products = new List<Product>
{
    new Product(1, "Книга", 500m),
    new Product(2, "Ноутбук", 75000m),
    new Product(3, "Кофе", 350m),
    new Product(4, "Телефон", 30000m)
};
var mostExpensive = CollectionUtils.MaxBy(products, p => p.Price);
Console.WriteLine($"\nMaxBy по цене: {mostExpensive}");

class Product
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
