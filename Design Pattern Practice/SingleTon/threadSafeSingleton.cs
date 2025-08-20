using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.SingleTon;
public class SafeSingleTon
{
    public static SafeSingleTon instance = null;
    public int counter = 0;
    private static readonly object lockObject = new object();
    public static SafeSingleTon Instance()
    {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new SafeSingleTon();
                }
            }
             return instance;
    }

    private SafeSingleTon()
    {
        counter++;
    }
    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Counter Value: " + counter);
    }
}
class ThreadSafeSingleton
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
        SafeSingleTon fromTeacher = SafeSingleTon.Instance();
        fromTeacher.PrintDetails("From Teacher");
    }
    private static void PrintStudentDetails()
    {
        SafeSingleTon fromStudent = SafeSingleTon.Instance();
        fromStudent.PrintDetails("From Student");
    }
}
