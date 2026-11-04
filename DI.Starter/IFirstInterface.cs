public interface IFirstInterface
{
    void Print(string message);
}

public class FirstImplementation : IFirstInterface
{
    private readonly IPrinter printer;

    public FirstImplementation(IPrinter printer)
    {
        this.printer = printer;
    }

    public IPrinter Printer => printer;

    public void Print(string message)
    {
        printer.Print(message);
    }

    public override string ToString()
    {
        return $"First_{GetHashCode()}";
    }
}

public interface IPrinter
{
    void Print(string message);
}

public class ConsolePrinter : IPrinter
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}