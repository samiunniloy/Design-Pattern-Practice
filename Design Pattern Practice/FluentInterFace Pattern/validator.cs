using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Design_Pattern_Practice.FluentInterFace_Pattern;
public class person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}
public class PersonValidator:AbstractValidator<person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(p => p.Age).InclusiveBetween(18, 65).WithMessage("Age must be between 18 and 65.");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Invalid email format.");
    }
}
public class Validator
{
    public static void main()
    {
        var person = new person { Name = "John", Age = 30, Email = "abs@gmail.com" };
        var validator = new PersonValidator();
        var result = validator.Validate(person);
        if (result.IsValid)
        {
            Console.WriteLine("Person is valid.");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Validation error: {error.ErrorMessage}");
            }
        }
    }
 
}