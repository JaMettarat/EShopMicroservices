using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Person(string name, int age)
    {
        // The parameters of the primary constructor can be used to initialize fields
        public string Name { get; } = name;
        public int Age { get; } = age;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }


}
