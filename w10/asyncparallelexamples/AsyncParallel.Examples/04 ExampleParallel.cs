using System;
using System.Threading;
using System.Threading.Tasks;

namespace Uniza.CSharp.PresentationParallel.Examples
{
    class ExampleParallel
    {
        public static void Run()
        {
            //ParallelInvoke();

            //ParallelForEach();

            //ParallelFor();

            //ParallelForWithAsync();

            //ParallelForWithInit();

            //StopParallelForEarly();
        }

        public static void ParallelInvoke()
        {
            // Paralelne zavolanie dvoch metod sucasne 
            // V jednom behu sa moze vypisat najskor prva metoda - method1, v inom spusteni druha - method2
            Parallel.Invoke(Method1, Method2);
        }

        private static void Method1() =>
            Console.WriteLine("method1");

        private static void Method2() =>
            Console.WriteLine("method2");

        public static void ParallelForEach()
        {
            string[] data = {"zero", "one", "two", "three", "four", "five",
                "six", "seven", "eight", "nine", "ten", "eleven", "twelve"};

            // Klasicky foreach
            //foreach (var s in data)
            //{
            //    Console.WriteLine(s);
            //}

            // Paralelny foreach
            Parallel.ForEach(data, s =>
            {
                Console.WriteLine(s);
            });
        }

        public static void ParallelFor()
        {
            ParallelLoopResult result =
                Parallel.For(0, 100, i =>
                {
                    Log($"Number: {i,2} - Start");
                    Task.Delay(10).Wait();
                    Log($"Number: {i,2} - End  ");
                });

            Console.WriteLine($"Is completed: {result.IsCompleted}");
        }

        public static void ParallelForWithAsync()
        {
            // Pouzitie async a await v tele delegata
            ParallelLoopResult result =
                Parallel.For(0, 100, async i =>
                {
                    Log($"Number: {i,2} - Start");
                    await Task.Delay(10);
                    Log($"Number: {i,2} - End  ");
                });

            Console.WriteLine($"Is completed: {result.IsCompleted}");
        }

        public static void ParallelForWithInit()
        {
            // 3 bloky - inicializacny, telo, finalizacny
            Parallel.For<string>(0, 10, () =>
            {
                // invoked once for each thread
                Log("init thread");
                return $"t{Thread.CurrentThread.ManagedThreadId}"; // Hodnota sa preda do str1
            },
            (i, pls, str1) =>
            {
                // invoked for each member
                Log($"body i = {i} str1 = {str1}");
                Task.Delay(10).Wait();
                return $"i{i}"; // Hodnota sa preda do str2
            },
            (str2) =>
            {
                // final action on each thread
                Log($"finally {str2}");
            });
        }

        public static void StopParallelForEarly()
        {
            // Priklad pouzitia break
            ParallelLoopResult result =
                Parallel.For(10, 40, (int i, ParallelLoopState pls) =>
                {
                    Log($"i = {i,2} - Start");
                    if (i > 12)
                    {
                        pls.Break();
                        Log($"break now {i}");
                    }

                    Task.Delay(10).Wait();
                    Log($"i = {i,2} - End");
                });

            Console.WriteLine($"Is completed: {result.IsCompleted}");
            Console.WriteLine($"Lowest break iteration: {result.LowestBreakIteration}");
        }

        public static void Log(string prefix) =>
            Console.WriteLine($"{prefix} (task: {Task.CurrentId,3}, thread: {Thread.CurrentThread.ManagedThreadId,3})");
    }
}
