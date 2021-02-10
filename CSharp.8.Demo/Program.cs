using System;

namespace CSharp._8.Demo
{
    /// <summary>
    /// C# 8.0 is supported on .NET Core 3.x and .NET Standard 2.1.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle
            {
                X = 4,
                Y = 5
            };            
            Console.WriteLine(r.ToString());
        }

        /// <summary>
        /// Readonly modifiers can be applied to members of a struct.  
        /// </summary>
        /// <remarks>The compiler doesn't assume get accessors don't modify 
        /// state; you must declare readonly explicitly.</remarks>
        public struct Rectangle
        {
            public double X { get; set; }
            public double Y { get; set; }
            public readonly double Area => (X * Y);
            public double Perimeter { get; set; }

            // This method signature will not compile CS1604 as readonly.
            //public readonly void CalculatePerimeter(int x, int y)
            public void CalculatePerimeter(int x, int y)
            {
                Perimeter = 2 * (x + y);
            }

            // ToString retrieves state and does not modify
            // Added readonly modifier
            public readonly override string ToString() =>
                $"({Area} is the area, {X} is the length, {Y} is the width of" +
                $" the rectangle.";
        }
    }
}
