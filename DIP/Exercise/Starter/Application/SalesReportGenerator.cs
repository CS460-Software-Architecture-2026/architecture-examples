namespace DIP.Exercise.Starter.Application;

public class SalesReportGenerator
{
    private readonly ISalesReader salesReader;
    private readonly IReportWriter reportWriter;

    public SalesReportGenerator(ISalesReader salesReader, IReportWriter reportWriter)
    {
        this.salesReader = salesReader;
        this.reportWriter = reportWriter;
    }

    public void Generate()
    {
        var totals = new SortedDictionary<string, decimal>(StringComparer.Ordinal);

        foreach (var sale in salesReader.ReadAll())
        {
            if (sale.Status == "Cancelled")
            {
                continue;
            }

            var amount = sale.Status == "Refunded" ? -sale.Amount : sale.Amount;
            totals.TryGetValue(sale.Category, out var currentTotal);
            totals[sale.Category] = currentTotal + amount;
        }

        reportWriter.Write(totals);
    }
}
