namespace OCP.Commands.After.Application;

public class CommandLoop
{
    private readonly IReadOnlyList<Command> commands;

    public CommandLoop(IEnumerable<Command> commands)
    {
        this.commands = commands.ToArray();
    }

    public void Run()
    {
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input == null)
            {
                return;
            }

            var parts = input.Split((char[]?)null, 2,
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length == 0)
            {
                continue;
            }

            if (parts[0].Equals("/exit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var selectedCommand = commands.FirstOrDefault(command => command.CanHandle(parts[0]));
            if (selectedCommand != null)
            {
                var arguments = parts.Length > 1 ? parts[1] : "";
                selectedCommand.Execute(arguments);
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }
    }
}
