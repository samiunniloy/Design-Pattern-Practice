using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.Builder_Design_Pattern;
public class Drink
{
    public string milk { get; set; }
    public string sugar { get; set; }
    public string powder { get; set; }
    public void DisplayBeverages()
    {
        Console.WriteLine("Sugar Added: ");
        Console.WriteLine("Milk Added: ");
        Console.WriteLine("Powder Added: ");
    }
}
public abstract  class DrinkBuilder
{
    protected Drink drink;
    public abstract void AddMilk();
    public abstract void AddSugar();
    public abstract void AddPowder();
    public abstract Drink  GetDrink();
}
public class TeaBuilder : DrinkBuilder
{
    public TeaBuilder()
    {
        drink = new Drink();
    }
    public override void AddMilk()
    {
        drink.milk = "Tea Milk";
    }
    public override void AddSugar()
    {
        drink.sugar = "Tea Sugar";
    }
    public override void AddPowder()
    {
        drink.powder = "Tea Powder";
    }
    public override Drink GetDrink()
    {
        return drink;
    }
}
public class CoffeeBuilder : DrinkBuilder
{
    public CoffeeBuilder()
    {
        drink = new Drink();
    }
    public override void AddMilk()
    {
        drink.milk = "Coffee Milk";
    }
    public override void AddSugar()
    {
        drink.sugar = "Coffee Sugar";
    }
    public override void AddPowder()
    {
        drink.powder = "Coffee Powder";
    }
    public override Drink GetDrink()
    {
        return drink;
    }
}
public class DrinkDirector
{
    private readonly DrinkBuilder _drinkBuilder;
    public DrinkDirector(DrinkBuilder drinkBuilder)
    {
        _drinkBuilder = drinkBuilder;
    }
    public void ConstructDrink()
    {
        _drinkBuilder.AddMilk();
        _drinkBuilder.AddSugar();
        _drinkBuilder.AddPowder();
    }
    public Drink GetDrink()
    {
        return _drinkBuilder.GetDrink();
    }
}
public class TeaAndCoffee
{
    public static void main()
    {
        // Tea
        DrinkBuilder teaBuilder = new TeaBuilder();
        DrinkDirector teaDirector = new DrinkDirector(teaBuilder);
        teaDirector.ConstructDrink();
        Drink tea = teaDirector.GetDrink();
        Console.WriteLine("Tea:");
        Console.WriteLine($"Milk: {tea.milk}, Sugar: {tea.sugar}, Powder: {tea.powder}");
        // Coffee
        DrinkBuilder coffeeBuilder = new CoffeeBuilder();
        DrinkDirector coffeeDirector = new DrinkDirector(coffeeBuilder);
        coffeeDirector.ConstructDrink();
        Drink coffee = coffeeDirector.GetDrink();
        Console.WriteLine("Coffee:");
        Console.WriteLine($"Milk: {coffee.milk}, Sugar: {coffee.sugar}, Powder: {coffee.powder}");
    }
}
