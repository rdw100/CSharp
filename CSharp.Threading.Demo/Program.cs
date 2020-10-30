using System;
using System.Threading;

namespace CSharp.Threading.Demo
{
    /// <summary>
    /// Represents a program executing multiple threads.
    /// </summary>
    /// <remarks>
    /// Threads Windows = Debug -> Windows -> Threads
    /// Diagnostic Tools displays CPU Memory etc.
    /// </remarks>
    public class Program
    {
        static void Main(string[] args)
        {
            // Worker thread method (thread delegate)
            ThreadStart threadLoop = new ThreadStart(Work.LoopOne);
            
            // Worker thread
            Thread thread = new Thread(threadLoop);
            thread.Name = "Alpha Worker";
            thread.Start();

            // Main thread
            if (thread.ThreadState == ThreadState.Running)
            {
                Console.WriteLine("Thread Running.");
            }

            // Illustrates multiple operations running parallel 
            // where the O/S is making context switching decisions
            // based on resource availability.
            Thread.CurrentThread.Name = "Zeta";

            for (int count = 1; count <= 250; count++)
            {
                Console.Write("Z: " + count + " ");
            }

            // Start another thread using threadstart delegate
            threadLoop = new ThreadStart(Work.LoopTwo);
            thread = new Thread(threadLoop);
            thread.Name = "Beta Worker";
            thread.Start();
        }
    }

    /// <summary>
    /// Represents a class with long running methods.
    /// </summary>
    class Work
    {
        /// <summary>
        /// Main thread LoopOne where work is performed.
        /// </summary>
        public static void LoopOne()
        {
            for (int count = 0; count < 500; count++)
            {
                Console.Write("A: " + count + " ");
            }
        }

        /// <summary>
        /// Main thread LoopOne where work is performed.
        /// </summary>
        public static void LoopTwo()
        {
            for (int count = 1; count <= 1000; count++)
            {
                Console.Write("B: " + count + " ");
            }
        }
    }
}
