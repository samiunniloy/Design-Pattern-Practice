using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.SingleTon;

public class DoubleSafeSingleTon
{
    public static DoubleSafeSingleTon instance = null;
    public int counter = 0;
    private static readonly object lockObject = new object();
    public static DoubleSafeSingleTon Instance()
    {

        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new DoubleSafeSingleTon();
                }
            }
        }
        return instance;
    }

    private DoubleSafeSingleTon()
    {
        counter++;
    }
    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Counter Value: " + counter);
    }
}
class DoubleThreadSafeSingleton
{

    public static void main()
    {
        Parallel.Invoke(
            () => PrintTeacherDetails(),
            () => PrintStudentDetails()
            );
        Console.ReadLine();
    }
    private static void PrintTeacherDetails()
    {
        DoubleSafeSingleTon fromTeacher = DoubleSafeSingleTon.Instance();
        fromTeacher.PrintDetails("From Teacher");
    }
    private static void PrintStudentDetails()
    {
        DoubleSafeSingleTon fromStudent = DoubleSafeSingleTon.Instance();
        fromStudent.PrintDetails("From Student");
    }
}