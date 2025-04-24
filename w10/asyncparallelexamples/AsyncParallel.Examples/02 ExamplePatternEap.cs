using System;
using System.Net;

namespace Uniza.CSharp.PresentationParallel.Examples
{
    /// <summary>
    /// Priklad na Event-based Asynchronous Pattern (EAP).
    /// </summary>
    class ExamplePatternEap
    {
        public static void Run()
        {
            // Priklad na asynchronne zavolanie metody a udalostou notifikovanie o jej skonceni
            DownloadString();

            Console.WriteLine("Cakam na stlacenie klavesu Enter...");
            Console.ReadLine();
        }

        private static void DownloadString()
        {
            // V sucastnosti je WebClient deprecated, ale na ucely ukazku modelu EAP je to v poriadku
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var wc = new WebClient();
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            wc.DownloadStringCompleted += WcOnDownloadStringCompleted;

            Console.WriteLine("Spustam asynchronne stahovanie");
            wc.DownloadStringAsync(new Uri("https://www.fri.uniza.sk/"));
        }

        private static void WcOnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine("Stranka bola stiahnuta");
            Console.WriteLine("Prvych 500 znakov: ");
            Console.WriteLine(e.Result.Substring(0, 500));
        }
    }
}
