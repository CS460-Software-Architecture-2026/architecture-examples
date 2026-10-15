using System.Globalization;

using DIP.Exercise.Starter2Classes.Infrastructure;
namespace DIP.Exercise.Stage2Classes.Application;


public class ReportService
{
    private readonly AmountCalculator amountCalculator = new();
    private readonly ReportGenerator reportGenerator = new();
    private readonly FileReportPrinter fileReportPrinter = new();


    public Report Complete(string inputPath, string outputPath)
    {
        var totals = amountCalculator.Calculate(inputPath);
        var report = reportGenerator.Generate(totals);
        fileReportPrinter.Print(report);
        return report;
    }
}