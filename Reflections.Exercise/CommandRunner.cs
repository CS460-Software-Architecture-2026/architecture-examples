using System.Reflection;

namespace Reflections.Exercise;

public class CommandRunner
{
    private readonly IReadOnlyList<DiscoveredCommand> commands;

    public CommandRunner(IReadOnlyList<DiscoveredCommand> commands)
    {
        this.commands = commands;
    }

    public void PrintHelp()
    {
        foreach (var command in commands.OrderBy(command => command.Name))
        {
            var parameters = command.Method.GetParameters()
                .Select(parameter => $"<{parameter.Name}:{parameter.ParameterType.Name}>");
            Console.WriteLine($"{command.Name} {string.Join(" ", parameters)}".TrimEnd());
        }

        Console.WriteLine("help - list commands; exit - quit");
    }

    public async Task RunAsync()
    {
        PrintHelp();
        while (true)
        {
            Console.Write("> ");
            var line = Console.ReadLine();
            if (line is null)
                return;

            var tokens = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
                continue;
            if (tokens[0].Equals("exit", StringComparison.OrdinalIgnoreCase))
                return;
            if (tokens[0].Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                PrintHelp();
                continue;
            }

            try
            {
                await ExecuteAsync(tokens[0], tokens[1..]);
            }
            catch (TargetInvocationException exception)
            {
                Console.WriteLine($"Execution error: {exception.InnerException?.Message ?? exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }
    }

    private async Task ExecuteAsync(string name, string[] arguments)
    {
        var candidates = commands.Where(command =>
            command.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToArray();
        if (candidates.Length == 0)
            throw new ArgumentException($"Unknown command '{name}'. Enter help to list commands.");

        // More than one [Execute] method can share a command name.
        var matches = new List<(DiscoveredCommand Command, object?[] Arguments)>();
        var errors = new List<string>();
        foreach (var candidate in candidates)
        {
            try
            {
                matches.Add((candidate, ArgumentConverter.Convert(arguments, candidate.Method.GetParameters())));
            }
            catch (ArgumentException exception)
            {
                errors.Add(exception.Message);
            }
        }

        if (matches.Count == 0)
            throw new ArgumentException(string.Join(" ", errors.Distinct()));
        if (matches.Count > 1)
            throw new ArgumentException($"Ambiguous command '{name}': more than one signature matches.");

        var (command, converted) = matches[0];
        var instance = command.Method.IsStatic ? null : Activator.CreateInstance(command.Type);
        var result = command.Method.Invoke(instance, converted);

        if (result is Task task)
        {
            await task;
            result = command.Method.ReturnType.IsGenericType
                ? task.GetType().GetProperty("Result")?.GetValue(task)
                : null;
        }

        if (result is not null)
            Console.WriteLine(result);
    }
}
