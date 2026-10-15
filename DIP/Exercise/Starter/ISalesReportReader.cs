namespace DIP.Exercise.Starter;

public interface ISalesReportReader
{
    IEnumerable<string> Read(string inputPath);
}