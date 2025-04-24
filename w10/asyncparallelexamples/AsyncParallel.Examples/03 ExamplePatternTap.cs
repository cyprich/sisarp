using System;
using System.Net;
using System.Threading.Tasks;

namespace Uniza.CSharp.PresentationParallel.Examples
{
    /// <summary>
    /// Priklad Task-based Asynchronous Pattern (TAP).
    /// Najnovsi sposob, mali by ste pouzivat.
    /// </summary>
    class ExamplePatternTap
    {
        public static void Run() //public static async void Run()
        {
            DownloadString(); //await DownloadString(); // nezabudnite pridat async do hlavicky metody pred void

            Console.WriteLine("Cakam na stlacenie klavesu Enter...");
            Console.ReadLine();
        }

        private static async Task DownloadString()
        {
            /// V sucastnosti je WebClient deprecated, mal by sa pouzivat HttpClient
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var wc = new WebClient();
#pragma warning restore SYSLIB0014 // Type or member is obsolete

            Console.WriteLine("Spustam asynchronne stahovanie");
            var result = await wc.DownloadStringTaskAsync(new Uri("https://www.fri.uniza.sk/"));

            Console.WriteLine("Stranka bola stiahnuta");
            Console.WriteLine("Prvych 500 znakov: ");
            Console.WriteLine(result.Substring(0, 500));
        }
    }
}
