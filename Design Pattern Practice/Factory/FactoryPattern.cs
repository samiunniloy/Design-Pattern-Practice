using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.Factory;
public class FactoryPattern
{   

    public interface Icard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();

    }
    private class GoldCard : Icard
    {
        public string GetCardType() => "Gold Card";
        public int GetCreditLimit() => 50000;
        public int GetAnnualCharge() => 1000;
    }
    private class SilverCard : Icard
    {
        public string GetCardType() => "Silver Card";
        public int GetCreditLimit() => 30000;
        public int GetAnnualCharge() => 500;
    }
    private class BronzeCard : Icard
    {
        public string GetCardType() => "Bronze Card";
        public int GetCreditLimit() => 10000;
        public int GetAnnualCharge() => 200;
    }
    public static class CardFactory {
        public static Icard GetCard(string cardType)
        {
            return cardType.ToLower() switch
            {
                "gold" => new GoldCard(),
                "silver" => new SilverCard(),
                "bronze" => new BronzeCard(),
                _ => throw new ArgumentException("Invalid card type")
            };
        }
    }



    public static void Run()
    {
       Icard card = CardFactory.GetCard("Gold");
        Console.WriteLine($"Card Type: {card.GetCardType()}");
        Console.WriteLine($"Credit Limit: {card.GetCreditLimit()}");
        Console.WriteLine($"Annual Charge: {card.GetAnnualCharge()}");

    }
}

