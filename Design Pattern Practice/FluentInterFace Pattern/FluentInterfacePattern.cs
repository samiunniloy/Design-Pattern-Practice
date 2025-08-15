using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Practice.FluentInterFace_Pattern;
public class Employee
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Department { get; set; }
    public string Address { get; set; }
}

public class FluentEmployee
{
        private Employee employee = new Employee();
        public FluentEmployee NameOfTheEmployee(string FullName)
        {
            employee.FullName = FullName;
            return this;
        }
        public FluentEmployee Born(string DateOfBirth)
        {
            employee.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            return this;
        }
        public FluentEmployee WorkingOn(string Department)
        {
            employee.Department = Department;
            return this;
        }
        public FluentEmployee StaysAt(string Address)
        {
            employee.Address = Address;
            return this;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Name: {employee.FullName}, \nDateOfBirth: {employee.DateOfBirth}, \nDepartment: {employee.Department}, \nAddress: {employee.Address}");
        }
}

public class FluentInterfacePattern
{
   public static void main()
    {
        FluentEmployee obj = new FluentEmployee();
        obj.NameOfTheEmployee("Anurag Mohanty")
                .Born("10/10/1992")
                .WorkingOn("IT")
                .StaysAt("Mumbai-India");
        obj.ShowDetails();
        Console.Read();
    }
}
