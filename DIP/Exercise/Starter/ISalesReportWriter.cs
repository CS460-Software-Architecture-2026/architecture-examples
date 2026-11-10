namespace DIP.Exercise.Starter;

public interface ISalesReportWriter
{
    void Write(string outputPath, IEnumerable<string> report);
}