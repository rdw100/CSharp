using System;
using System.Threading;

namespace CSharp.Threading.Shared.Demo
{
    /// <summary>
    /// Represents a class that uses the C# lock statement to synchronize 
    /// thread access to a shared resource.
    /// </summary>
    class Program
    {
        private static bool isCompleted;

        static readonly object lockCompleted = new object();

        static void Main()
        {
            // Worker thread method (thread delegate)
            ThreadStart threadLoop = new ThreadStart(LoopOne);

            // Worker thread
            Thread thread = new Thread(threadLoop);
            thread.Name = "Alpha Worker";
            thread.Start();

            // Main thread
            LoopOne();
        }

        /// <summary>
        /// Locks code execution using a boolean to prevent repeated execution.
        /// </summary>
        public static void LoopOne()
        {
            lock (lockCompleted)
            {
                if (!isCompleted)
                {
                    isCompleted = true;

                    Console.WriteLine("This code executes only once.");
                }
            }
        }
    }
}
