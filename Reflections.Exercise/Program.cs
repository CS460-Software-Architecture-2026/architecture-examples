
using System.Reflection;
using CommandContracts;

var assembly = Assembly.LoadFrom(
    Path.Combine(AppContext.BaseDirectory, "UserCommands.dll"));

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();

    if (input == null || input == "exit")
        break;

    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    if (parts.Length == 0)
        continue;
    
    if (parts[0] == "help")
    {
        foreach (var type in assembly.GetTypes())
        {
            var command = type.GetCustomAttribute<CommandAttribute>();

            if (command == null)
                continue;

            foreach (var m in type.GetMethods(
                         BindingFlags.Public | BindingFlags.NonPublic |
                         BindingFlags.Instance | BindingFlags.Static))
            {
                if (m.GetCustomAttribute<ExecuteAttribute>() == null)
                    continue;

                Console.Write(command.Name);

                foreach (var parameter in m.GetParameters())
                    Console.Write($" <{parameter.ParameterType.Name}>");

                Console.WriteLine();
            }
        }

        continue;
    }

    
    
    Type? commandType = null;

    foreach (var type in assembly.GetTypes())
    {
        var command = type.GetCustomAttribute<CommandAttribute>();

        if (command != null && command.Name == parts[0])
        {
            commandType = type;
            break;
        }
    }

    if (commandType == null)
    {
        Console.WriteLine("Command not found");
        continue;
    }
    
    MethodInfo? method = null;

    foreach (var m in commandType.GetMethods(
                 BindingFlags.Public | BindingFlags.NonPublic |
                 BindingFlags.Instance | BindingFlags.Static))
    {
        if (m.GetCustomAttribute<ExecuteAttribute>() != null)
        {
            method = m;
            break;
        }
    }

    if (method == null)
    {
        Console.WriteLine("Execute method not found");
        continue;
    }

    var parameters = method.GetParameters();

    if (parameters.Length != parts.Length - 1)
    {
        Console.WriteLine("Wrong number of arguments");
        continue;
    }
    
    try
    {
        object?[] arguments = new object?[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            var value = parts[i + 1];

            if (parameters[i].ParameterType == typeof(int))
                arguments[i] = int.Parse(value);
            else if (parameters[i].ParameterType == typeof(bool))
                arguments[i] = bool.Parse(value);
            else if (parameters[i].ParameterType == typeof(string))
                arguments[i] = value;
            else
                throw new Exception("Unsupported argument type");
        }

        object? instance = null;

        if (!method.IsStatic)
            instance = Activator.CreateInstance(commandType);

        var result = method.Invoke(instance, arguments);

        if (result != null)
            Console.WriteLine(result);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e.InnerException?.Message ?? e.Message}");
    }
}
