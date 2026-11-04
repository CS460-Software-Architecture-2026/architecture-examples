// Завдання 1: нова залежність
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[{this}] {message}");
    }

    public override string ToString()
    {
        return $"Logger_{GetHashCode()}";
    }
}
