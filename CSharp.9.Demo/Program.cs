using System;
using System.Collections.Generic;

namespace CSharp._9.Demo
{

    /// <summary>
    /// C# 9.0 adds the following features and enhancements to the C# language.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Equality is value-based.
            var person1 = new Person("John", "Adams");
            var person2 = new Person("John", "Doe");
            // Records support copy construction.
            // Records support with expressions.
            var person3 = person1 with { LastName = "Smith" };
            // Records support with expressions to create an exact copy.
            Person clone = person3 with { };
            // The compiler produces a Deconstruct 
            // method for positional records.
            var doctor = new Provider("Doctorson", "Bill");
            var (last, first) = doctor;
            // Change the mutable record.    
            person1.LastName = "Doe";
            // Cannot change immutable record.
            //doctor.LastName = "Davies";

            Console.WriteLine(person1 == person2); // True if structurally (properties & types) equal    
            Console.WriteLine(person1.Equals(person2)); // True if structurally equal      
            Console.WriteLine(ReferenceEquals(person1, person1)); // True if same instance 
            Console.WriteLine(person1 != person3); // True if NOT equal
            Console.WriteLine(clone == person3); // True if structurally equal
            Console.WriteLine($"{first} {last}");
        }
    }

    // Record types are reference types.
    public record Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Person(string first, string last) => (FirstName, LastName) = (first, last);
    }

    // Record types can inherit.
    public record Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(string first, string last, string sub)
            : base(first, last) => Subject = sub;
    }

    // Record types can be sealed.
    public sealed record Student : Person
    {
        public int Level { get; set; }

        public Student(string first, string last, int level) 
            : base(first, last) => Level = level;
    }

    // Record type syntax can be written more concisely as a positional record.
    public record Provider(string FirstName, string LastName);

    public record Physician(string FirstName, string LastName,
    string Subject)
        : Provider(FirstName, LastName);

    public sealed record Nurse(string FirstName,
        string LastName, int Level)
        : Provider(FirstName, LastName);
}
