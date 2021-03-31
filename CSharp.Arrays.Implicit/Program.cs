using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CSharp.Arrays.Implicit
{
    public class Program
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

            string lJson = jJson + "," + kJson;
            Console.WriteLine(lJson);

            List<Col> cols = new List<Col>()
            {
                new Col { id = "lengthincm", label = "Lengthincm", type = "number" },
                new Col { id = "p3", label = "P3", type = "number" },
                new Col { id = "p15", label = "P15", type = "number" },
                new Col { id = "p50", label = "P50", type = "number" },
                new Col { id = "p85", label = "P85", type = "number" },
                new Col { id = "p97", label = "P97", type = "number" },
                new Col { id = "score", label = "Score", type = "number" },
            };

            string mJson = JsonSerializer.Serialize(cols);
            Console.WriteLine(mJson);

            // List to 2d array w / ctor
            List<Row> rows = new List<Row>() { 
                new Row(1, 2, 3, 4, 5, 6, 7 ),
                new Row(8, 9, 10, 11, 12, 13, 14 ),
                new Row(15, 16, 17, 18, 19, 20, 21 ),
                new Row(22, 23, 24, 25, 26, 27, 28 ),
                new Row(29, 30, 31, 32, 33, 34, 35 )
            };
            string nJson = JsonSerializer.Serialize(rows);
            Console.WriteLine("List w / ctor: " + nJson);

            // Load list into 2d Object array with LINQ
            List<List<int>> lst = new List<List<int>>();
            int[][] arrayList = lst.Select(a => a.ToArray()).ToArray();

            // 2d Object array
            object[,] array2D = new object[rows.Count, 7];
            for (int i = 0; i < rows.Count; i++)
            {
                array2D[i, 0] = rows[i].Lengthincm;
                array2D[i, 1] = rows[i].P3;
                array2D[i, 2] = rows[i].P15;
                array2D[i, 3] = rows[i].P50;
                array2D[i, 4] = rows[i].P85;
                array2D[i, 5] = rows[i].P85;
                array2D[i, 6] = rows[i].Score;
            }

            Console.WriteLine("2d Array: " + array2D[0, 0]);

            // C# Nested List serialized into 2d array.
            List<List<int>> oModel = new List<List<int>>();
            oModel.Add(new List<int>() { 1, 2, 3 });
            oModel.Add(new List<int>() { 1, 2, 3 });
            string oJson = JsonSerializer.Serialize(oModel);

            Console.WriteLine("Nested List: " + oJson);

            int[,] pModel = new int[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } };

            // C# Nested Typed List serialized into 2d array.
            List<List<Row>> nestedRows = new List<List<Row>>();
            nestedRows.Add(new List<Row>(rows));
            nestedRows.Add(new List<Row>() { new Row(36, 37, 38, 39, 40, 41, 42) });
            nestedRows.Add(new List<Row>() { new Row(43, 44, 45, 46, 47, 48, 49) });
            nestedRows.Add(new List<Row>() { new Row(50, 51, 52, 53, 54, 55, 56) });
            string pJson = JsonSerializer.Serialize(nestedRows);
            Console.WriteLine("Nested Typed List: " + pJson);
        }
    }

    public static class EnumerableExtensions
    {
        public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source)
        {
            var data = source
                .Select(x => x.ToArray())
                .ToArray();

            var res = new T[data.Length, data.Max(x => x.Length)];
            for (var i = 0; i < data.Length; ++i)
            {
                for (var j = 0; j < data[i].Length; ++j)
                {
                    res[i, j] = data[i][j];
                }
            }

            return res;
        }
    }

    public class CDataTable
    {
        public List<Col> cols { get; set; }
        public List<List<Row>> rows { get; set; }
    }

    public class Col
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
    }

    public class Row
    {
        public Row(decimal lengthincm, decimal p3, decimal p15, decimal p50, decimal p85, decimal p97, decimal? score)
        {
            Lengthincm = lengthincm;
            P3 = p3;
            P15 = p15;
            P50 = p50;
            P85 = p85;
            P97 = p97;
            Score = score;
        }

        public decimal Lengthincm { get; set; }
        public decimal P3 { get; set; }
        public decimal P15 { get; set; }
        public decimal P50 { get; set; }
        public decimal P85 { get; set; }
        public decimal P97 { get; set; }
        public decimal? Score { get; set; }
    }
}