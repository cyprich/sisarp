using System.Text;

//args.Order();
Array.Sort(args);

System.Console.WriteLine(args.Length);
StringBuilder sb = new();

int index = 0;
foreach (var arg in args)
{
    System.Console.WriteLine($"{++index}. {arg} [dlzka = {arg.Length}]");
    sb.Append(arg);
}

System.Console.WriteLine(sb.ToString());
