using System.Globalization;

namespace DIP.Exercise.Starter;

public class SalesReportGenerator
{
    private readonly ICSVParser parser;
    private readonly IPrinter printer;

    public SalesReportGenerator(ICSVParser parser, IPrinter printer)
    {
        this.parser = parser;
        this.printer = printer;
    }
    
    public void Generate(string inputPath, string outputPath)
    {
        
        var totals = parser.Generate(inputPath);
        printer.Report(outputPath, totals); 
        
        // Intentionally mixed: workflow, business rules, CSV parsing, and text output.

    }
}
