using System;
using System.Threading;
using System.Threading.Tasks;

namespace Uniza.CSharp.PresentationParallel.Examples
{
    class ExampleAsyncTasks
    {
        public static void Run()
        {
            //MultipleAsyncMethods();

            //MultipleAsyncMethodsWithCombinators1();
            
            //MultipleAsyncMethodsWithCombinators2();
        }

        private static async void MultipleAsyncMethods()
        {
            string s1 = await GreetingAsync("Jano");
            string s2 = await GreetingAsync("Fero");
            Console.WriteLine($"Finished both methods.{Environment.NewLine} Result 1: {s1}{Environment.NewLine} Result 2: {s2}");
        }

        private static async void MultipleAsyncMethodsWithCombinators1()
        {
            Task<string> t1 = GreetingAsync("Jano");
            Task<string> t2 = GreetingAsync("Fero");
            await Task.WhenAll(t1, t2);
            Console.WriteLine($"Finished both methods.{Environment.NewLine} Result 1: {t1.Result}{Environment.NewLine} Result 2: {t2.Result}");
        }

        private static async void MultipleAsyncMethodsWithCombinators2()
        {
            Task<string> t1 = GreetingAsync("Jano");
            Task<string> t2 = GreetingAsync("Fero");
            string[] result = await Task.WhenAll(t1, t2);
            Console.WriteLine($"Finished both methods.{Environment.NewLine} Result 1: {result[0]}{Environment.NewLine} Result 2: {result[1]}");
        }

        static Task<string> GreetingAsync(string name) =>
            Task.Run(() =>
            {
                TraceThreadAndTask($"running {nameof(GreetingAsync)}");
                return Greeting(name);
            });

        static string Greeting(string name)
        {
            TraceThreadAndTask($"running {nameof(Greeting)}");
            Task.Delay(3000).Wait();
            return $"Hello, {name}";
        }

        public static void TraceThreadAndTask(string info)
        {
            string taskInfo = Task.CurrentId == null ? "no task" : "task " + Task.CurrentId;

            Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId} and {taskInfo}");
        }
    }
}
