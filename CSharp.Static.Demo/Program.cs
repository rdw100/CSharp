using System;

namespace CSharp.Static.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Company name = " + Customer.GetName());
        }

        static class Customer
        {
            public static string GetName() { return "Buffalo Trace"; }
        }
    }
}
