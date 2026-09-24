namespace DIP.Exercise.Starter;

public interface ITotalCalculator
{
    public SortedDictionary<string, decimal> getTotal(string inputPath);
}
