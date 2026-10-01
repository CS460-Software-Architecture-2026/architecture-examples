using DIP.Exercise.Starter.Application;
using DIP.Exercise.Starter.Infrastructure;

namespace DIP.Exercise;

public class SalesReportExercise
{
    public void Run()
    {
        Console.WriteLine("SALES REPORT EXERCISE: separate workflow, business rules, and file handling");
        var inputPath = Path.Combine(AppContext.BaseDirectory, "Exercise", "Data", "sales.csv");
        var outputPath = Path.Combine(AppContext.BaseDirectory, "sales-report.txt");

        var generator = new SalesReportGenerator(new CsvSalesReader(inputPath), new TextFileReportWriter(outputPath));
        generator.Generate();

        Console.WriteLine(File.ReadAllText(outputPath));
        Console.WriteLine($"Report saved to: {outputPath}");
    }
}
