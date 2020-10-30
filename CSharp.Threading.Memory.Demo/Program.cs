using System;
using System.Threading;

namespace CSharp.Threading.Memory.Demo
{
    class Program
    {
        static void Main()
        {
            // Worker thread
            new Thread(Print).Start();

            // Main thread
            Print();
        }

        /// <summary>
        /// Multiple threads do not change the 
        /// the local i variable.
        /// </summary>
        private static void Print()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i + 1 + " ");
            }
        }
    }
}
