using System;

public class Product
{
    private string _productName;
    private string _productID;
    private int _pricePerUnit;
    private int _quantity;

    public Product(string productName, string productID, int pricePerUnit, int quantity)
    {
        _productName = productName;
        _productID = productID;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }
    public int TotalCost()
    {
        return _pricePerUnit * _quantity;
    }
    public void SetProductName(string productName)
    {
        _productName = productName;
    }
    public string GetProductName()
    {
        return _productName;
    }
    public void SetProductID(string productID)
    {
        _productID = productID;
    }
    public string GetProductID()
    {
        return _productID;
    }
    public void SetPricePerUnit(int pricePerUnit)
    {
        _pricePerUnit = pricePerUnit;
    }
    public int GetPricePerUnit()
    {
        return _pricePerUnit;
    }
    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
}