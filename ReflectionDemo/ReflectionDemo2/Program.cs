using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            IList<ICar> cars = new List<ICar>();

            Console.WriteLine("Select a car: ");

            foreach (Type type in types)
            {
                if(type.GetInterfaces().Contains(typeof(ICar)))
                {
                    ConstructorInfo constructor = type.GetConstructor(new Type[] { });
                    ICar car = constructor.Invoke(new object[] { }) as ICar;
                    cars.Add(car);

                    Console.WriteLine(car.Model);
                }
            }
            var selectedCarModel = Console.ReadLine();
            var selectedCar = cars.Where(c => c.Model == selectedCarModel).First();

            selectedCar.Start();

            while(true)
            {
                Console.WriteLine("Select your option: ");
                Console.WriteLine("1) SpeedUp");
                Console.WriteLine("2) SpeedDown");
                Console.WriteLine("3) Exit");

                var actionName  = Console.ReadLine();

                if (actionName == "Exit")
                    break;

                var carType = typeof(ICar);

                MethodInfo actionMethod = carType.GetMethod(actionName, 
                    new Type[] { typeof(double) });
                actionMethod.Invoke(selectedCar, new object[] { 100 });
                
                Console.WriteLine($"Current speed: {selectedCar.CurrentSpeed}");
            }
            
            //selectedCar.SpeedUp(100);
            //selectedCar.SpeedDown(100);

            
        }
    }
}
