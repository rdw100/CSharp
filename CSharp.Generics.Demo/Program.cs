using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSharp.Generics.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare a list of type string
            List<String> Names = new List<String>();
            Names.Add("Nicolaus Copernicus");
            Names.Add("Galileo Galilei");
            Names.Add("Isaac Newton");

            // Use a foreach or for loop to 
            // iterate a List<String> collection.
            foreach (string item in Names)
            {
                Console.WriteLine(item);
            }

            // Declare a list of type customer
            // Use simplified instantiation
            List<Customer> Customers = new List<Customer>
            {
                new Customer("Johannes Kepler"),
                new Customer("‎Aristarchus of Samos"),
                new Customer("Domenico Maria Novara")
            };

            // Use a foreach or for loop to 
            // iterate a List<String> collection
            // using a lambda expression
            Customers.ForEach(c => Console.WriteLine(c.Name));
        }
    }

    public class Customer
    {
        public string Name {get; set;}
        public Customer (string name)
        {
            Name = name;
        }
    }
}
