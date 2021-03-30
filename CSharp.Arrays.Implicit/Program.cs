using System;
using System.Collections.Generic;
using System.Linq;
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
            int[][] c = new[]
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

            // Explicitly typed array; Printing contents of array in C#
            // converts List to array
            List<string> list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");

            string[] array = list.ToArray();

            string gJson = JsonSerializer.Serialize(array);
            Console.WriteLine(gJson);
            
            // c# add element to array
            string[] arrays = new[] { "zero" };
            foreach (string item in list)
            {
                arrays = arrays.Concat(new[] { item }).ToArray();
            }

            string hJson = JsonSerializer.Serialize(arrays);
            Console.WriteLine(hJson);

            // Multidimensional Arrays
            string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            //string iJson = JsonSerializer.Serialize(array2Db);
            //Console.WriteLine(iJson);

            // Implicitly-typed arrays, Mixed Dimension
            var j = new[]
            {
                new{ id = "lengthincm", label = "Lengthincm", type = "number" },
                new { id = "p3", label = "P3", type = "number" },
                new { id = "p15", label = "P15", type = "number" },
                new { id = "p50", label = "P50", type = "number" },
                new { id = "p85", label = "P85", type = "number" },
                new { id = "p97", label = "P97", type = "number" },
                new { id = "score", label = "Score", type = "number" }
            };

            var k = new[]
            {
                new[]{1,2,3,4,5,6,7},
                new[]{8,9,10,11,12,13,14},
                new[]{15,16,17,18,19,20,21},
                new[]{22,23,24,25,26,27,28},
                new[]{29,30,31,32,33,34,35}
            };

            string jJson = JsonSerializer.Serialize(j);
            Console.WriteLine(jJson);

            string kJson = JsonSerializer.Serialize(k);
            Console.WriteLine(kJson);
        }
    }    
}
