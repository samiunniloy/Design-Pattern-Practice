using System;
namespace PrototypeDesignPattern
{
   public class Cloning
    {
      public  static void main()
        {
            // Creating an Instance of Employee Class
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";

            // Instead of using Assignment Operator, now use the Clone method to create a Cloned Object
            // Both emp1 and emp2 having different Memory Address
            Employee emp2 = emp1.GetClone();

            // Changing the Name Property Value of emp2 instance, 
            // will not change the Name Property Value of emp1 instance
            emp2.Name = "Pranaya";

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Department: " + emp1.Department);
            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Department: " + emp2.Department);

            Console.Read();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee GetClone()
        {
            // MemberwiseClone Method Creates a shallow copy of the current System.Object
            // So typecast the Object Appropriate Type
            // In this case, typecast to Employee type
            return (Employee)this.MemberwiseClone();
        }
    }
}