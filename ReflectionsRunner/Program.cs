using System.Reflection;
using System.Windows.Input;
using CommandContracts;

Assembly asm = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "UserCommands.dll"));

Console.WriteLine("=== Types in assembly ===");
foreach (var t in asm.GetTypes())
{
    Console.WriteLine(t.FullName);
}

var commandTypes = asm.GetTypes().Where(t => t.GetCustomAttribute<CommandAttribute>() != null).ToArray();

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine().Trim();
    
    if (input == "exit") break;
    var commandType =
        commandTypes.FirstOrDefault(type => string.Equals(type.GetCustomAttribute<CommandAttribute>().Name, input));
}