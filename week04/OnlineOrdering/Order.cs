namespace OnlineOrdering;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const decimal UsaShippingCost = 5.0m;
    private const decimal InternationalShippingCost = 35.0m;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal productTotal = _products.Sum(p => p.GetTotalCost());
        decimal shippingCost = _customer.LivesInUSA() ? UsaShippingCost : InternationalShippingCost;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(p => $"Product: {p.Name} (ID: {p.ProductId})"));
    }

    public string GetShippingLabel()
    {
        return $"Customer: {_customer.Name}\n{_customer.Address}";
    }
}