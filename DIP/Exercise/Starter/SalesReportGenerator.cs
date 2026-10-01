using System.Globalization;

namespace DIP.Exercise.Starter;

public class SalesReportGenerator
{
    private readonly ICalculateTotals calculateTotals;
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IReportBuilder reportBuilder;

    public SalesReportGenerator(IReader reader, IWriter writer, ICalculateTotals calculateTotals, IReportBuilder reportBuilder)
    {
        this.writer = writer;
        this.reader = reader;
        this.calculateTotals = calculateTotals;
        this.reportBuilder = reportBuilder;
    }
    
    public void Generate()
    {
        var lines = reader.Read();
        var totals = calculateTotals.Calculate(lines);
        var report = reportBuilder.Build(totals);
        writer.Write(report);
    }
}
