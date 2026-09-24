namespace DIP.Exercise.Starter;

public interface ICSVParser
{
    Totals Generate(string inputPath);
}