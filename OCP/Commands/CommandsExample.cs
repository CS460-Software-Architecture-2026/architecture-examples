using OCP.Commands.After.Application;
using OCP.Commands.After.Commands;

namespace OCP.Commands;

public class CommandsExample
{
    public void Run()
    {
        Console.WriteLine("BEFORE — /exit continues to the refactored version");
        new Before.CommandLoop().Run();

        Console.WriteLine("AFTER — /exit continues to the quiz exercise");
        // A new command changes registration here; CommandLoop stays unchanged.
        new CommandLoop(new Command[]
        {
            new EchoCommand(),
            new TimeCommand(),
            new PollCommand()
        }).Run();
    }
}
