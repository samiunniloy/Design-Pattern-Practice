using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.SingleTon;
public sealed class Singleton
{
    //This variable value will be increment by 1 each time the object of the class is created
    private static int Counter = 0;
    //This variable is going to store the Singleton Instance
    private static Singleton Instance = null;
    //The following Static Method is going to return the Singleton Instance
    public static Singleton GetInstance()
    {
        //This is not thread-safe
        if (Instance == null)
        {
            Instance = new Singleton();
        }
        //Return the Singleton Instance
        return Instance;
    }

    private Singleton()
    {
        //Each Time the Constructor is called, increment the Counter value by 1
        Counter++;
        Console.WriteLine("Counter Value " + Counter.ToString());
    }
    //The following method can be accessed from outside of the class by using the Singleton Instance
    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
    }
}
class ThreadNotSafeSingleton
{
    //Example to Understand Thraed-Safe Problem with Singleton Design Pattern
    //When use in a Multithreaded Environment
    public static void main()
    {
        //The following Code will Invoke both methods Parallely using two different Threads
        Parallel.Invoke(
            //Let us Assume PrintTeacherDetails method is Invoked by Thread-1
            () => PrintTeacherDetails(),
            //Let us Assume PrintStudentDetails method is Invoked by Thread-2
            () => PrintStudentDetails()
            );
        Console.ReadLine();
    }
    private static void PrintTeacherDetails()
    {
        //Thread-1 Calling the GetInstance() Method of the Singleton class
        Singleton fromTeacher = Singleton.GetInstance();
        fromTeacher.PrintDetails("From Teacher");
    }
    private static void PrintStudentDetails()
    {
        //At the same time, Thread-2 also Calling the GetInstance() Method of the Singleton Class
        Singleton fromStudent = Singleton.GetInstance();
        fromStudent.PrintDetails("From Student");
    }
}