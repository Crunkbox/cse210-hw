using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public int TotalPrice()
    {
        int total = _products.Sum(product => product.TotalCost());
        total += _customer.Domestic() ? 5 : 35;
        return total;
    }
    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(p => $"{p.GetProductName()} ({p.GetProductID()})"));
    }
    public string GetShippingLabel()
    {
        return $"{_customer.GetCustomerName()}\n{_customer.GetAddress().FullAddress()}";
    }
}