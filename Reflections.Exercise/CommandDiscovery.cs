using System.Reflection;
using CommandContracts;

namespace Reflections.Exercise;

public record DiscoveredCommand(string Name, Type Type, MethodInfo Method);

public static class CommandDiscovery
{
    public static IReadOnlyList<DiscoveredCommand> Discover(Assembly assembly)
    {
        var commands = new List<DiscoveredCommand>();

        foreach (var type in assembly.GetTypes())
        {
            var attribute = type.GetCustomAttribute<CommandAttribute>();
            if (attribute is null || !type.IsClass)
                continue;

            // Attributes, rather than method names or visibility, select executable methods.
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<ExecuteAttribute>() is not null)
                    commands.Add(new DiscoveredCommand(attribute.Name, type, method));
            }
        }

        return commands;
    }
}
