namespace DIP.Exercise.Starter;

public class FileSalesReportReader : ISalesReportReader
{
    public IEnumerable<string> Read(string inputPath)
    {
        return File.ReadAllLines(inputPath);
    }
}