using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.FactoryMethod;
public interface convertor
{
    string Convert(string input);
}
public class UpperCaseConvertor : convertor
{
    public string Convert(string input)
    {
        return input.ToUpper();
    }
}
public class LowerCaseConvertor : convertor
{
    public string Convert(string input)
    {
        return input.ToLower();
    }
}
public abstract class ConvertorFactory
{
    public abstract convertor CreateConvertor();
}
public class UpperCaseConvertorFactory : ConvertorFactory
{
    public override convertor CreateConvertor()
    {
        return new UpperCaseConvertor();
    }
}
public class LowerCaseConvertorFactory : ConvertorFactory
{
    public override convertor CreateConvertor()
    {
        return new LowerCaseConvertor();
    }
}
public class ConvertorClient
{
    public void ConvertText(ConvertorFactory factory, string text)
    {
        convertor convertor = factory.CreateConvertor();
        string result = convertor.Convert(text);
        Console.WriteLine("Converted Text: " + result);
    }
}
public class DocumentConvertor
{
    public static void main()
    {
        ConvertorClient client = new ConvertorClient();
        ConvertorFactory upperCaseFactory = new UpperCaseConvertorFactory();
        client.ConvertText(upperCaseFactory, "Hello World");
        ConvertorFactory lowerCaseFactory = new LowerCaseConvertorFactory();
        client.ConvertText(lowerCaseFactory, "Hello World");
    }
}
