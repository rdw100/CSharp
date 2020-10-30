using System;
using System.Diagnostics;

namespace CSharp.Benchmark.Demo
{
    public class Benchmark
    {
        public string Name { get; set; }
        public int Iterations { get; set; }
        public Action Action { get; set; }

        public Benchmark(string name, int iterations, Action action)
        {
            Name = name;
            Iterations = iterations;
            Action = action;
        }

        public void Run()
        {
            try
            {
                Console.Write($"Running benchmark '{Name}' for {Iterations} iterations... ");

                Setup(Action);

                // Run the benchmark.
                Stopwatch watch = Stopwatch.StartNew();

                for (int i = 0; i < Iterations; i++)
                {
                    Console.WriteLine("test" + i);
                }

                watch.Stop();

                // Output results.
                Console.WriteLine($"Elapsed time {watch.ElapsedMilliseconds + "ms. " + Iterations} times.");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine($"Out of memory!");
            }
        }

        private void Setup(Action action)
        {
            // Perform garbage collection.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            // Force JIT compilation of the method.
            action.Invoke();
        }
    }
}
