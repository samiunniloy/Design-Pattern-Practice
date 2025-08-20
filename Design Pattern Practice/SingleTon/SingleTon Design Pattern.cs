using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.SingleTon;
public sealed class SingleTon
{
    public int counter = 0;
    private static SingleTon? instance = null;

    public static SingleTon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingleTon();
            }
            return instance;
        }
    }
    private SingleTon()
    {
        counter++;
    }
    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
    }

}