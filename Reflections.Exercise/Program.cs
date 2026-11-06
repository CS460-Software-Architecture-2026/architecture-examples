using System.Reflection;
using CommandContracts;

var commandsAssemblyPath = Path.Combine(AppContext.BaseDirectory, "UserCommands.dll");
if (!File.Exists(commandsAssemblyPath))
{
    throw new FileNotFoundException("Could not find UserCommands.dll.", commandsAssemblyPath);
}

var commandsAssembly = Assembly.LoadFrom(commandsAssemblyPath);
var commands = commandsAssembly
    .GetTypes()
    .Select(type => new
    {
        Type = type,
        Attribute = type.GetCustomAttribute<CommandAttribute>(inherit: false)
    })
    .Where(command => command.Attribute is not null)
    .Select(command => new
    {
        command.Type,
        Name = command.Attribute!.Name,
        ExecuteMethods = command.Type
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            .Where(method =>
                method.GetCustomAttribute<ExecuteAttribute>(inherit: false) is not null
                && method.GetParameters().Length == 0)
            .ToArray()
    })
    .ToArray();

if (args.Length == 0)
{
    Console.WriteLine("Available commands:");
    foreach (var command in commands)
    {
        Console.WriteLine($"  {command.Name}");
    }

    Console.WriteLine("\nRun a parameterless command with: dotnet run -- <command>");
    return;
}

if (args.Length != 1)
{
    throw new ArgumentException("This stage accepts only a command name; command arguments are not supported yet.");
}

var matchingCommands = commands
    .Where(command => string.Equals(command.Name, args[0], StringComparison.OrdinalIgnoreCase))
    .ToArray();

if (matchingCommands.Length != 1)
{
    throw new InvalidOperationException(
        matchingCommands.Length == 0
            ? $"No command named '{args[0]}' was found."
            : $"More than one command is named '{args[0]}'.");
}

var selectedCommand = matchingCommands[0];
if (selectedCommand.ExecuteMethods.Length != 1)
{
    throw new InvalidOperationException(
        selectedCommand.ExecuteMethods.Length == 0
            ? $"Command '{selectedCommand.Name}' has no parameterless [Execute] method."
            : $"Command '{selectedCommand.Name}' has more than one parameterless [Execute] method.");
}

var executeMethod = selectedCommand.ExecuteMethods[0];
var instance = executeMethod.IsStatic ? null : Activator.CreateInstance(selectedCommand.Type);
executeMethod.Invoke(instance, parameters: null);
