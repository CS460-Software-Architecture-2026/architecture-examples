namespace DIP.Exercise.Starter;

public class CSVToSales : ISalesProvider
{
    public override string[] getSalesFrom(string inputPath)
    {
        var lines = File.ReadAllLines(inputPath);
        return lines;
    }
}