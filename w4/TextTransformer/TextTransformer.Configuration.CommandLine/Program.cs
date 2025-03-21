using Microsoft.Extensions.Configuration;
using Figgle;


IConfiguration configuration = new ConfigurationBuilder()
    .AddCommandLine(args)
    .Build();

if (args.Length == 0 || configuration["help"] != null)
{
    Console.WriteLine("Description:");
    Console.WriteLine("  Display text to output.");
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  TextTransformer.Classic <text> [--uppercase] [--add-spaces <number>]");
    Console.WriteLine();
    Console.WriteLine("Arguments:");
    Console.WriteLine("  <text>        Input text.");
    Console.WriteLine("  --uppercase   Change the letters to uppercase.");
    Console.WriteLine("  --add-spaces <number>  Add spaces between words.");
    Console.WriteLine("  --help  Show help and usage information.");
    Console.WriteLine("  --font  Specify Figgle font");
    return;
}

string text = args[0];
bool uppercase = configuration["uppercase"] != null;
int addSpaces = int.TryParse(configuration["add-spaces"], out int temp) ? temp : 0;

string fontArg = configuration["font"];
var font = Figgle.FiggleFonts.TryGetByName(fontArg) ?? Figgle.FiggleFonts.Standard;
font.Render(text);

DisplayToOutput(text, uppercase, addSpaces);

static void DisplayToOutput(string text, bool uppercase, int addSpaces)
{
    if (uppercase)
        text = text.ToUpper();

    if (addSpaces > 0)
    {
        var newSpaces = new string(' ', addSpaces);
        text = text.Replace(" ", newSpaces);
    }


    /*Console.WriteLine();*/
}
