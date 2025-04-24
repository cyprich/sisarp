using System;

namespace Uniza.CSharp.PresentationParallel.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mnohe z vnorenych prikladov pochadzaju z knihy Professional C# 7 and .NET Core 2.0 od Christiana Nagela
            // alebo z oficialnej dokumentacie Microsoftu

            // Priklad na Asynchronous Programming Model (APM) / vzor IAsyncResult
            //ExamplePatternApm.Run();

            // Priklad na Event-based Asynchronous Pattern (EAP) / udalost
            //ExamplePatternEap.Run();

            // Priklad na Task-based Asynchronous Pattern (TAP) / async / await
            //ExamplePatternTap.Run();

            // Priklady na paralelny for, foreach, invoke
            //ExampleParallel.Run();

            // Priklad na ulohy
            //ExampleTasks.Run();

            // Priklad na osetrovanie vynimok v ulohach
            //ExampleExceptionHandling.Run();

            // Priklad na cakanie pomocou async
            //ExampleAsyncTasks.Run();

            // Priklad na CancelationToken, ktory nam dava informaciu o tom, ze sa ma zrusit (zastavit) vykonavanie ulohy
            //ExampleCancellation.Run();

            Console.ReadKey();
        }
    }
}
