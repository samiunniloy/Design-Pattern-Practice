using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Design_Pattern_Practice.FluentInterFace_Pattern
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerDTO
    {
        public string FullName { get; set; }
    }

    public class MapperConfig
    {
        public static IMapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.FullName,
                  opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            });

            return config.CreateMapper();
        }
    }

    public class AutoMapperExample
    {
        public static void main() 
        {
            var customer = new Customer { FirstName = "John", LastName = "Doe" };

            var mapper = MapperConfig.InitializeAutomapper();

            var customerDTO1 = mapper.Map<CustomerDTO>(customer);
            Console.WriteLine(customerDTO1.FullName); 

            var customerDTO2 = mapper.Map<Customer, CustomerDTO>(customer);
            Console.WriteLine(customerDTO2.FullName); 
            Console.ReadKey();
        }
    }
}