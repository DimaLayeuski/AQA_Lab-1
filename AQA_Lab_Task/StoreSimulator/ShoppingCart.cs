namespace StoreSimulator;

public class ShoppingCart
{
    private readonly List<Goods?> _storage;

    public ShoppingCart()
    {
        _storage = new List<Goods?>();
    }

    public void AddProduct(Goods? product)
    {
        _storage.Add(product);
    }

    public void AddProductsList(IEnumerable<Goods?>? product)
    {
        _storage.AddRange(product!);
    }

    public void RemoveProduct(int index)
    {
        _storage.RemoveAt(index);
    }

    public void PrintShoppingCartSummary()
    {
        _storage.ForEach(product => Console.WriteLine($"{product!.GoodsName} || {product.Category} || {product.BarcodeId} || {product.Price:F} $"));
        var sum = _storage.Sum(product => product!.Price);
        Console.WriteLine($"\nSum: {sum} $");
    }
}