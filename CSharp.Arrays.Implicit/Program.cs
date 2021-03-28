using System;
using System.Text.Json;

namespace CSharp.Arrays.Implicit
{
    class Program
    {
        /// <summary>
        /// Implicitly Typed Arrays Serialized to JSON
        /// </summary>
        static void Main()
        {
            var a = new[] { 1, 2, 3, 5 }; // int[]
            var b = new[] { "one", null, "three" }; // string[]

            string aJson = JsonSerializer.Serialize(a);
            Console.WriteLine(aJson);

            string bJson = JsonSerializer.Serialize(b);
            Console.WriteLine(bJson);

            // single-dimension jagged array
            var c = new[]
            {
                new[]{1,2,3,4},
                new[]{11,12,13,14}
            };

            string cJson = JsonSerializer.Serialize(c);
            Console.WriteLine(cJson);

            // jagged array of strings
            var d = new[]
            {
                new[]{"Betty", "Wilma", "Pearl", "Pebbles"},
                new[]{"Fred", "Barney", "Gazoo"}
            };

            string dJson = JsonSerializer.Serialize(d);
            Console.WriteLine(dJson);

            // implicitly-typed arrays in object initializers
            var e = new[]
            {
                new {
                    Name = " John Smith",
                    PhoneNumbers = new[] { "606-555-5555", "561-555-5555" }
                },
                new {
                    Name = " Jane Smith",
                    PhoneNumbers = new[] { "508-555-5555" }
                }
            };

            string eJson = JsonSerializer.Serialize(e);
            Console.WriteLine(eJson);
        }
    }
}
