using Assignment3.Models;

namespace Assignment3.Commands;

public class ChooseFormatCommand : ICommand<string>
{
    public string Execute()
    {
        Console.WriteLine("Available formats:");
        Console.WriteLine(PrintFormat.Xml);
        Console.WriteLine(PrintFormat.Json);
        Console.WriteLine(PrintFormat.Csv);

        while (true)
        {
            string? input = Console.ReadLine();

            switch (input)
            {
                case PrintFormat.Xml:
                case PrintFormat.Json:
                case PrintFormat.Csv:
                    return input;
                default:
                    Console.WriteLine("There is no such format. Please try again.");
                    continue;
            }
        }
    }
}
