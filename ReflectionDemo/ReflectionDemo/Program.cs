using System;

namespace ReflectionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var product = new Product { Name = "Book", Price = 100.5M };
            var person = new Person { Id = 101, Name = "Rakib" };

            Print(product);
            Print(person);
        }

        private static void Print(object item)
        {
            Type type = item.GetType();
            var properties = type.GetProperties();
            Console.WriteLine($"{type.Name}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} ({property.PropertyType}) = {property.GetValue(item)}");
            }
            Console.WriteLine("_____________________________");
        }
    }
}
