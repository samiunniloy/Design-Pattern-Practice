using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.FluentInterFace_Pattern;

public class Product
{
   public string Name { get; set; }
  public  decimal Price { get; set; }
}
public class Order
{
    public List<Product> Products { get; set; } = new List<Product>();
    public Decimal TotalPrice =>Products.Sum(p => p.Price);

    public Order AddProduct(Product product)
    {
        Products.Add(product);
        return this;
    }
    public Order RemoveProduct(Product product)
    {
        Products.Remove(product);
        return this;
    }
}
public class ShoppingCartBuilder
{
    public readonly  Order order = new Order();

    public ShoppingCartBuilder AddProduct(string name, decimal price)
    {
        order.AddProduct(new Product { Name = name, Price = price });
        return this;
    }
    public ShoppingCartBuilder RemoveProduct(string name)
    {
        var product = order.Products.FirstOrDefault(p => p.Name == name);
        if (product != null)
        {
            order.RemoveProduct(product);
        }
        return this;
    }
}
public class ShoppingCart
{
    public static void main()
    {
        var cart = new ShoppingCartBuilder()
            .AddProduct("Laptop", 1000)
            .AddProduct("Mouse", 50)
            .RemoveProduct("Mouse")
            .AddProduct("Keyboard", 75);
        Console.WriteLine("Products in the cart:");
        foreach (var product in cart.order.Products)
        {
            Console.WriteLine($"{product.Name}: ${product.Price}");
        }
        Console.WriteLine($"Total Price: ${cart.order.TotalPrice}");
    }
}


