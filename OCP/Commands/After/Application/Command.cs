namespace OCP.Commands.After.Application;

public abstract class Command
{
    protected abstract string CommandName { get; }

    public bool CanHandle(string input)
    {
        return input.Equals(CommandName, StringComparison.OrdinalIgnoreCase);
    }

    public abstract void Execute(string arguments);
}
