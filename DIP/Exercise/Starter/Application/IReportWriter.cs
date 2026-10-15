namespace DIP.Exercise.Starter.Application;

public interface IReportWriter
{
    void Write(IReadOnlyDictionary<string, decimal> totalsByCategory);
}
