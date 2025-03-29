using Uniza.CSharp.Generics.DataStructures;
using Uniza.CSharp.Generics.Tools;

namespace Uniza.CSharp.Generics.App;

public record Vehicle(string Brand, string Model)
{
    public string Brand { get; init; } = Brand;
    public string Model { get; init; } = Model;
}

class Program
{
    static void Main()
    {
        SwapExample();
        DoublyLinkedListExample();
    }

    private static void SwapExample()
    {
        var a = 10;
        var b = 20;
        Swapper.Swap(ref a, ref b);
        // V premenných by mali byť tieto hodnoty:
        // a = 20, b = 10
        Console.WriteLine($"{a} {b}");
 
        var d1 = Math.PI;
        var d2 = Math.E;
        Swapper.Swap(ref d1, ref d2);
        // V premenných by mali byť tieto hodnoty:
        // d1 = Math.E, d2 = Math.PI
        Console.WriteLine($"{d1} {d2}");

        var hello = "Ahoj";
        var world = "svet";
        Swapper.Swap(ref hello, ref world);
        // V premenných by mali byť tieto hodnoty:
        // hello = "svet", world = "Ahoj"
        Console.WriteLine($"{hello} {world}");

        // TODO: Úloha 1.1 - Opravte chyby, aby prehodenie hodnôt fungovalo a bol nasledujúci požadovaný výstup: 
        // 20 10
        // 2,718281828459045 3,141592653589793
        // svet Ahoj
    }

    private static void DoublyLinkedListExample()
    {
        //var list = new DoublyLinkedList();
        //list.Add("biela");
        //list.Add("modra");
        //list.Add("cervena");
        //for (int i = 0; i < list.Count; i++)
        //{
        //    Console.WriteLine(list[i]);
        //}

        // TODO: Úloha 1.4 - Prebte zoznam na generický a následne odkomentujte nasledujúci kód:
        var list = new GenericDoublyLinkedList<string>();
        list.Add("biela");
        list.Add("modra");
        list.Add("cervena");

        var numbers = new GenericDoublyLinkedList<int>();
        for (int i = 1; i < 6; i++)
            numbers.Add(i);

        //Prechod cez indexer:
        for (int i = 0; i < numbers.Count; i++)
            Console.WriteLine(numbers[i]);

        // TODO: Úloha 1.5 - Implementujte rozhranie IEnumberable<T> v triede DoublyLinkedList a odkomentujte nasledujúci kód:
        // Prechod cez enumerátor:
        var enumerator = numbers.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var number = enumerator.Current;
            Console.WriteLine(number);
        }


        // Prechod cez foreach - s využitím enumerátora:
        foreach (var number in numbers)
            Console.WriteLine(number);

        // TODO: Úloha 1.6 - Implementujte metódu GetReverse() v triede DoublyLinkedList a odkomentujte nasledujúci kód:
        foreach (var number in numbers.GetReverse())
            Console.WriteLine(number);

        // TODO: Úloha 1.7 - Vytvorte rekord Vehicle a vytvorte zoznam vozidiel, ktorý bude obsahovať záznamy o vozidlách
        var vehicles = new GenericDoublyLinkedList<Vehicle>();
        vehicles.Add(new("Skoda", "Oktavia"));
        vehicles.Add(new("Volkswagen", "Golf"));

        foreach (var v in vehicles)
        {
            Console.WriteLine(v);
        }
    }
}
