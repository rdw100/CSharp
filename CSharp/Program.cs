using System;
using System.Dynamic;

namespace CSharp.ReferenceTypes.Demo
{
    /// <summary>
    /// Reference types are objects that store references to the data.
    /// </summary>
    /// <examples>
    /// Examples of reference types are Class, Interface, delegate, object & string (& Dynamic)
    /// </example>
    public class Program : IBook
    {
        // Object
        static object Book { get; set; } = "Domain-Driven Design: Tackling Complexity in the Heart of Software";

        // Delegate
        delegate void fctnPntr(string value);

        static void Main(string[] args)
        {
            // Declare an interface instance.
            IBook book = new Program();
            
            // Call the member.
            book.WriteBook();

            // Assign class to dynamic type for run-time compiler check
            dynamic pub = new Publisher(1);
            Console.WriteLine(pub.ToString());
        }

        // Explicit interface member implementation:
        void IBook.WriteBook()
        {
            // Invoke delegate
            fctnPntr f = x => Console.WriteLine(x);
            f.Invoke(Book.ToString());
        }
    }

    public interface IBook
    {       
       void WriteBook();
    }

    public class Publisher
    {
        public int PublisherId { get; set; }

        public Publisher(int Id) 
        {
            PublisherId = Id;            
        }

        public override String ToString()
        {
            return $"Initializing dynamic runtime identifier as " + PublisherId + ".";
        }
    }
}
