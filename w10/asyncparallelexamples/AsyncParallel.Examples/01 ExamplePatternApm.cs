using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Uniza.CSharp.PresentationParallel.Examples
{
    /// <summary>
    /// Priklad na Asynchronous Programming Model (APM).
    /// Zastarany, nemali by ste vobec pouzivat.
    /// </summary>
    class ExamplePatternApm
    {
        public static void Run()
        {
            // Priklad na asynchronne stiahnutie HTML stranky pomocou triedy WebRequest
            DownloadString();

            // Priklad na volanie metody v delegatovi pomocou metody BeginInvoke (asynchronna)
            // V .NET Framework funkcne, v .NET Core nepodporovane - vypise chybu: System.PlatformNotSupportedException: 'Operation is not supported on this platform.'
            //OwnDelegate();
        }

        #region DownloadString

        private static WebRequest _request;

        private static void DownloadString()
        {
            // V sucastnosti je WebRequest deprecated, ale na ucely ukazku modelu APM je to v poriadku
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            _request = WebRequest.Create(new Uri("https://www.fri.uniza.sk/"));
#pragma warning restore SYSLIB0014 // Type or member is obsolete

            Console.WriteLine("Spustam asynchronne stahovanie");
            IAsyncResult result = _request.BeginGetResponse(ReadResponse, null);
            
            Console.WriteLine("Cakam na stlacenie klavesu Enter...");
            Console.ReadLine();
        }

        static void ReadResponse(IAsyncResult ar)
        {
            using (WebResponse response = _request.EndGetResponse(ar))
            {
                Stream stream = response.GetResponseStream();
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();

                    Console.WriteLine("Stranka bola stiahnuta");
                    Console.WriteLine("Prvych 500 znakov: ");
                    Console.WriteLine(content.Substring(0, 500));
                }
            }
        }

        #endregion


        #region Own delegate

        delegate double MyDelegate(int maxValue);

        static void OwnDelegate()
        {
            // Akykolvek delegat obsahuje metodu Invoke pre synchronne zavolanie a BeginInvoke, EndInvoke pre asynchronne
            MyDelegate del = Method1;

            // Synchronne zavolanie metody Method1 (blokuje az dokial nevykona vsetky metody v delegatovi)
            var resultSum = del?.Invoke(1000); // iny sposob: var resultSum = del(1000);

            // Asynchronne zavolanie metody Method1 pomocou delegata; po jej skonceni je zavolana metoda Method1Finished
            // Pozor: V .NET Framework funkcne, v .NET Core nepodporovane - vypise chybu: System.PlatformNotSupportedException: 'Operation is not supported on this platform.'
            IAsyncResult asyncResult = del.BeginInvoke(1000, Method1Finished, null);

            // Zavolanie inej metody Method2 (synchronne) - je vykonavana subezne s Method1
            Method2();

            // Metoda EndInvoke blokuje vlakno - caka az do ukoncenia metod v delegatovi del
            double resultAsyncSum = del.EndInvoke(asyncResult);

            Console.WriteLine("Sum: {0}, Sum (async): {1}", resultSum, resultAsyncSum);
        }

        private static double Method1(int maxValue)
        {
            Console.WriteLine("Method1");

            double sum = 0.0;
            for (int i = 1; i < maxValue; ++i)
            {
                sum += Math.Sqrt(i);
                //Thread.Sleep(1);
            }
            return sum;
        }

        private static void Method2()
        {
            Console.WriteLine("Method2");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Doing other work...{0}", i);
                // Umele spomalenie - uspi vlakno na 1000 milisekund ("simulacia" 1 sekundu trvajucej prace metody)
                Thread.Sleep(1000);
            }
        }

        private static void Method1Finished(object state)
        {
            Console.WriteLine("Method1Finished");
        }

        #endregion
    }
}
