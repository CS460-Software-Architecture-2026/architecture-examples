namespace DIP.Exercise.Starter2Classes.Infrastructure;


public class FileReportPrinter
{
    public void Print(Report report,  string outputPath) {
        File.WriteAllLines(outputPath, report);

        return;
    }
}