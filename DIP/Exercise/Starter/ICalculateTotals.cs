namespace DIP.Exercise.Starter;

public interface ICalculateTotals
{
    SortedDictionary<string, decimal> Calculate(String[] lines);
}