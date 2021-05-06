using System;

namespace CSharp.Arrays.Jagged
{
    /// <summary>
    /// Illustrates the declaration and initialization of Jagged Arrays.
    /// </summary>
    /// <remarks>
    /// A jagged array is an array whose elements are arrays, possibly of 
    /// different sizes. 
    /// A jagged array is sometimes called an "array of arrays."    
    /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/jagged-arrays
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            // String array to store customer names
            string[] customerNames = new string[3];
            customerNames[0] = "John";
            customerNames[1] = "Jane";
            customerNames[2] = "James";

            // Jagged array to store customer orders
            string[][] jaggedOrders = new string[3][];

            jaggedOrders[0] = new string[3];
            jaggedOrders[1] = new string[1];
            jaggedOrders[2] = new string[2];

            // Assign values to individual array elements
            jaggedOrders[0][0] = "Chai";
            jaggedOrders[0][1] = "Ikura";
            jaggedOrders[0][2] = "Chang";

            jaggedOrders[1][0] = "Aniseed Syrup";

            jaggedOrders[2][0] = "Konbu";
            jaggedOrders[2][1] = "Tofu";

            // Loop thru customers and print orders
            for (int i = 0; i < jaggedOrders.Length; i++)
            {
                Console.WriteLine(customerNames[i]);
                Console.WriteLine("---------------");
                string[] innerArray = jaggedOrders[i];
                for (int j = 0; j < innerArray.Length; j++)
                {
                    Console.WriteLine(innerArray[j]);
                }
                Console.WriteLine();
            }
            /*  Output:
                John
                ---------------
                Chai
                Ikura
                Chang

                Jane
                ---------------
                Aniseed Syrup

                James
                ---------------
                Konbu
                Tofu
             */
        }
    }
}