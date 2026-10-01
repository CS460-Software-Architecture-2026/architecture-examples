namespace DIP.Exercise.Starter;

public class ReportBuilder: IReportBuilder
{
    public List<string> Build(SortedDictionary<string, decimal> totals)
    {
        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totals)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totals.Values.Sum():F2}"));
        
        return report;
    }
}