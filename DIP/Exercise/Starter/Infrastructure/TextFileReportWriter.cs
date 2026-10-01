using DIP.Exercise.Starter.Application;

namespace DIP.Exercise.Starter.Infrastructure;

public class TextFileReportWriter : IReportWriter
{
    private readonly string path;

    public TextFileReportWriter(string path)
    {
        this.path = path;
    }

    public void Write(IReadOnlyDictionary<string, decimal> totalsByCategory)
    {
        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totalsByCategory)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totalsByCategory.Values.Sum():F2}"));
        File.WriteAllLines(path, report);
    }
}
