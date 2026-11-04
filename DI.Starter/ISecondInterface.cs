public interface ISecondInterface
{
    // Відкриті назовні, щоб у Program.cs можна було перевірити,
    // які саме об'єкти контейнер передав у конструктор
    IFirstInterface First { get; }

    ILogger Logger { get; }
}


public class SecondImplementation : ISecondInterface
{
    public IFirstInterface First { get; }

    public ILogger Logger { get; }

    // SecondImplementation не знає, звідки беруться залежності — їх дає контейнер
    public SecondImplementation(IFirstInterface firstInterface, ILogger logger)
    {
        First = firstInterface;
        Logger = logger;
    }

    public override string ToString()
    {
        return $"Second_{GetHashCode()}";
    }
}
