namespace DIP.Exercise.Starter;

public class Reportator : ITotalReporter
{
    public override void report(SortedDictionary<string, decimal> totals, string outputPath)
    {
        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totals)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totals.Values.Sum():F2}"));
        File.WriteAllLines(outputPath, report);
    }
}