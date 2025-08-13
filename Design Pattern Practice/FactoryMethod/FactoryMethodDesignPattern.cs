using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.FactoryMethod;
public interface CreditCard
{
    string GetCardType();
    int GetCreditLimit();
    int GetAnnualCharge();
}
public class MoneyBack : CreditCard
{
    public string GetCardType()
    {
        return "MoneyBack";
    }
    public int GetCreditLimit()
    {
        return 15000;
    }
    public int GetAnnualCharge()
    {
        return 500;
    }
}
public class Titanium : CreditCard
{
    public string GetCardType()
    {
        return "Titanium Edge";
    }
    public int GetCreditLimit()
    {
        return 25000;
    }
    public int GetAnnualCharge()
    {
        return 1500;
    }
}
public class Platinum : CreditCard
{
    public string GetCardType()
    {
        return "Platinum Plus";
    }
    public int GetCreditLimit()
    {
        return 35000;
    }
    public int GetAnnualCharge()
    {
        return 2000;
    }
}
public abstract class CreditCardFactory
{
    protected abstract CreditCard MakeProduct();
    public CreditCard CreateProduct()
    {
        CreditCard creditCard = this.MakeProduct();
        return creditCard;
    }
}
public class PlatinumFactory : CreditCardFactory
{   protected override CreditCard MakeProduct()
    {
        CreditCard product = new Platinum();
        return product;
    }
}
public class MoneyBackFactory : CreditCardFactory
{
    
    protected override CreditCard MakeProduct()
    {
        CreditCard product = new MoneyBack();
        return product;
    }
}
public class TitaniumFactory : CreditCardFactory
{
       protected override CreditCard MakeProduct()
       {
        CreditCard product = new Titanium();
        return product;
       }
}
public class FactoryMethodDesignPattern
{
    public static void main()
    {
         CreditCard creditCard = new PlatinumFactory().CreateProduct();
        if (creditCard != null)
        {
            Console.WriteLine("Card Type : " + creditCard.GetCardType());
            Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
            Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
        }
        else
        {
            Console.Write("Invalid Card Type");
        }
        Console.WriteLine("--------------");
        creditCard = new MoneyBackFactory().CreateProduct();
        if (creditCard != null)
        {
            Console.WriteLine("Card Type : " + creditCard.GetCardType());
            Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
            Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
        }
        else
        {
            Console.Write("Invalid Card Type");
        }
        Console.ReadLine();
    }
}