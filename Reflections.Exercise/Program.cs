using System.Reflection;
using Reflections.Exercise;

try
{
    // Resolve the DLL relative to the executable, regardless of the working directory.
    var assembly = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "UserCommands.dll"));
    var commands = CommandDiscovery.Discover(assembly);
    if (commands.Count == 0)
        throw new InvalidOperationException("No methods marked [Execute] in classes marked [Command] were found.");

    await new CommandRunner(commands).RunAsync();
}
catch (Exception exception)
{
    Console.Error.WriteLine($"Cannot start command runner: {exception.Message}");
    Environment.ExitCode = 1;
}
