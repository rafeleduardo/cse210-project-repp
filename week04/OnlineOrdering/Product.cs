namespace OnlineOrdering;

public class Product
{
    public string Name { get; }
    public string ProductId { get; }
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}