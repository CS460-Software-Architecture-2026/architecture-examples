using System.Reflection;

Assembly asm = Assembly.LoadFrom("C:\\Year3Term1\\CS460\\architecture-examples\\Reflections.Exercise\\UserCommands.dll");


Console.WriteLine("Available commands (for now only check):\n");

foreach (var type in asm.GetTypes())
{
    if (type.GetCustomAttributes().Any(a => a.GetType().Name == "CommandAttribute"))
    {
        foreach (var m in type.GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType().Name == "ExecuteAttribute")))
        {
            var paramList = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
            Console.WriteLine($"{m.ReturnType.Name} {m.Name}({paramList})");
            
        }
    }
}

// var commands = new Dictionary<string, instance + method + arg list types>>(StringComparer.OrdinalIgnoreCase);
//
// foreach (var type in asm.GetTypes())
// {
//     if (type.GetCustomAttributes().Any(a => a.GetType().Name == "CommandAttribute"))
//     {
//         foreach (var m in type.GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType().Name == "ExecuteAttribute")))
//         {
//             var instance = Activator.CreateInstance(type)!;
//             commands[m.Name] =
//         }
//     }
// }



bool is_exit = false;
while (!is_exit)
{
    Console.Write("Enter command: ");
    string? command = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(command)) continue;

    string[] split = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var commandName = split[0];
    //
    // if (commands.TryGetValue(commandName, out ))
    // {
    // }
    
    if (commandName == "check")
    {
        foreach (var type in asm.GetTypes())
        {
            if (type.GetCustomAttributes().Any(a => a.GetType().Name == "CommandAttribute"))
            {
                foreach (var m in type.GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType().Name == "ExecuteAttribute")))
                {
                    var instance = Activator.CreateInstance(type)!;
                    
                    if (m.Name == "Check")
                    {
                        m.Invoke(instance, null);
                        var paramList = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        Console.WriteLine($"{m.ReturnType.Name} {m.Name}({paramList})");
                        Console.WriteLine("Invoked check");
                    }
                }
            }
        }

        
    }
    is_exit = commandName == "exit";
}




// 2. List all types
// Console.WriteLine("=== Types in assembly ===");
// foreach (var t in asm.GetTypes())
// {
//     Console.WriteLine(t.FullName);
// }

//
//discovers classes marked `[Command]`,
//reads the command name from `CommandAttribute.Name`, and finds their methods marked `[Execute]`.
// Start with parameterless calls, then support positional `string`, `int`, and `bool` arguments.
// Handle invalid input and execution errors without terminating the loop, and add `exit`.


// foreach (var type in asm.GetTypes())
// {
//     Console.Write(type);
//     Console.Write(" ");
//     foreach (var attribute in type.GetCustomAttributes())
//     {
//      Console.Write(attribute.GetType().Name);   
//     Console.Write(" ");
//      
//     }
//
// }

// foreach (var type in asm.GetTypes())
// {
//     if (type.GetCustomAttributes().Any(a => a.GetType().Name == "CommandAttribute"))
//     {
//         foreach (var m in type.GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType().Name == "ExecuteAttribute")))
//         {
//             foreach (var ctor in type.GetConstructors())
//             {
//                 var paramList = string.Join(", ", ctor.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
//                 Console.WriteLine($"{type.Name}({paramList})");
//             }
//             
//         }
//     }
// }
//

// foreach (var type in asm.GetTypes())
// {
//     if (type.GetCustomAttributes().Any(a => a.GetType().Name == "CommandAttribute"))
//     {
//         foreach (var m in type.GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType().Name == "ExecuteAttribute")))
//         {
//             
//             
//             Console.WriteLine(type);
//             
//             var instance = Activator.CreateInstance(type)!;
//             
//             if (m.Name == "Check")
//             {
//                 m.Invoke(instance, null);
//                 var paramList = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
//                 Console.WriteLine($"{m.ReturnType.Name} {m.Name}({paramList})");
//             }
//         }
//     }
// }

// // 8. Create instance dynamically
// Console.WriteLine("\n=== Create Instance ===");
// Console.WriteLine(instance);
//
// // 9. Invoke method
// Console.WriteLine("\n=== Invoke Method ===");
// var greetMethod = userType.GetMethod("Greet");
// greetMethod!.Invoke(instance, null);
//
// // 9. Check attributed methods
// Console.WriteLine("\n=== Methods with [ObsoleteMethodAttribute] ===");
// var executeMethods = userType               
//     .GetMethods(BindingFlags.Public | BindingFlags.NonPublic 
//                                     | BindingFlags.Instance | BindingFlags.Static)
//     .Where(m => m.GetCustomAttribute(typeof(ObsoleteMethodAttribute)) != null);
//
// foreach (var m in executeMethods)
// {
//     Console.WriteLine($"Method: {m.Name}");
// }