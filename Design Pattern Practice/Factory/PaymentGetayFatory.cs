using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.Factory;

public interface IPaymentGetway
{
    public void ProcessPayement(string amount);

}
public class Paypal : IPaymentGetway
{
    public void ProcessPayement(string amount)
    {
        Console.WriteLine(amount+ "paid by paypal");
    }
}
public class Stripe : IPaymentGetway
{
    public void ProcessPayement(string amount) {
        Console.WriteLine(amount + "paid by Stripe");
    }
}

public class Card : IPaymentGetway
{
    public void ProcessPayement(string amount)
    {
        Console.WriteLine(amount + "paid by Card");
    }
}

public static class GetwayFactory{
    
    public static IPaymentGetway GetGetway(string type)
    {
        return type.ToLower() switch
        {
            "paypal" => new Paypal(),
            "stripe" => new Stripe(),
            "card" => new Card(),
            _ => throw new Exception("no match")
        };
    }
}
public class PaymentGetwayFactory()
{
    public static void main()
    {
        Console.WriteLine("Select the payment gateway (PayPal, Stripe, CreditCard): ");
        string gatewayName = Console.ReadLine();
        IPaymentGetway getWay=GetwayFactory.GetGetway(gatewayName);
        getWay.ProcessPayement(gatewayName);

    }

}
