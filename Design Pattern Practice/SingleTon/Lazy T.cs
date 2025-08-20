using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.SingleTon;
public class LazySingleTon
{
    public int counter = 0;
    private static readonly Lazy<LazySingleTon> instance = new Lazy<LazySingleTon>(() => new LazySingleTon());

    public static LazySingleTon Instance()
    {
        return instance.Value;
    }
    private LazySingleTon()
    {
        counter++;
    }
    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Counter Value: " + counter);
    }
}
class LazySafeSingleton
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
        LazySingleTon fromTeacher = LazySingleTon.Instance();
        fromTeacher.PrintDetails("From Teacher");
    }
    private static void PrintStudentDetails()
    {
        LazySingleTon fromStudent = LazySingleTon.Instance();
        fromStudent.PrintDetails("From Student");
    }
}
