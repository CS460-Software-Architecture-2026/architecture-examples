using OCP.Commands.After.Application;

namespace OCP.Commands.After.Commands;

public class TimeCommand : Command
{
    protected override string CommandName => "/time";


    public override void Execute(string arguments)
    {
        Console.WriteLine($"UTC: {DateTimeOffset.UtcNow:HH:mm:ss}");
    }
}
