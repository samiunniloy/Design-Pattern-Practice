using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.ProtoType_Pattern;
public abstract class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public string Type { get; set; }
    public abstract Employee GetClone();
    public abstract void ShowDetails();
}
public class PermanentEmployee : Employee
{
    public int Salary { get; set; }
    public override Employee GetClone()
    {

        return (PermanentEmployee)this.MemberwiseClone();
    }
    public override void ShowDetails()
    {
        Console.WriteLine("Permanent Employee");
        Console.WriteLine($" Name:{this.Name}, Department: {this.Department}, Type:{this.Type}, Salary: {this.Salary}\n");
    }
}
public class TemporaryEmployee : Employee
{
    public int FixedAmount { get; set; }
    public override Employee GetClone()
    {
        return (TemporaryEmployee)this.MemberwiseClone();
    }
    public override void ShowDetails()
    {
        Console.WriteLine("Temporary Employee");
        Console.WriteLine($" Name:{this.Name}, Department: {this.Department}, Type:{this.Type}, FixedAmount: {this.FixedAmount}\n");
    }
}
public class EmployeePrototypePattern
{
   public  static void main()
    {
        // Creating an Instance of Permanent Employee Class
        Employee emp1 = new PermanentEmployee()
        {
            Name = "Anurag",
            Department = "IT",
            Type = "Permanent",
            Salary = 100000
        };
        //Creating a Clone of the above Permanent Employee
        Employee emp2 = emp1.GetClone();
        // Changing the Name and Department Property Value of emp2 instance, 
        // will not change the Name and Department Property Value of the emp1 instance
        emp2.Name = "Pranaya";
        emp2.Department = "HR";
        emp1.ShowDetails();
        emp2.ShowDetails();
        // Creating an Instance of Temporary Employee Class
        Employee emp3 = new TemporaryEmployee()
        {
            Name = "Preety",
            Department = "HR",
            Type = "Temporary",
            FixedAmount = 200000
        };
        //Creating a Clone of the above Temporary Employee
        Employee emp4 = emp3.GetClone();
        // Changing the Name and Department Property Value of emp4 instance, 
        // will not change the Name and Department Property Value of the emp3 instance
        emp4.Name = "Priyanka";
        emp4.Department = "Sales";
        emp3.ShowDetails();
        emp4.ShowDetails();

        Console.Read();
    }
}