using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.AbstractFactoryPattern;
public interface IBackEnd{
    public void GetDeatils();
}
public interface IFrontEnd
{
    public void GetDeatils();
}
public class BackEndOffline : IBackEnd
{
    public void GetDeatils()
    {
        Console.WriteLine("BackEndOffline Running");
    }
}
public class BackEndOnline : IBackEnd
{
    public void GetDeatils()
    {
        Console.WriteLine("BackENdOnline Running");
    }
}
public class FrontEndOffline : IFrontEnd
{
    public void GetDeatils()
    {
        Console.WriteLine("FrontEndOffline Running");
    }
}
public class FrontEndOnline : IFrontEnd
{
    public void GetDeatils()
    {
        Console.WriteLine("FrontENdOnline Running");
    }
}

public abstract class ICourseFactory
{
    public abstract IBackEnd CreateBackEnd();
    public abstract IFrontEnd CreateFrontEnd();
}
public class OfflineFactory : ICourseFactory
{
    public override IBackEnd CreateBackEnd()
    {
        return  new BackEndOffline();
    }

    public override IFrontEnd CreateFrontEnd()
    {
        return  new FrontEndOffline();
    }
}
public class OnlineFactory : ICourseFactory
{
    public override IBackEnd CreateBackEnd()
    {
        return new BackEndOnline();
    }

    public override IFrontEnd CreateFrontEnd()
    {
        return new FrontEndOnline();
    }
}

public class AbstractFactoryPatternCourse
{
    public static void main()
    {
        ICourseFactory offlineFactory = new OfflineFactory();
        IFrontEnd course=offlineFactory.CreateFrontEnd();
        course.GetDeatils();
    }
}


