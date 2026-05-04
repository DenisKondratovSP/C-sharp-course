Console.OutputEncoding = System.Text.Encoding.UTF8;

var products = new Repository<Product>();
products.Add(new Product(1, "Книга", 500m));
products.Add(new Product(2, "Ноутбук", 75000m));
products.Add(new Product(3, "Кофе", 350m));
products.Add(new Product(4, "Телефон", 30000m));

Console.WriteLine($"Всего продуктов: {products.Count}");

Console.WriteLine("\nВсе продукты:");
foreach (var p in products.GetAll())
    Console.WriteLine($"  {p}");

Console.WriteLine($"\nGetById(2): {products.GetById(2)}");
Console.WriteLine($"GetById(99): {products.GetById(99)?.ToString() ?? "null"}");

Console.WriteLine("\nПродукты дороже 1000:");
foreach (var p in products.Find(p => p.Price > 1000))
    Console.WriteLine($"  {p}");

Console.WriteLine("\nПопытка добавить дубликат (Id=1):");
try
{
    products.Add(new Product(1, "Дубликат", 999m));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"  Исключение: {ex.Message}");
}

Console.WriteLine($"\nRemove(3) -> {products.Remove(3)}, продуктов: {products.Count}");
Console.WriteLine($"Remove(3) ещё раз -> {products.Remove(3)}");

var users = new Repository<User>();
users.Add(new User(1, "Аня"));
users.Add(new User(2, "Боря"));
users.Add(new User(3, "Вика"));

Console.WriteLine($"\nRepository<User>. Всего: {users.Count}");
foreach (var u in users.GetAll())
    Console.WriteLine($"  {u}");
