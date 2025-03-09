namespace RotatingNews;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 3)
            {
                Console.Error.WriteLine("Nezadali ste 3 argumenty");
                return;
            }

            string message = args[0];
            int row = int.Parse(args[1]);
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[2], true);

            Console.ForegroundColor = color;
            Console.CursorTop = row - 1;
            Console.CursorVisible = false;

            int index = Console.WindowWidth - 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    break;
                }

                Console.CursorLeft = index;
                Console.CursorTop = row;

                Console.WriteLine(message);

                index--;
                if (index < 0)
                {
                    index = Console.WindowWidth - 1;
                }

                Thread.Sleep(50);
                /*await Task.Delay(1000);*/
                Console.Clear();
            }

        }
        finally
        {
            Console.ResetColor();
            Console.CursorVisible = true;
        }
    }
}
