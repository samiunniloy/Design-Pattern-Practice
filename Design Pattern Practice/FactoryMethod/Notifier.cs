using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.FactoryMethod;
public interface INotifier
{
    void Notify(string message);
}
public class EmailNotifier:INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine("Email Notification: " + message);
    }
}
public class SMSNotifier:INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine("SMS Notification: " + message);
    }
}
public class PushNotifier:INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine("Push Notification: " + message);
    }
}
public abstract class NotifierFactory {
    public abstract INotifier CreateNotifier();
}
public class EmailNotifierFactory : NotifierFactory
{
    public override INotifier CreateNotifier()
    {
        return new EmailNotifier();
    }
}
public class SMSNotifierFactory : NotifierFactory
{
    public override INotifier CreateNotifier()
    {
        return new SMSNotifier();
    }
}
public class PushNotifierFactory : NotifierFactory
{
    public override INotifier CreateNotifier()
    {
        return new PushNotifier();
    }
}
public class NotificationSystem
{
    public void NotifyUser(NotifierFactory factory, string message)
    {
        INotifier notifier = factory.CreateNotifier();
        notifier.Notify(message);
    }
}

public class Program
{
    public static void main()
    {
        var notificationSystem = new NotificationSystem();

        notificationSystem.NotifyUser(new EmailNotifierFactory(), "This is an email notification!");
       
        notificationSystem.NotifyUser(new SMSNotifierFactory(), "This is an SMS notification!");
       
        notificationSystem.NotifyUser(new PushNotifierFactory(), "This is a push notification!");
        Console.ReadKey();
    }
}
