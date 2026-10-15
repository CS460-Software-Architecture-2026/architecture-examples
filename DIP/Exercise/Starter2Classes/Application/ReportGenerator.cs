using System.Globalization;

using DIP.Exercise.Starter2Classes.Infrastructure;
namespace DIP.Exercise.Stage2Classes.Application;


public class ReportGenerator{
    public Report Generate(Totals totals) {
        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totals)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totals.Values.Sum():F2}"));
        return report;
    }
}