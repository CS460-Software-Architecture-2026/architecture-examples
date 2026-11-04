namespace DIP.Exercise.Starter;

public interface ITotalReporter
{
    public void report(SortedDictionary<string, decimal> totals, string outputPath);
}