using System.Globalization;

namespace DIP.Exercise.Starter;

public class SalesReportGenerator
{

    private ISalesProvider salesProvider;
    private ITotalCalculator totalCalculator;
    private ITotalReporter totalReporter;

    public SalesReportGenerator(ISalesProvider salesProvider, ITotalCalculator totalCalculator, ITotalReporter totalReporter)
    {
        this.salesProvider = salesProvider;
        this.totalCalculator = totalCalculator;
        this.totalReporter = totalReporter;
    }
    public void Generate(string inputPath, string outputPath)
    {
        var salesStats = salesProvider.getSalesFrom(inputPath);
        var totals = totalCalculator.getTotal(salesStats);
        totalReporter.report(totals, outputPath);
    }
}
