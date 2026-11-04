using System.Reflection;
using CommandContracts;

// 1. Load assembly
var asm = Assembly.LoadFrom("UserCommands.dll");

// 2. Find commands
foreach (var type in asm.GetTypes())
{
    var command = type.GetCustomAttribute<CommandAttribute>();
    if (command == null)
    {
        continue;
    }

    Console.WriteLine($"Command: {command.Name} ({type.Name})");
 }