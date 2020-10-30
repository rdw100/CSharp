using System;

namespace CSharp.Benchmark.Demo
{
    class Program
    {
        static void Main()
        {
            Benchmark bench = new Benchmark("Execute", 10000, () => { });
            bench.Run();
        }
    }
}
