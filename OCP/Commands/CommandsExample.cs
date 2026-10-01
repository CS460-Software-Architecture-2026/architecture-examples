namespace OCP.Commands;

public class CommandsExample
{
    public void Run()
    {
        Console.WriteLine("COMMANDS: /echo, /time, /exit");
        Console.WriteLine("Enter /exit to continue to the quiz.");
        new CommandLoop().Run();
    }
}
