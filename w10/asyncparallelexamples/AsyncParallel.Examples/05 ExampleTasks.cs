using System;
using System.Threading;
using System.Threading.Tasks;

namespace Uniza.CSharp.PresentationParallel.Examples
{
    class ExampleTasks
    {
        // Originalne zdrojove kody z: https://github.com/ProfessionalCSharp/ProfessionalCSharp7/tree/master/Tasks

        public static void Run()
        {
            //TaskMethod("Synchronna metoda");

            //FirstTask();

            //LongRunningTask();

            //TasksUsingThreadPool();

            // Naplanovanie uloh iducich po sebe
            //ContinuationTasks();

            //ParentAndChild();

            Console.ReadKey();
        }

        public static void TaskMethod(object o)
        {
            Log(o?.ToString());
        }

        private static readonly object LogLock = new object();

        public static void Log(string title)
        {
            // Monitor - uzamkne pristup a dovoli vstupit iba jednemu vlaknu (ostatne budu cakat na odomknutie)
            lock (LogLock)
            {
                Console.WriteLine(title);
                Console.WriteLine(
                    $"Task id: {Task.CurrentId?.ToString() ?? "no task"}, thread: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"is pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
                Console.WriteLine($"is background thread: {Thread.CurrentThread.IsBackground}");
                Console.WriteLine();
            }
        }

        public static void FirstTask()
        {
            var task1 = new Task(TaskMethod, "Moja prva uloha");
            task1.Start();
        }

        public static void LongRunningTask()
        {
            var taskLongRun1 = new Task(TaskMethod, "Uloha s dlhou zivotnostou", TaskCreationOptions.LongRunning);
            taskLongRun1.Start(); 
        }
        
        public static void TasksUsingThreadPool()
        {
            var taskFactory = new TaskFactory();
            Task task1 = taskFactory.StartNew(TaskMethod, "new TaskFactory().StartNew() uloha");

            Task task2 = Task.Factory.StartNew(TaskMethod, "Task.Factory.StartNew() uloha");

            var task3 = new Task(TaskMethod, "new Task().Start() uloha");
            task3.Start();

            Task task4 = Task.Run(() => TaskMethod("Task.Run() uloha"));
        }
        
        public static void ParentAndChild()
        {
            var parent = new Task(ParentTask);
            parent.Start();

            Task.Delay(20).Wait();
            Console.WriteLine(parent.Status);

            Task.Delay(4000).Wait();
            Console.WriteLine(parent.Status);
        }

        private static void ParentTask()
        {
            Console.WriteLine($"Task id {Task.CurrentId}");

            var child = new Task(ChildTask);
            child.Start();

            Task.Delay(1000).Wait();
            Console.WriteLine("Parent started child");
        }

        private static void ChildTask()
        {
            Console.WriteLine("Child");
            Task.Delay(5000).Wait();

            Console.WriteLine("Child finished");
        }

        public static void ContinuationTasks()
        {
            Task t1 = new Task(Method1);
            Task t2 = t1.ContinueWith(Method2);
            Task t3 = t1.ContinueWith(Method3);
            //Task t4 = t2.ContinueWith(Method2);
            t1.Start();
        }

        private static void Method1()
        {
            Console.WriteLine($"Doing some task {Task.CurrentId}");
            Console.WriteLine();

            Task.Delay(3000).Wait();
        }

        private static void Method2(Task t)
        {
            Console.WriteLine(nameof(Method2));
            Console.WriteLine($"Task {t.Id} finished");
            Console.WriteLine($"This task id {Task.CurrentId}");
            Console.WriteLine("Do some cleanup");
            Console.WriteLine();

            Task.Delay(3000).Wait();
        }

        private static void Method3(Task t)
        {
            Console.WriteLine(nameof(Method3));
            Console.WriteLine($"Task {t.Id} finished");
            Console.WriteLine($"This task id {Task.CurrentId}");
            Console.WriteLine("Do some cleanup");
            Console.WriteLine();

            Task.Delay(3000).Wait();
        }

        public static void RunSynchronousTask()
        {
            TaskMethod("just the main thread");
            var t1 = new Task(TaskMethod, "run sync");
            t1.RunSynchronously();
        }
    }
}
