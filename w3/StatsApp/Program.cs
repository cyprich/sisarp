var file = File.ReadAllLines("txt/numbers.txt");
int[] numbers = new int[file.Length];

for (int i = 0; i < file.Length; i++)
{
    numbers[i] = int.Parse(file[i]);
}

void PrintStatistics(ReadOnlySpan<int> span)
{
    int sum = 0;

    foreach (var i in span)
    {
        sum += i;
    }

    double mean = (double)sum / file.Length;

    double variance = 0;

    foreach (var i in span)
    {
        variance += Math.Pow(i - mean, 2);
    }

    variance /= file.Length;

    System.Console.WriteLine($"\tSuma: {sum}");
    System.Console.WriteLine($"\tPriemer: {mean}");
    System.Console.WriteLine($"\tRozptyl: {variance}\n");
}


System.Console.WriteLine($"Prvy prvok: {file[0]}");
System.Console.WriteLine($"Posledny prvok: {file[^1]}");
System.Console.WriteLine($"Prostredny prvok: {file[file.Length / 2]}\n");

PrintStatistics(numbers);

var a = numbers.AsSpan();
a[..300].Clear();
System.Console.WriteLine("Prvych 300 prvkov = 0");
PrintStatistics(a);

a = numbers.AsSpan();
a[4000..6001].Fill(500);
System.Console.WriteLine("Prvky 4000 az 6000 = 500");
PrintStatistics(a);

a = numbers.AsSpan();
System.Console.WriteLine("od indexu 5000");
PrintStatistics(a[5000..]);
