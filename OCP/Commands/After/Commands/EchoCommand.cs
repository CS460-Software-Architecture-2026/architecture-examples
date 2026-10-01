using OCP.Commands.After.Application;

namespace OCP.Commands.After.Commands;

public class EchoCommand : Command
{
    protected override string CommandName => "/echo";

    public override void Execute(string arguments)
    {
        Console.WriteLine(arguments);
    }
}
