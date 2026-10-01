namespace DIP.Exercise.Starter;

public class FileSalesReportWriter : ISalesReportWriter
{
    public void Write(
        string outputPath,
        IEnumerable<string> report)
    {
        File.WriteAllLines(outputPath, report);
    }
}