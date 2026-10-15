namespace DIP.Exercise.Starter;

public interface IReportBuilder
{
    List<string> Build(SortedDictionary<string, decimal> totals);
}