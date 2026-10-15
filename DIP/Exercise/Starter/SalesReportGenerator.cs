using System.Globalization;

namespace DIP.Exercise.Starter;

public class SalesReportGenerator
{
    private readonly IReportReader _reader;
    private readonly IReportWriter _writer;

    public SalesReportGenerator()
    {
        _reader = new FileReportReader();
        _writer = new FileReportWriter();
    }

    public SalesReportGenerator(
        IReportReader reader,
        IReportWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Generate(string inputPath, string outputPath)
    {
        var lines = _reader.Read(inputPath);
        var totals = new SortedDictionary<string, decimal>(StringComparer.Ordinal);

        foreach (var line in lines.Skip(1))
        {
            var columns = line.Split(',');
            var category = columns[0];
            var amount = decimal.Parse(columns[1], CultureInfo.InvariantCulture);
            var status = columns[2];

            if (status == "Cancelled")
            {
                continue;
            }

            if (status == "Refunded")
            {
                amount = -amount;
            }

            totals.TryGetValue(category, out var currentTotal);
            totals[category] = currentTotal + amount;
        }

        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totals)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totals.Values.Sum():F2}"));
        _writer.Write(outputPath, report);
    }
}