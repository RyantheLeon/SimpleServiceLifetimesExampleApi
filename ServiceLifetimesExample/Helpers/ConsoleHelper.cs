namespace SimpleServiceLifetimesExampleApi.Helpers;

internal static class ConsoleHelper
{
    internal static void WriteAndHighlight(string value, ConsoleColor color)
    {
        Console.WriteLine();
        Console.BackgroundColor = color;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(value);
        Console.ResetColor();
    }

    internal static void WriteRequestBreak()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("********************");
        Console.WriteLine();
        Console.WriteLine();
    }

    internal static void PrintInstructions(string value)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(value);
        Console.ResetColor();
    }

    internal static void PrintExplanation(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
    }
}
