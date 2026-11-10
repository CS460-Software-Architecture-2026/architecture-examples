namespace DIP.Exercise.Starter.Application;

public interface ISalesReader
{
    IReadOnlyList<Sale> ReadAll();
}
