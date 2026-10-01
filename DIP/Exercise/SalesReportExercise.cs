using DIP.Exercise.Starter;

namespace DIP.Exercise;

public class SalesReportExercise
{
    public void Run()
    {
        Console.WriteLine("SALES REPORT EXERCISE: separate workflow, business rules, and file handling");
        var inputPath = Path.Combine(AppContext.BaseDirectory, "Exercise", "Data", "sales.csv");
        var outputPath = Path.Combine(AppContext.BaseDirectory, "sales-report.txt");

        new SalesReportGenerator(new CSVParser(), new Printer()).Generate(inputPath, outputPath);

        Console.WriteLine(File.ReadAllText(outputPath));
        Console.WriteLine($"Report saved to: {outputPath}");
    }
}
