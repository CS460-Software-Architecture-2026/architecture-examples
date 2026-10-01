using OCP.Commands.After.Application;

namespace OCP.Commands.After.Commands;

public class PollCommand : Command
{
    
    protected override string CommandName => "/poll";


    public override void Execute(string arguments)
    {
        var parts = arguments.Split('|', StringSplitOptions.TrimEntries);
        if (parts.Length < 3 || parts.Any(string.IsNullOrWhiteSpace))
        {
            Console.WriteLine("Usage: /poll question | option | option");
            return;
        }

        Console.WriteLine($"Poll: {parts[0]}");
        for (var index = 1; index < parts.Length; index++)
        {
            Console.WriteLine($"{index}. {parts[index]}");
        }
    }
}
